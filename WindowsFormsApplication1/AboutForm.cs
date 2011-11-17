using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BukkitQuery {
    public partial class AboutForm : Form {
        public AboutForm() {
            InitializeComponent();
            VersionLabel.Text = String.Format("version {0}", Application.ProductVersion);
        }

        private void EmailLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("mailto:jason@moltensoft.com");
        }
    }
}
