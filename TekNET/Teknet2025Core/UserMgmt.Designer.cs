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
            AddUser = new Button();
            EditUser = new Button();
            DeleteUser = new Button();
            SaveUsers = new Button();
            Close = new Button();
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
            // AddUser
            // 
            AddUser.Location = new Point(574, 12);
            AddUser.Name = "AddUser";
            AddUser.Size = new Size(95, 23);
            AddUser.TabIndex = 1;
            AddUser.Text = "Add User";
            AddUser.UseVisualStyleBackColor = true;
            // 
            // EditUser
            // 
            EditUser.Location = new Point(574, 41);
            EditUser.Name = "EditUser";
            EditUser.Size = new Size(95, 23);
            EditUser.TabIndex = 2;
            EditUser.Text = "Edit User";
            EditUser.UseVisualStyleBackColor = true;
            // 
            // DeleteUser
            // 
            DeleteUser.Location = new Point(574, 70);
            DeleteUser.Name = "DeleteUser";
            DeleteUser.Size = new Size(95, 23);
            DeleteUser.TabIndex = 3;
            DeleteUser.Text = "Delete User";
            DeleteUser.UseVisualStyleBackColor = true;
            // 
            // SaveUsers
            // 
            SaveUsers.Location = new Point(797, 597);
            SaveUsers.Name = "SaveUsers";
            SaveUsers.Size = new Size(75, 23);
            SaveUsers.TabIndex = 4;
            SaveUsers.Text = "Save";
            SaveUsers.UseVisualStyleBackColor = true;
            // 
            // Close
            // 
            Close.Location = new Point(797, 626);
            Close.Name = "Close";
            Close.Size = new Size(75, 23);
            Close.TabIndex = 5;
            Close.Text = "Close";
            Close.UseVisualStyleBackColor = true;
            // 
            // UserMgmt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 661);
            Controls.Add(Close);
            Controls.Add(SaveUsers);
            Controls.Add(DeleteUser);
            Controls.Add(EditUser);
            Controls.Add(AddUser);
            Controls.Add(UserList);
            Name = "UserMgmt";
            Text = "UserMgmt";
            Load += UserMgmt_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox UserList;
        private Button AddUser;
        private Button EditUser;
        private Button DeleteUser;
        private Button SaveUsers;
        private Button Close;
    }
}