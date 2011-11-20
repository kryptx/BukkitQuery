namespace BukkitQuery {
    partial class AddServerForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.ServerNameLabel = new System.Windows.Forms.Label();
            this.ServerNameTextBox = new System.Windows.Forms.TextBox();
            this.IPAddressTextBox = new System.Windows.Forms.TextBox();
            this.MinequeryPortTextBox = new System.Windows.Forms.TextBox();
            this.HostNameLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.AddServerButton = new System.Windows.Forms.Button();
            this.CancelAddServerButton = new System.Windows.Forms.Button();
            this.AddServerErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.AddServerErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ServerNameLabel
            // 
            this.ServerNameLabel.AutoSize = true;
            this.ServerNameLabel.Location = new System.Drawing.Point(61, 14);
            this.ServerNameLabel.Name = "ServerNameLabel";
            this.ServerNameLabel.Size = new System.Drawing.Size(72, 13);
            this.ServerNameLabel.TabIndex = 0;
            this.ServerNameLabel.Text = "Server Name:";
            // 
            // ServerNameTextBox
            // 
            this.ServerNameTextBox.Location = new System.Drawing.Point(139, 11);
            this.ServerNameTextBox.Name = "ServerNameTextBox";
            this.ServerNameTextBox.Size = new System.Drawing.Size(151, 20);
            this.ServerNameTextBox.TabIndex = 1;
            this.ServerNameTextBox.TextChanged += new System.EventHandler(this.ValidateInputs);
            this.ServerNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ServerNameTextBox_Validating);
            // 
            // IPAddressTextBox
            // 
            this.IPAddressTextBox.Location = new System.Drawing.Point(139, 37);
            this.IPAddressTextBox.Name = "IPAddressTextBox";
            this.IPAddressTextBox.Size = new System.Drawing.Size(151, 20);
            this.IPAddressTextBox.TabIndex = 2;
            this.IPAddressTextBox.TextChanged += new System.EventHandler(this.ValidateInputs);
            this.IPAddressTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.IPAddressTextBox_Validating);
            // 
            // MinequeryPortTextBox
            // 
            this.MinequeryPortTextBox.Location = new System.Drawing.Point(139, 63);
            this.MinequeryPortTextBox.Name = "MinequeryPortTextBox";
            this.MinequeryPortTextBox.Size = new System.Drawing.Size(82, 20);
            this.MinequeryPortTextBox.TabIndex = 3;
            this.MinequeryPortTextBox.Text = "25566";
            this.MinequeryPortTextBox.TextChanged += new System.EventHandler(this.ValidateInputs);
            this.MinequeryPortTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.MinequeryPortTextBox_Validating);
            // 
            // HostNameLabel
            // 
            this.HostNameLabel.AutoSize = true;
            this.HostNameLabel.Location = new System.Drawing.Point(35, 40);
            this.HostNameLabel.Name = "HostNameLabel";
            this.HostNameLabel.Size = new System.Drawing.Size(98, 13);
            this.HostNameLabel.TabIndex = 4;
            this.HostNameLabel.Text = "Host or IP Address:";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(12, 66);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(121, 13);
            this.PortLabel.TabIndex = 5;
            this.PortLabel.Text = "Minequery Port Number:";
            // 
            // AddServerButton
            // 
            this.AddServerButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddServerButton.Enabled = false;
            this.AddServerButton.Location = new System.Drawing.Point(139, 96);
            this.AddServerButton.Name = "AddServerButton";
            this.AddServerButton.Size = new System.Drawing.Size(127, 23);
            this.AddServerButton.TabIndex = 6;
            this.AddServerButton.Text = "Add Server";
            this.AddServerButton.UseVisualStyleBackColor = true;
            this.AddServerButton.Click += new System.EventHandler(this.AddServerButton_Click);
            // 
            // CancelAddServerButton
            // 
            this.CancelAddServerButton.CausesValidation = false;
            this.CancelAddServerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelAddServerButton.Location = new System.Drawing.Point(58, 96);
            this.CancelAddServerButton.Name = "CancelAddServerButton";
            this.CancelAddServerButton.Size = new System.Drawing.Size(75, 23);
            this.CancelAddServerButton.TabIndex = 7;
            this.CancelAddServerButton.Text = "Cancel";
            this.CancelAddServerButton.UseVisualStyleBackColor = true;
            this.CancelAddServerButton.Click += new System.EventHandler(this.CancelAddServerButton_Click);
            // 
            // AddServerErrorProvider
            // 
            this.AddServerErrorProvider.ContainerControl = this;
            // 
            // AddServerForm
            // 
            this.AcceptButton = this.AddServerButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelAddServerButton;
            this.ClientSize = new System.Drawing.Size(317, 132);
            this.Controls.Add(this.CancelAddServerButton);
            this.Controls.Add(this.AddServerButton);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.HostNameLabel);
            this.Controls.Add(this.MinequeryPortTextBox);
            this.Controls.Add(this.IPAddressTextBox);
            this.Controls.Add(this.ServerNameTextBox);
            this.Controls.Add(this.ServerNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddServerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Add Server";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.AddServerErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ServerNameLabel;
        private System.Windows.Forms.Label HostNameLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Button AddServerButton;
        private System.Windows.Forms.Button CancelAddServerButton;
        internal System.Windows.Forms.TextBox ServerNameTextBox;
        internal System.Windows.Forms.TextBox IPAddressTextBox;
        internal System.Windows.Forms.TextBox MinequeryPortTextBox;
        private System.Windows.Forms.ErrorProvider AddServerErrorProvider;
    }
}