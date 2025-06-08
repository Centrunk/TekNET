namespace Teknet2025Core
{
	partial class SvrHome
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
            PeerList = new ListBox();
            ManualPollBUT = new Button();
            PeerID = new TextBox();
            ForceLogOff = new Button();
            SiteInfo = new Button();
            EditConfig = new Button();
            ManageUser = new Button();
            ManageFacility = new Button();
            ServerSettings = new Button();
            ManageGroup = new Button();
            AboutBUT = new Button();
            SuspendLayout();
            // 
            // PeerList
            // 
            PeerList.FormattingEnabled = true;
            PeerList.ItemHeight = 15;
            PeerList.Items.AddRange(new object[] { "PeerID/FacilityID-Status-User" });
            PeerList.Location = new Point(12, 12);
            PeerList.Name = "PeerList";
            PeerList.Size = new Size(372, 394);
            PeerList.TabIndex = 0;
            // 
            // ManualPollBUT
            // 
            ManualPollBUT.Location = new Point(409, 41);
            ManualPollBUT.Name = "ManualPollBUT";
            ManualPollBUT.Size = new Size(99, 23);
            ManualPollBUT.TabIndex = 1;
            ManualPollBUT.Text = "Manual Poll";
            ManualPollBUT.UseVisualStyleBackColor = true;
            ManualPollBUT.Click += button1_Click;
            // 
            // PeerID
            // 
            PeerID.Location = new Point(409, 12);
            PeerID.Name = "PeerID";
            PeerID.Size = new Size(100, 23);
            PeerID.TabIndex = 2;
            // 
            // ForceLogOff
            // 
            ForceLogOff.Location = new Point(409, 70);
            ForceLogOff.Name = "ForceLogOff";
            ForceLogOff.Size = new Size(99, 23);
            ForceLogOff.TabIndex = 3;
            ForceLogOff.Text = "Force Log Off";
            ForceLogOff.UseVisualStyleBackColor = true;
            // 
            // SiteInfo
            // 
            SiteInfo.Location = new Point(409, 99);
            SiteInfo.Name = "SiteInfo";
            SiteInfo.Size = new Size(99, 23);
            SiteInfo.TabIndex = 4;
            SiteInfo.Text = "Site Info";
            SiteInfo.UseVisualStyleBackColor = true;
            // 
            // EditConfig
            // 
            EditConfig.Location = new Point(409, 128);
            EditConfig.Name = "EditConfig";
            EditConfig.Size = new Size(99, 23);
            EditConfig.TabIndex = 5;
            EditConfig.Text = "Edit Config";
            EditConfig.UseVisualStyleBackColor = true;
            // 
            // ManageUser
            // 
            ManageUser.Location = new Point(528, 12);
            ManageUser.Name = "ManageUser";
            ManageUser.Size = new Size(102, 23);
            ManageUser.TabIndex = 6;
            ManageUser.Text = "Manage User";
            ManageUser.UseVisualStyleBackColor = true;
            // 
            // ManageFacility
            // 
            ManageFacility.Location = new Point(528, 41);
            ManageFacility.Name = "ManageFacility";
            ManageFacility.Size = new Size(102, 23);
            ManageFacility.TabIndex = 7;
            ManageFacility.Text = "Manage Facility";
            ManageFacility.UseVisualStyleBackColor = true;
            // 
            // ServerSettings
            // 
            ServerSettings.Location = new Point(668, 415);
            ServerSettings.Name = "ServerSettings";
            ServerSettings.Size = new Size(120, 23);
            ServerSettings.TabIndex = 8;
            ServerSettings.Text = "Server Settings";
            ServerSettings.UseVisualStyleBackColor = true;
            // 
            // ManageGroup
            // 
            ManageGroup.Location = new Point(528, 71);
            ManageGroup.Name = "ManageGroup";
            ManageGroup.Size = new Size(102, 23);
            ManageGroup.TabIndex = 9;
            ManageGroup.Text = "Manage group";
            ManageGroup.UseVisualStyleBackColor = true;
            // 
            // AboutBUT
            // 
            AboutBUT.Location = new Point(587, 415);
            AboutBUT.Name = "AboutBUT";
            AboutBUT.Size = new Size(75, 23);
            AboutBUT.TabIndex = 10;
            AboutBUT.Text = "About";
            AboutBUT.UseVisualStyleBackColor = true;
            // 
            // SvrHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AboutBUT);
            Controls.Add(ManageGroup);
            Controls.Add(ServerSettings);
            Controls.Add(ManageFacility);
            Controls.Add(ManageUser);
            Controls.Add(EditConfig);
            Controls.Add(SiteInfo);
            Controls.Add(ForceLogOff);
            Controls.Add(PeerID);
            Controls.Add(ManualPollBUT);
            Controls.Add(PeerList);
            Name = "SvrHome";
            Text = "SvrHome";
            Load += SvrHome_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox PeerList;
        private Button ManualPollBUT;
        private TextBox PeerID;
        private Button ForceLogOff;
        private Button SiteInfo;
        private Button EditConfig;
        private Button ManageUser;
        private Button ManageFacility;
        private Button ServerSettings;
        private Button ManageGroup;
        private Button AboutBUT;
    }
}