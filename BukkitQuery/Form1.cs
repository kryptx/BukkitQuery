using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

using BukkitQuery.Components;

namespace BukkitQuery {

    public partial class MainWindow : Form {

        public MainWindow() {
            InitializeComponent();
            PopulateServersListBox();
            AttachEventListeners();  // is there a race condition here?
        }

        private void PopulateServersListBox() {

            List<BukkitServer> servers = BukkitServerDataReader.ReadServers();

            ServersListBox.Items.Clear();
            foreach (BukkitServer thisServer in servers) {
                ServersListBox.Items.Add(thisServer);
                thisServer.Refresh();
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
                newServer.Refresh();

            }

        }


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }



        private void ServersListBox_SelectedIndexChanged(object sender, EventArgs e) {
            ServersListBox.Refresh();
            UpdateUIElements();
        }


        private void UpdateUIElements() {

            BukkitServer selectedServer = ServersListBox.SelectedItem as BukkitServer;

            UpdateDetailBoxesVisibility(selectedServer);
            UpdateToolStripButtonStates(selectedServer);

            if (selectedServer != null) {
                UpdateServerDetailLabels(selectedServer);
                UpdatePlayersOnlineList(selectedServer);
            }
            
        }


        private void UpdatePlayersOnlineList(BukkitServer selectedServer) {
            PlayersOnlineListBox.Items.Clear();
            PlayersOnlineListBox.Items.AddRange(selectedServer.PlayerList.ToArray());
        }


        private void UpdateServerDetailLabels(BukkitServer selectedServer) {

            HostValueLabel.Text = selectedServer.ServerAddress;
            StatusValueLabel.Text = selectedServer.Status.ToString();

            if (selectedServer.IsOnline()) {

                PortValueLabel.Text = selectedServer.ServerPort.ToString();
                MaxPlayersValueLabel.Text = selectedServer.MaxPlayers.ToString();
                OpenSlotsValueLabel.Text = (selectedServer.MaxPlayers - selectedServer.PlayerCount).ToString();

            } else if (selectedServer.Status == BukkitServer.ServerStatus.Unknown) {

                PortValueLabel.Text = "Waiting for result...";
                OpenSlotsValueLabel.Text = MaxPlayersValueLabel.Text = "Waiting for result...";

            } else if (selectedServer.Status == BukkitServer.ServerStatus.Unreachable) {

                PortValueLabel.Text = "Unknown";
                OpenSlotsValueLabel.Text = MaxPlayersValueLabel.Text = "N/A";

            }

        }


        private void UpdateToolStripButtonStates(BukkitServer selectedServer) {

            if (selectedServer == null) {
                DisableToolStripButtons();
            } else {
                EnableToolStripButtons();
            }

        }


        private void UpdateDetailBoxesVisibility(BukkitServer selectedServer) {

            if (selectedServer == null) {
                HideServerDetailBoxes();
                return;
            }

            ShowServerInfoBox();

            if (selectedServer.IsOnline()) {
                ShowPlayersOnlineBox();
            } else {
                HidePlayersOnlineBox();
            }

        }



        private void ShowPlayersOnlineBox() {
            PlayersOnlineGroupBox.Visible = true;
        }

        private void ShowServerInfoBox() {
            ServerInfoGroupBox.Visible = true;
        }


        private void EnableToolStripButtons() {

            EditToolStripButton.Enabled = true;
            RefreshToolStripButton.Enabled = true;
            DeleteToolStripButton.Enabled = true;
        }

        private void DisableToolStripButtons() {
            EditToolStripButton.Enabled = false;
            RefreshToolStripButton.Enabled = false;
            DeleteToolStripButton.Enabled = false;
        }


        private void HideServerDetailBoxes() {
            HideServerInfoBox();
            HidePlayersOnlineBox();
        }

        private void HidePlayersOnlineBox() {
            PlayersOnlineGroupBox.Visible = false;
        }

        private void HideServerInfoBox() {
            ServerInfoGroupBox.Visible = false;
        }


        private void refreshAllToolStripMenuItem_Click(object sender, EventArgs e) {
            foreach (BukkitServer server in ServersListBox.Items) {
                server.Refresh();
            }
        }


        private void RefreshToolStripButton_Click(object sender, EventArgs e) {
            ((BukkitServer)ServersListBox.SelectedItem).Refresh();
        }


        private void DeleteToolStripButton_Click(object sender, EventArgs e) {
            ServersListBox.Items.Remove(ServersListBox.SelectedItem);
            SaveServerList();
        }


        private void SaveServerList() {
            BukkitServerDataWriter.SaveServers(ServersListBox.Items);
        }
            

        private void EditToolStripButton_Click(object sender, EventArgs e) {

            BukkitServer serverToEdit = ServersListBox.SelectedItem as BukkitServer;
            AddServerForm addServerForm = new AddServerForm(serverToEdit.ServerName, serverToEdit.ServerAddress, serverToEdit.QueryPort);
            DialogResult editResult = addServerForm.ShowDialog(this);

            if (editResult == DialogResult.OK) {
                serverToEdit.ServerName = addServerForm.ServerNameTextBox.Text;
                serverToEdit.ServerAddress = addServerForm.IPAddressTextBox.Text;
                serverToEdit.QueryPort = Int32.Parse(addServerForm.MinequeryPortTextBox.Text);
                serverToEdit.Refresh();
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
                    ServersListBox.Refresh();
                    if ((BukkitServer)sender == ServersListBox.SelectedItem) {
                        UpdateUIElements();
                    }
                }
            );
            
        }

    }

}
