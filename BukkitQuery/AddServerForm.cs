using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BukkitQuery {

    public partial class AddServerForm : Form {

        public AddServerForm() {
            InitializeComponent();
        }

        public AddServerForm(string serverName, string hostName, int port) : this() {
            ServerNameTextBox.Text = serverName;
            IPAddressTextBox.Text = hostName;
            MinequeryPortTextBox.Text = port.ToString();
            AddServerButton.Text = "Update Server";
            Text = "Update Server Details";
        }

        private void ValidateInputs(object sender, EventArgs e) {

            try {
                if (IPAddressTextBox.Text.Trim().Length > 0 &&
                    ServerNameTextBox.Text.Trim().Length > 0 &&
                    Int32.Parse(MinequeryPortTextBox.Text) > 0) {

                    AddServerButton.Enabled = true;
                    return;
                }
            } catch { }

            AddServerButton.Enabled = false;

        }


        private void AddServerButton_Click(object sender, EventArgs e) {
            this.Close();
        }
        
        private void CancelAddServerButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ServerNameTextBox_Validating(object sender, CancelEventArgs e) {
            AddServerErrorProvider.SetError(ServerNameTextBox,
                (ServerNameTextBox.Text.Trim().Length == 0) ? "Please enter a name to describe this server." : null);
        }

        private void IPAddressTextBox_Validating(object sender, CancelEventArgs e) {
            AddServerErrorProvider.SetError(IPAddressTextBox,
                (IPAddressTextBox.Text.Trim().Length == 0) ? "Please enter the server's IP address or host name." : null);
        }

        private void MinequeryPortTextBox_Validating(object sender, CancelEventArgs e) {
            try {
                int port = Int32.Parse(MinequeryPortTextBox.Text);
                if (port > 0) AddServerErrorProvider.SetError(MinequeryPortTextBox, null);
                else AddServerErrorProvider.SetError(MinequeryPortTextBox, "Port must be greater than zero.");
            } catch {
                AddServerErrorProvider.SetError(
                    MinequeryPortTextBox, "Please enter a numeric port number.");
            }

        }

    }

}
