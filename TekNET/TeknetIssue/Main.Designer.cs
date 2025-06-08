namespace TeknetIssue
{
	partial class Main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NewAlertBUT = new Button();
            ConfigRefreshBut = new Button();
            SettingsBUT = new Button();
            AboutBUT = new Button();
            ServerStatusList = new ListBox();
            ServerStatusLBL = new Label();
            ConfigLBL = new Label();
            ConfigList = new ListBox();
            SuspendLayout();
            // 
            // NewAlertBUT
            // 
            NewAlertBUT.Location = new Point(12, 12);
            NewAlertBUT.Name = "NewAlertBUT";
            NewAlertBUT.Size = new Size(75, 23);
            NewAlertBUT.TabIndex = 0;
            NewAlertBUT.Text = "New Alert";
            NewAlertBUT.UseVisualStyleBackColor = true;
            // 
            // ConfigRefreshBut
            // 
            ConfigRefreshBut.Location = new Point(93, 12);
            ConfigRefreshBut.Name = "ConfigRefreshBut";
            ConfigRefreshBut.Size = new Size(94, 23);
            ConfigRefreshBut.TabIndex = 1;
            ConfigRefreshBut.Text = "Config Refresh";
            ConfigRefreshBut.UseVisualStyleBackColor = true;
            // 
            // SettingsBUT
            // 
            SettingsBUT.Location = new Point(193, 12);
            SettingsBUT.Name = "SettingsBUT";
            SettingsBUT.Size = new Size(75, 23);
            SettingsBUT.TabIndex = 2;
            SettingsBUT.Text = "Settings";
            SettingsBUT.UseVisualStyleBackColor = true;
            // 
            // AboutBUT
            // 
            AboutBUT.Location = new Point(274, 12);
            AboutBUT.Name = "AboutBUT";
            AboutBUT.Size = new Size(75, 23);
            AboutBUT.TabIndex = 3;
            AboutBUT.Text = "About";
            AboutBUT.UseVisualStyleBackColor = true;
            // 
            // ServerStatusList
            // 
            ServerStatusList.FormattingEnabled = true;
            ServerStatusList.ItemHeight = 15;
            ServerStatusList.Items.AddRange(new object[] { "Server-Status" });
            ServerStatusList.Location = new Point(12, 86);
            ServerStatusList.Name = "ServerStatusList";
            ServerStatusList.Size = new Size(120, 94);
            ServerStatusList.TabIndex = 4;
            ServerStatusList.SelectedIndexChanged += ServerStatusList_SelectedIndexChanged;
            // 
            // ServerStatusLBL
            // 
            ServerStatusLBL.AutoSize = true;
            ServerStatusLBL.Location = new Point(29, 55);
            ServerStatusLBL.Name = "ServerStatusLBL";
            ServerStatusLBL.Size = new Size(74, 15);
            ServerStatusLBL.TabIndex = 5;
            ServerStatusLBL.Text = "Server Status";
            // 
            // ConfigLBL
            // 
            ConfigLBL.AutoSize = true;
            ConfigLBL.Location = new Point(264, 55);
            ConfigLBL.Name = "ConfigLBL";
            ConfigLBL.Size = new Size(43, 15);
            ConfigLBL.TabIndex = 6;
            ConfigLBL.Text = "Config";
            // 
            // ConfigList
            // 
            ConfigList.FormattingEnabled = true;
            ConfigList.ItemHeight = 15;
            ConfigList.Items.AddRange(new object[] { "CurrentConfig" });
            ConfigList.Location = new Point(229, 86);
            ConfigList.Name = "ConfigList";
            ConfigList.Size = new Size(120, 94);
            ConfigList.TabIndex = 7;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(367, 289);
            Controls.Add(ConfigList);
            Controls.Add(ConfigLBL);
            Controls.Add(ServerStatusLBL);
            Controls.Add(ServerStatusList);
            Controls.Add(AboutBUT);
            Controls.Add(SettingsBUT);
            Controls.Add(ConfigRefreshBut);
            Controls.Add(NewAlertBUT);
            Name = "Main";
            Text = "Main";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button NewAlertBUT;
        private Button ConfigRefreshBut;
        private Button SettingsBUT;
        private Button AboutBUT;
        private ListBox ServerStatusList;
        private Label ServerStatusLBL;
        private Label ConfigLBL;
        private ListBox ConfigList;
    }
}