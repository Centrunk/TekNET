namespace Teknet2025Core
{
	partial class UserMgmt
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
            UserList = new ListBox();
            AddUserBUT = new Button();
            EditUserBUT = new Button();
            DeleteUserBUT = new Button();
            SaveUserBUT = new Button();
            CloseUserBUT = new Button();
            SuspendLayout();
            // 
            // UserList
            // 
            UserList.FormattingEnabled = true;
            UserList.ItemHeight = 15;
            UserList.Items.AddRange(new object[] { "UserID-Status-Version-Type" });
            UserList.Location = new Point(12, 12);
            UserList.Name = "UserList";
            UserList.Size = new Size(474, 634);
            UserList.TabIndex = 0;
            // 
            // AddUserBUT
            // 
            AddUserBUT.Location = new Point(574, 12);
            AddUserBUT.Name = "AddUserBUT";
            AddUserBUT.Size = new Size(95, 23);
            AddUserBUT.TabIndex = 1;
            AddUserBUT.Text = "Add User";
            AddUserBUT.UseVisualStyleBackColor = true;
            // 
            // EditUserBUT
            // 
            EditUserBUT.Location = new Point(574, 41);
            EditUserBUT.Name = "EditUserBUT";
            EditUserBUT.Size = new Size(95, 23);
            EditUserBUT.TabIndex = 2;
            EditUserBUT.Text = "Edit User";
            EditUserBUT.UseVisualStyleBackColor = true;
            // 
            // DeleteUserBUT
            // 
            DeleteUserBUT.Location = new Point(574, 70);
            DeleteUserBUT.Name = "DeleteUserBUT";
            DeleteUserBUT.Size = new Size(95, 23);
            DeleteUserBUT.TabIndex = 3;
            DeleteUserBUT.Text = "Delete User";
            DeleteUserBUT.UseVisualStyleBackColor = true;
            // 
            // SaveUserBUT
            // 
            SaveUserBUT.Location = new Point(797, 597);
            SaveUserBUT.Name = "SaveUserBUT";
            SaveUserBUT.Size = new Size(75, 23);
            SaveUserBUT.TabIndex = 4;
            SaveUserBUT.Text = "Save";
            SaveUserBUT.UseVisualStyleBackColor = true;
            // 
            // CloseUserBUT
            // 
            CloseUserBUT.Location = new Point(797, 626);
            CloseUserBUT.Name = "CloseUserBUT";
            CloseUserBUT.Size = new Size(75, 23);
            CloseUserBUT.TabIndex = 5;
            CloseUserBUT.Text = "Close";
            CloseUserBUT.UseVisualStyleBackColor = true;
            // 
            // UserMgmt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 661);
            Controls.Add(CloseUserBUT);
            Controls.Add(SaveUserBUT);
            Controls.Add(DeleteUserBUT);
            Controls.Add(EditUserBUT);
            Controls.Add(AddUserBUT);
            Controls.Add(UserList);
            Name = "UserMgmt";
            Text = "UserMgmt";
            Load += UserMgmt_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox UserList;
        private Button AddUserBUT;
        private Button EditUserBUT;
        private Button DeleteUserBUT;
        private Button SaveUserBUT;
        private Button CloseUserBUT;
    }
}