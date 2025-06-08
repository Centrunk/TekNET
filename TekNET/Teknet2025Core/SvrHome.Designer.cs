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
            ForceLogOffBUT = new Button();
            SiteInfoBUT = new Button();
            EditConfigBUT = new Button();
            ManageUserBUT = new Button();
            ManageFacilityBUT = new Button();
            ServerSettingsBUT = new Button();
            ManageGroupBUT = new Button();
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
            // ForceLogOffBUT
            // 
            ForceLogOffBUT.Location = new Point(409, 70);
            ForceLogOffBUT.Name = "ForceLogOffBUT";
            ForceLogOffBUT.Size = new Size(99, 23);
            ForceLogOffBUT.TabIndex = 3;
            ForceLogOffBUT.Text = "Force Log Off";
            ForceLogOffBUT.UseVisualStyleBackColor = true;
            // 
            // SiteInfoBUT
            // 
            SiteInfoBUT.Location = new Point(409, 99);
            SiteInfoBUT.Name = "SiteInfoBUT";
            SiteInfoBUT.Size = new Size(99, 23);
            SiteInfoBUT.TabIndex = 4;
            SiteInfoBUT.Text = "Site Info";
            SiteInfoBUT.UseVisualStyleBackColor = true;
            // 
            // EditConfigBUT
            // 
            EditConfigBUT.Location = new Point(409, 128);
            EditConfigBUT.Name = "EditConfigBUT";
            EditConfigBUT.Size = new Size(99, 23);
            EditConfigBUT.TabIndex = 5;
            EditConfigBUT.Text = "Edit Config";
            EditConfigBUT.UseVisualStyleBackColor = true;
            // 
            // ManageUserBUT
            // 
            ManageUserBUT.Location = new Point(528, 12);
            ManageUserBUT.Name = "ManageUserBUT";
            ManageUserBUT.Size = new Size(102, 23);
            ManageUserBUT.TabIndex = 6;
            ManageUserBUT.Text = "Manage User";
            ManageUserBUT.UseVisualStyleBackColor = true;
            // 
            // ManageFacilityBUT
            // 
            ManageFacilityBUT.Location = new Point(528, 41);
            ManageFacilityBUT.Name = "ManageFacilityBUT";
            ManageFacilityBUT.Size = new Size(102, 23);
            ManageFacilityBUT.TabIndex = 7;
            ManageFacilityBUT.Text = "Manage Facility";
            ManageFacilityBUT.UseVisualStyleBackColor = true;
            // 
            // ServerSettingsBUT
            // 
            ServerSettingsBUT.Location = new Point(668, 415);
            ServerSettingsBUT.Name = "ServerSettingsBUT";
            ServerSettingsBUT.Size = new Size(120, 23);
            ServerSettingsBUT.TabIndex = 8;
            ServerSettingsBUT.Text = "Server Settings";
            ServerSettingsBUT.UseVisualStyleBackColor = true;
            // 
            // ManageGroupBUT
            // 
            ManageGroupBUT.Location = new Point(528, 71);
            ManageGroupBUT.Name = "ManageGroupBUT";
            ManageGroupBUT.Size = new Size(102, 23);
            ManageGroupBUT.TabIndex = 9;
            ManageGroupBUT.Text = "Manage group";
            ManageGroupBUT.UseVisualStyleBackColor = true;
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
            Controls.Add(ManageGroupBUT);
            Controls.Add(ServerSettingsBUT);
            Controls.Add(ManageFacilityBUT);
            Controls.Add(ManageUserBUT);
            Controls.Add(EditConfigBUT);
            Controls.Add(SiteInfoBUT);
            Controls.Add(ForceLogOffBUT);
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
        private Button ForceLogOffBUT;
        private Button SiteInfoBUT;
        private Button EditConfigBUT;
        private Button ManageUserBUT;
        private Button ManageFacilityBUT;
        private Button ServerSettingsBUT;
        private Button ManageGroupBUT;
        private Button AboutBUT;
    }
}