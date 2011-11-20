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

    }

}
