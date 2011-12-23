namespace BukkitQuery {
    partial class MainWindow {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.ServersListBox = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddServerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.EditToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMSQTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.OpenSlotsValueLabel = new System.Windows.Forms.Label();
            this.StatusValueLabel = new System.Windows.Forms.Label();
            this.MaxPlayersValueLabel = new System.Windows.Forms.Label();
            this.PortValueLabel = new System.Windows.Forms.Label();
            this.HostValueLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OpenSlotsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.HostLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PlayersOnlineGroupBox = new System.Windows.Forms.GroupBox();
            this.PlayersOnlineListBox = new System.Windows.Forms.ListBox();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.ServerInfoGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.PlayersOnlineGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ServersListBox
            // 
            this.ServersListBox.DisplayMember = "ServerName";
            this.ServersListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServersListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ServersListBox.FormattingEnabled = true;
            this.ServersListBox.Location = new System.Drawing.Point(3, 28);
            this.ServersListBox.Name = "ServersListBox";
            this.tableLayoutPanel1.SetRowSpan(this.ServersListBox, 2);
            this.ServersListBox.Size = new System.Drawing.Size(176, 354);
            this.ServersListBox.TabIndex = 0;
            this.ServersListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ServersListBox_DrawItem);
            this.ServersListBox.SelectedIndexChanged += new System.EventHandler(this.ServersListBox_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 2);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddServerToolStripButton,
            this.toolStripSeparator2,
            this.EditToolStripButton,
            this.RefreshToolStripButton,
            this.DeleteToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(457, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddServerToolStripButton
            // 
            this.AddServerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddServerToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddServerToolStripButton.Image")));
            this.AddServerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddServerToolStripButton.Name = "AddServerToolStripButton";
            this.AddServerToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.AddServerToolStripButton.Text = "Add Server...";
            this.AddServerToolStripButton.Click += new System.EventHandler(this.AddServerTool_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // EditToolStripButton
            // 
            this.EditToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditToolStripButton.Enabled = false;
            this.EditToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EditToolStripButton.Image")));
            this.EditToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditToolStripButton.Name = "EditToolStripButton";
            this.EditToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.EditToolStripButton.Text = "Edit";
            this.EditToolStripButton.Click += new System.EventHandler(this.EditToolStripButton_Click);
            // 
            // RefreshToolStripButton
            // 
            this.RefreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshToolStripButton.Enabled = false;
            this.RefreshToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshToolStripButton.Image")));
            this.RefreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshToolStripButton.Name = "RefreshToolStripButton";
            this.RefreshToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.RefreshToolStripButton.Text = "Refresh";
            this.RefreshToolStripButton.Click += new System.EventHandler(this.RefreshToolStripButton_Click);
            // 
            // DeleteToolStripButton
            // 
            this.DeleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteToolStripButton.Enabled = false;
            this.DeleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteToolStripButton.Image")));
            this.DeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteToolStripButton.Name = "DeleteToolStripButton";
            this.DeleteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.DeleteToolStripButton.Text = "Delete";
            this.DeleteToolStripButton.Click += new System.EventHandler(this.DeleteToolStripButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(457, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddServerToolStripMenuItem,
            this.refreshAllToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.fileToolStripMenuItem.Text = "Servers";
            // 
            // AddServerToolStripMenuItem
            // 
            this.AddServerToolStripMenuItem.Name = "AddServerToolStripMenuItem";
            this.AddServerToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.AddServerToolStripMenuItem.Text = "Add Server...";
            this.AddServerToolStripMenuItem.Click += new System.EventHandler(this.AddServerTool_Click);
            // 
            // refreshAllToolStripMenuItem
            // 
            this.refreshAllToolStripMenuItem.Name = "refreshAllToolStripMenuItem";
            this.refreshAllToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshAllToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.refreshAllToolStripMenuItem.Text = "Refresh All";
            this.refreshAllToolStripMenuItem.Click += new System.EventHandler(this.refreshAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.ExitToolStripMenuItem.Text = "Exit MSQT";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMSQTToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutMSQTToolStripMenuItem
            // 
            this.aboutMSQTToolStripMenuItem.Name = "aboutMSQTToolStripMenuItem";
            this.aboutMSQTToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.aboutMSQTToolStripMenuItem.Text = "About BukkitQuery...";
            this.aboutMSQTToolStripMenuItem.Click += new System.EventHandler(this.aboutMSQTToolStripMenuItem_Click);
            // 
            // ServerInfoGroupBox
            // 
            this.ServerInfoGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.ServerInfoGroupBox.Controls.Add(this.OpenSlotsValueLabel);
            this.ServerInfoGroupBox.Controls.Add(this.StatusValueLabel);
            this.ServerInfoGroupBox.Controls.Add(this.MaxPlayersValueLabel);
            this.ServerInfoGroupBox.Controls.Add(this.PortValueLabel);
            this.ServerInfoGroupBox.Controls.Add(this.HostValueLabel);
            this.ServerInfoGroupBox.Controls.Add(this.label2);
            this.ServerInfoGroupBox.Controls.Add(this.OpenSlotsLabel);
            this.ServerInfoGroupBox.Controls.Add(this.label1);
            this.ServerInfoGroupBox.Controls.Add(this.PortLabel);
            this.ServerInfoGroupBox.Controls.Add(this.HostLabel);
            this.ServerInfoGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerInfoGroupBox.Location = new System.Drawing.Point(185, 28);
            this.ServerInfoGroupBox.Name = "ServerInfoGroupBox";
            this.ServerInfoGroupBox.Size = new System.Drawing.Size(269, 174);
            this.ServerInfoGroupBox.TabIndex = 4;
            this.ServerInfoGroupBox.TabStop = false;
            this.ServerInfoGroupBox.Text = "Server Information";
            this.ServerInfoGroupBox.Visible = false;
            // 
            // OpenSlotsValueLabel
            // 
            this.OpenSlotsValueLabel.AutoSize = true;
            this.OpenSlotsValueLabel.Location = new System.Drawing.Point(120, 115);
            this.OpenSlotsValueLabel.Name = "OpenSlotsValueLabel";
            this.OpenSlotsValueLabel.Size = new System.Drawing.Size(35, 13);
            this.OpenSlotsValueLabel.TabIndex = 9;
            this.OpenSlotsValueLabel.Text = "label7";
            // 
            // StatusValueLabel
            // 
            this.StatusValueLabel.AutoSize = true;
            this.StatusValueLabel.Location = new System.Drawing.Point(120, 71);
            this.StatusValueLabel.Name = "StatusValueLabel";
            this.StatusValueLabel.Size = new System.Drawing.Size(35, 13);
            this.StatusValueLabel.TabIndex = 8;
            this.StatusValueLabel.Text = "label6";
            // 
            // MaxPlayersValueLabel
            // 
            this.MaxPlayersValueLabel.AutoSize = true;
            this.MaxPlayersValueLabel.Location = new System.Drawing.Point(120, 93);
            this.MaxPlayersValueLabel.Name = "MaxPlayersValueLabel";
            this.MaxPlayersValueLabel.Size = new System.Drawing.Size(35, 13);
            this.MaxPlayersValueLabel.TabIndex = 7;
            this.MaxPlayersValueLabel.Text = "label5";
            // 
            // PortValueLabel
            // 
            this.PortValueLabel.AutoSize = true;
            this.PortValueLabel.Location = new System.Drawing.Point(120, 49);
            this.PortValueLabel.Name = "PortValueLabel";
            this.PortValueLabel.Size = new System.Drawing.Size(35, 13);
            this.PortValueLabel.TabIndex = 6;
            this.PortValueLabel.Text = "label4";
            // 
            // HostValueLabel
            // 
            this.HostValueLabel.AutoSize = true;
            this.HostValueLabel.Location = new System.Drawing.Point(120, 27);
            this.HostValueLabel.Name = "HostValueLabel";
            this.HostValueLabel.Size = new System.Drawing.Size(35, 13);
            this.HostValueLabel.TabIndex = 5;
            this.HostValueLabel.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status:";
            // 
            // OpenSlotsLabel
            // 
            this.OpenSlotsLabel.AutoSize = true;
            this.OpenSlotsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenSlotsLabel.Location = new System.Drawing.Point(41, 115);
            this.OpenSlotsLabel.Name = "OpenSlotsLabel";
            this.OpenSlotsLabel.Size = new System.Drawing.Size(73, 13);
            this.OpenSlotsLabel.TabIndex = 4;
            this.OpenSlotsLabel.Text = "Open Slots:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Max Players:";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortLabel.Location = new System.Drawing.Point(80, 49);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(34, 13);
            this.PortLabel.TabIndex = 1;
            this.PortLabel.Text = "Port:";
            // 
            // HostLabel
            // 
            this.HostLabel.AutoSize = true;
            this.HostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HostLabel.Location = new System.Drawing.Point(77, 27);
            this.HostLabel.Name = "HostLabel";
            this.HostLabel.Size = new System.Drawing.Size(37, 13);
            this.HostLabel.TabIndex = 0;
            this.HostLabel.Text = "Host:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ServersListBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.PlayersOnlineGroupBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ServerInfoGroupBox, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(457, 385);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // PlayersOnlineGroupBox
            // 
            this.PlayersOnlineGroupBox.Controls.Add(this.PlayersOnlineListBox);
            this.PlayersOnlineGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayersOnlineGroupBox.Location = new System.Drawing.Point(185, 208);
            this.PlayersOnlineGroupBox.Name = "PlayersOnlineGroupBox";
            this.PlayersOnlineGroupBox.Size = new System.Drawing.Size(269, 174);
            this.PlayersOnlineGroupBox.TabIndex = 3;
            this.PlayersOnlineGroupBox.TabStop = false;
            this.PlayersOnlineGroupBox.Text = "Players Online";
            this.PlayersOnlineGroupBox.Visible = false;
            // 
            // PlayersOnlineListBox
            // 
            this.PlayersOnlineListBox.BackColor = System.Drawing.SystemColors.Control;
            this.PlayersOnlineListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PlayersOnlineListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayersOnlineListBox.FormattingEnabled = true;
            this.PlayersOnlineListBox.Location = new System.Drawing.Point(3, 16);
            this.PlayersOnlineListBox.Name = "PlayersOnlineListBox";
            this.PlayersOnlineListBox.Size = new System.Drawing.Size(263, 155);
            this.PlayersOnlineListBox.Sorted = true;
            this.PlayersOnlineListBox.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 409);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(375, 375);
            this.Name = "MainWindow";
            this.Text = "BukkitQuery";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ServerInfoGroupBox.ResumeLayout(false);
            this.ServerInfoGroupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.PlayersOnlineGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ServersListBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddServerToolStripButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMSQTToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton RefreshToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton DeleteToolStripButton;
        private System.Windows.Forms.GroupBox ServerInfoGroupBox;
        private System.Windows.Forms.Label OpenSlotsLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label HostLabel;
        private System.Windows.Forms.ToolStripMenuItem refreshAllToolStripMenuItem;
        private System.Windows.Forms.Label OpenSlotsValueLabel;
        private System.Windows.Forms.Label StatusValueLabel;
        private System.Windows.Forms.Label MaxPlayersValueLabel;
        private System.Windows.Forms.Label PortValueLabel;
        private System.Windows.Forms.Label HostValueLabel;
        private System.Windows.Forms.ToolStripButton EditToolStripButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox PlayersOnlineGroupBox;
        private System.Windows.Forms.ListBox PlayersOnlineListBox;

    }
}

