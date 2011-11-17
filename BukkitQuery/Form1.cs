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

namespace BukkitQuery {

    public partial class MainWindow : Form {

        public MainWindow() {
            InitializeComponent();
            LoadServerList();
        }

        void ServersListBox_DrawItem(object sender, DrawItemEventArgs e) {

            if (e.Index >= 0) {
                
                Brush myBrush;
                e.DrawBackground();
                MinecraftServer thisServer = (MinecraftServer)ServersListBox.Items[e.Index];
                if (thisServer == (MinecraftServer)ServersListBox.SelectedItem) {
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), e.Bounds);
                }
                
                switch (thisServer.Status) {

                    case MinecraftServer.ServerStatus.Online:
                        myBrush = Brushes.DarkGreen;
                        break;

                    case MinecraftServer.ServerStatus.Unknown:
                        myBrush = Brushes.DarkBlue;
                        break;

                    case MinecraftServer.ServerStatus.Full:
                        myBrush = Brushes.DarkOrange;
                        break;

                    case MinecraftServer.ServerStatus.Unreachable:
                    default:
                        myBrush = Brushes.DarkRed;
                        break;
                }

                e.Graphics.DrawString(thisServer.ServerName,
                    e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

                if (thisServer.Status == MinecraftServer.ServerStatus.Full ||
                    thisServer.Status == MinecraftServer.ServerStatus.Online) {

                    string playersString = String.Format("{0} / {1}",
                                                        thisServer.PlayerCount.ToString(),
                                                        thisServer.MaxPlayers.ToString());

                    int playersWidth = (int)System.Math.Ceiling(e.Graphics.MeasureString(playersString, e.Font).Width);
                    int playersX = (int)(e.Bounds.Right - playersWidth);
                    Rectangle playersRect = new Rectangle(playersX, e.Bounds.Y, playersWidth, e.Bounds.Height);

                    e.Graphics.DrawString(playersString, e.Font, myBrush, playersRect, StringFormat.GenericDefault);
                }
            }

        }
        

        public void AddServer(string serverName, string serverAddress, int queryPort) {

            MinecraftServer newServer = new MinecraftServer(serverName, serverAddress, queryPort);
            ServersListBox.Items.Add(newServer);
            SaveServerList();
            RefreshServer(newServer);

        }

        private void RefreshServer(MinecraftServer server) {

            server.Status = MinecraftServer.ServerStatus.Unknown;
            UpdateLabels();

            BackgroundWorker bgw = new BackgroundWorker();
            server.AttachedWorker = bgw;

            // use a delegate method (with group syntax) for DoWork
            bgw.DoWork += UpdateServer_DoWork;

            // use an anonymous method for RunWorkerCompleted, so we can use the server variable
            /* bgw.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e) {
                ServersListBox.Refresh();
                if(server == ServersListBox.SelectedItem)
                    UpdateLabels();
            }; */

            bgw.RunWorkerCompleted += (sender, e) => {
                ServersListBox.Refresh();
                if (server == ServersListBox.SelectedItem)
                    UpdateLabels();
            };

            bgw.RunWorkerAsync(server);

        }


        private void AddServerTool_Click(object sender, EventArgs e) {
            AddServerForm addServerForm = new AddServerForm();
            addServerForm.ShowDialog(this);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void UpdateServer_DoWork(object sender, DoWorkEventArgs e) {

            MinecraftServer server = e.Argument as MinecraftServer;
            byte[] data = Encoding.ASCII.GetBytes("QUERY\n");
            byte[] receiveBuffer = new byte[256];
            string responseString = "";

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
                    server.Status = MinecraftServer.ServerStatus.Unreachable;
            }

            if ((server.AttachedWorker == sender as BackgroundWorker) && (server.Status == MinecraftServer.ServerStatus.Unknown)) {

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
                    server.Status = MinecraftServer.ServerStatus.Full;
                } else server.Status = MinecraftServer.ServerStatus.Online;

            }

        }

        private void ServersListBox_SelectedIndexChanged(object sender, EventArgs e) {
            ServersListBox.Refresh();
            UpdateLabels();
        }

        private void UpdateLabels() {

            MinecraftServer selectedServer = ServersListBox.SelectedItem as MinecraftServer;

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

                    case MinecraftServer.ServerStatus.Full:
                    case MinecraftServer.ServerStatus.Online:
                        PortValueLabel.Text = selectedServer.ServerPort.ToString();
                        MaxPlayersValueLabel.Text = selectedServer.MaxPlayers.ToString();
                        OpenSlotsValueLabel.Text = (selectedServer.MaxPlayers - selectedServer.PlayerCount).ToString();
                        PlayersOnlineGroupBox.Visible = true;
                        PlayersOnlineListBox.Items.Clear();
                        PlayersOnlineListBox.Items.AddRange(selectedServer.PlayerList.ToArray());
                        break;

                    case MinecraftServer.ServerStatus.Unknown:
                        PortValueLabel.Text = "Waiting for result...";
                        OpenSlotsValueLabel.Text = MaxPlayersValueLabel.Text = "Waiting for result...";
                        PlayersOnlineGroupBox.Visible = false;
                        break;

                    case MinecraftServer.ServerStatus.Unreachable:
                        PortValueLabel.Text = "Unknown";
                        OpenSlotsValueLabel.Text = MaxPlayersValueLabel.Text = "N/A";
                        PlayersOnlineGroupBox.Visible = false;
                        break;

                }
                
            }

        }

        private void refreshAllToolStripMenuItem_Click(object sender, EventArgs e) {
            foreach (MinecraftServer server in ServersListBox.Items) {
                RefreshServer(server);
            }
        }

        private void RefreshToolStripButton_Click(object sender, EventArgs e) {
            RefreshServer(ServersListBox.SelectedItem as MinecraftServer);
        }

        private void DeleteToolStripButton_Click(object sender, EventArgs e) {
            ServersListBox.Items.Remove(ServersListBox.SelectedItem);
            SaveServerList();
        }

        private void SaveServerList() {
            using (XmlTextWriter writer = new XmlTextWriter("servers.xml", Encoding.UTF8)) {
                Type[] serializedTypes = { typeof(MinecraftServer) };
                XmlSerializer xml = new XmlSerializer(typeof(List<MinecraftServer>), serializedTypes);
                List<MinecraftServer> servers = new List<MinecraftServer>();
                foreach (MinecraftServer thisServer in ServersListBox.Items) {
                    servers.Add(thisServer);
                }
                xml.Serialize(writer, servers);
            }
        }

        private void LoadServerList() {

            try {
                using (XmlTextReader reader = new XmlTextReader("servers.xml")) {
                    Type[] myTypes = { typeof(MinecraftServer) };
                    XmlSerializer xml = new XmlSerializer(typeof(List<MinecraftServer>), myTypes);
                    List<MinecraftServer> servers = (List<MinecraftServer>)xml.Deserialize(reader);
                    ServersListBox.Items.Clear();
                    foreach (MinecraftServer thisServer in servers) {
                        ServersListBox.Items.Add(thisServer);
                        RefreshServer(thisServer);
                    }
                }
                
            } catch (InvalidOperationException e) {
                if (e.InnerException is FileNotFoundException) {
                    // do nothing; they are probably running for the first time
                } else throw e;
            }

        }

        private void EditToolStripButton_Click(object sender, EventArgs e) {
            MinecraftServer serverToEdit = ServersListBox.SelectedItem as MinecraftServer;
            AddServerForm addServerForm = new AddServerForm(serverToEdit.ServerName, serverToEdit.ServerAddress, serverToEdit.QueryPort);
            addServerForm.ShowDialog(this);
        }

        public void UpdateSelected(string serverName, string serverAddress, int queryPort) {
            MinecraftServer serverToEdit = ServersListBox.SelectedItem as MinecraftServer;
            serverToEdit.ServerName = serverName;
            serverToEdit.ServerAddress = serverAddress;
            serverToEdit.QueryPort = queryPort;
            RefreshServer(serverToEdit);
        }

        private void aboutMSQTToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

    }

}
