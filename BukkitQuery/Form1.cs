using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

using BukkitQuery.Components;

namespace BukkitQuery {

    public partial class MainWindow : Form {

        public MainWindow() {
            InitializeComponent();
            LoadServerList();
            AttachEventListeners();  // is there a race condition here?
        }


        private void LoadServerList() {

            List<BukkitServer> servers = ReadServersFromXml();
            PopulateServersListBox(servers);

        }


        private List<BukkitServer> ReadServersFromXml() {

            try {
                using (XmlTextReader reader = new XmlTextReader("servers.xml")) {

                    XmlSerializer xml = new XmlSerializer(
                        typeof(List<BukkitServer>),
                        new Type[] { typeof(BukkitServer) }
                    );

                    return (List<BukkitServer>)xml.Deserialize(reader);

                }

            } catch (InvalidOperationException e) {
                if (e.InnerException is FileNotFoundException) {
                    return new List<BukkitServer>();
                } else throw e;
            }
        }


        private void PopulateServersListBox(List<BukkitServer> servers) {

            ServersListBox.Items.Clear();
            foreach (BukkitServer thisServer in servers) {
                ServersListBox.Items.Add(thisServer);
                RefreshServer(thisServer);
            }

        }


        private void AttachEventListeners() {

            foreach (object o in ServersListBox.Items) {
                ((BukkitServer)o).StatusChanged += ServerStatusChanged;
            }

        }


        void ServersListBox_DrawItem(object sender, DrawItemEventArgs e) {

            var thisServer = (BukkitServer)ServersListBox.Items[e.Index];

            DrawBackground(thisServer, e);
            DrawServerName(thisServer, e);
            DrawPlayersString(thisServer, e);

        }


        private void DrawBackground(BukkitServer thisServer, DrawItemEventArgs e) {

            if (thisServer == (BukkitServer)ServersListBox.SelectedItem) {
                e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), e.Bounds);
            }

        }


        private static void DrawServerName(BukkitServer thisServer, DrawItemEventArgs e) {

            e.Graphics.DrawString(thisServer.ServerName,
                e.Font, thisServer.ServerBrush, e.Bounds, StringFormat.GenericDefault);

        }


        private void DrawPlayersString(BukkitServer thisServer, DrawItemEventArgs e) {

            string playersString = thisServer.BuildPlayersString();

            if (playersString.Length > 0) {

                e.Graphics.DrawString(playersString,
                    e.Font, thisServer.ServerBrush, CalculatePlayersRectangle(playersString, e), StringFormat.GenericDefault);

            }

        }



        private Rectangle CalculatePlayersRectangle(string playersString, DrawItemEventArgs e) {

            int playersWidth = (int)System.Math.Ceiling(e.Graphics.MeasureString(playersString, e.Font).Width);
            int playersX = (int)(e.Bounds.Right - playersWidth);
            return new Rectangle(playersX, e.Bounds.Y, playersWidth, e.Bounds.Height);

        }



        private void RefreshServer(BukkitServer server) {

            server.Status = BukkitServer.ServerStatus.Unknown;

            var bgw = server.AttachedWorker = new BackgroundWorker();

            bgw.DoWork += UpdateServer_DoWork;

            bgw.RunWorkerCompleted += delegate {
                ServersListBox.Refresh();
            };

            bgw.RunWorkerAsync(server);

        }


        private void AddServerTool_Click(object sender, EventArgs e) {

            AddServerForm addServerForm = new AddServerForm();
            DialogResult addResult = addServerForm.ShowDialog(this);
            if (addResult == DialogResult.OK) {

                BukkitServer newServer = new BukkitServer {
                    ServerName = addServerForm.ServerNameTextBox.Text,
                    ServerAddress = addServerForm.IPAddressTextBox.Text,
                    QueryPort = Int32.Parse(addServerForm.MinequeryPortTextBox.Text)
                };

                newServer.StatusChanged += ServerStatusChanged;

                ServersListBox.Items.Add(newServer);
                SaveServerList();
                RefreshServer(newServer);

            }

        }


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }


        private void UpdateServer_DoWork(object sender, DoWorkEventArgs e) {

            // prepare local variables
            BukkitServer server = (BukkitServer)e.Argument;
            byte[] data = Encoding.ASCII.GetBytes("QUERY\n");
            byte[] receiveBuffer = new byte[256];
            string responseString = "";

            // send the request, and receive the response
            try {
                using (TcpClient client = new TcpClient(server.ServerAddress, server.QueryPort)) {

                    using (NetworkStream stream = client.GetStream()) {

                        stream.Write(data, 0, data.Length);
                        do {
                            int bytes = stream.Read(receiveBuffer, 0, receiveBuffer.Length);
                            responseString += Encoding.ASCII.GetString(receiveBuffer, 0, bytes);
                            Array.Clear(receiveBuffer, 0, bytes);
                        } while (!responseString.EndsWith("]\n"));

                    }

                }
            } catch (Exception) {
                if(server.AttachedWorker == sender as BackgroundWorker)
                    server.Status = BukkitServer.ServerStatus.Unreachable;
            }


            if ((server.AttachedWorker == (BackgroundWorker)sender) && (server.Status == BukkitServer.ServerStatus.Unknown)) {

                // parse the response string:
                server.PlayerList = new List<string>();
                string[] responseLines = responseString.Trim().Split('\n');

                foreach (string thisLine in responseLines) {

                    string property = thisLine.Substring(0, thisLine.IndexOf(' '));
                    string value = thisLine.Substring(thisLine.IndexOf(' ') + 1);

                    switch (property) {

                        case "SERVERPORT":
                            server.ServerPort = Int32.Parse(value);
                            break;

                        case "PLAYERCOUNT":
                            server.PlayerCount = Int32.Parse(value);
                            break;

                        case "MAXPLAYERS":
                            server.MaxPlayers = Int32.Parse(value);
                            break;

                        case "PLAYERLIST":
                            // [zealotrush, silvertongue514]
                            string[] players = value.TrimEnd(']').TrimStart('[').Split(',');
                            foreach (string thisPlayer in players) {
                                server.PlayerList.Add(thisPlayer.Trim());
                            }
                            break;

                    }

                }

                if (server.PlayerCount >= server.MaxPlayers) {
                    server.Status = BukkitServer.ServerStatus.Full;
                } else server.Status = BukkitServer.ServerStatus.Online;

            }

        }


        private void ServersListBox_SelectedIndexChanged(object sender, EventArgs e) {
            ServersListBox.Refresh();
            UpdateServerDetailLabels();
        }


        private void UpdateServerDetailLabels() {

            BukkitServer selectedServer = ServersListBox.SelectedItem as BukkitServer;

            if (selectedServer == null) {

                ServerInfoGroupBox.Visible = false;
                PlayersOnlineGroupBox.Visible = false;
                EditToolStripButton.Enabled = false;
                RefreshToolStripButton.Enabled = false;
                DeleteToolStripButton.Enabled = false;

            } else {

                ServerInfoGroupBox.Visible = true;
                EditToolStripButton.Enabled = true;
                RefreshToolStripButton.Enabled = true;
                DeleteToolStripButton.Enabled = true;
                HostValueLabel.Text = selectedServer.ServerAddress;
                StatusValueLabel.Text = selectedServer.Status.ToString();
                switch (selectedServer.Status) {

                    case BukkitServer.ServerStatus.Full:
                    case BukkitServer.ServerStatus.Online:
                        PortValueLabel.Text = selectedServer.ServerPort.ToString();
                        MaxPlayersValueLabel.Text = selectedServer.MaxPlayers.ToString();
                        OpenSlotsValueLabel.Text = (selectedServer.MaxPlayers - selectedServer.PlayerCount).ToString();
                        PlayersOnlineGroupBox.Visible = true;
                        PlayersOnlineListBox.Items.Clear();
                        PlayersOnlineListBox.Items.AddRange(selectedServer.PlayerList.ToArray());
                        break;

                    case BukkitServer.ServerStatus.Unknown:
                        PortValueLabel.Text = "Waiting for result...";
                        OpenSlotsValueLabel.Text = MaxPlayersValueLabel.Text = "Waiting for result...";
                        PlayersOnlineGroupBox.Visible = false;
                        break;

                    case BukkitServer.ServerStatus.Unreachable:
                        PortValueLabel.Text = "Unknown";
                        OpenSlotsValueLabel.Text = MaxPlayersValueLabel.Text = "N/A";
                        PlayersOnlineGroupBox.Visible = false;
                        break;

                }
                
            }

        }


        private void refreshAllToolStripMenuItem_Click(object sender, EventArgs e) {
            foreach (BukkitServer server in ServersListBox.Items) {
                RefreshServer(server);
            }
        }


        private void RefreshToolStripButton_Click(object sender, EventArgs e) {
            RefreshServer(ServersListBox.SelectedItem as BukkitServer);
        }


        private void DeleteToolStripButton_Click(object sender, EventArgs e) {
            ServersListBox.Items.Remove(ServersListBox.SelectedItem);
            SaveServerList();
        }


        private void SaveServerList() {
            using (XmlTextWriter writer = new XmlTextWriter("servers.xml", Encoding.UTF8)) {
                XmlSerializer xml = new XmlSerializer(
                    typeof(List<BukkitServer>), 
                    new Type[] { typeof(BukkitServer) });
                List<BukkitServer> servers = new List<BukkitServer>();
                foreach (BukkitServer thisServer in ServersListBox.Items) {
                    servers.Add(thisServer);
                }
                xml.Serialize(writer, servers);
            }
        }
                






        private void EditToolStripButton_Click(object sender, EventArgs e) {

            BukkitServer serverToEdit = ServersListBox.SelectedItem as BukkitServer;
            AddServerForm addServerForm = new AddServerForm(serverToEdit.ServerName, serverToEdit.ServerAddress, serverToEdit.QueryPort);
            DialogResult editResult = addServerForm.ShowDialog(this);
            if (editResult == DialogResult.OK) {
                serverToEdit.ServerName = addServerForm.ServerNameTextBox.Text;
                serverToEdit.ServerAddress = addServerForm.IPAddressTextBox.Text;
                serverToEdit.QueryPort = Int32.Parse(addServerForm.MinequeryPortTextBox.Text);
                RefreshServer(serverToEdit);
            }

        }

        private void aboutMSQTToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void ServerStatusChanged(object sender, EventArgs e) {

            // we have to use this.Invoke to make sure this code runs in the control's thread context
            // because the status can be changed on a different thread
            // if we're already on that thread, this is just like using an ordinary anonymous method
            this.Invoke(
                (MethodInvoker)delegate {
                    if ((BukkitServer)sender != ServersListBox.SelectedItem) return;
                    UpdateServerDetailLabels(); 
                }
            );

        }

    }

}
