namespace Teknet2025Core
{
    partial class GroupMgmt
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
            GroupList = new ListBox();
            AddGroupBUT = new Button();
            EditGroupBUT = new Button();
            DeleteGroupBUT = new Button();
            SaveGroupBUT = new Button();
            CloseGroupBUT = new Button();
            SuspendLayout();
            // 
            // GroupList
            // 
            GroupList.FormattingEnabled = true;
            GroupList.ItemHeight = 15;
            GroupList.Items.AddRange(new object[] { "GroupID-GroupAlias-NumberMembers" });
            GroupList.Location = new Point(3, 12);
            GroupList.Name = "GroupList";
            GroupList.Size = new Size(403, 619);
            GroupList.TabIndex = 0;
            // 
            // AddGroupBUT
            // 
            AddGroupBUT.Location = new Point(510, 12);
            AddGroupBUT.Name = "AddGroupBUT";
            AddGroupBUT.Size = new Size(87, 23);
            AddGroupBUT.TabIndex = 1;
            AddGroupBUT.Text = "Add Group";
            AddGroupBUT.UseVisualStyleBackColor = true;
            // 
            // EditGroupBUT
            // 
            EditGroupBUT.Location = new Point(510, 41);
            EditGroupBUT.Name = "EditGroupBUT";
            EditGroupBUT.Size = new Size(87, 23);
            EditGroupBUT.TabIndex = 2;
            EditGroupBUT.Text = "EditGroup";
            EditGroupBUT.UseVisualStyleBackColor = true;
            // 
            // DeleteGroupBUT
            // 
            DeleteGroupBUT.Location = new Point(510, 70);
            DeleteGroupBUT.Name = "DeleteGroupBUT";
            DeleteGroupBUT.Size = new Size(87, 23);
            DeleteGroupBUT.TabIndex = 3;
            DeleteGroupBUT.Text = "DeleteGroup";
            DeleteGroupBUT.UseVisualStyleBackColor = true;
            // 
            // SaveGroupBUT
            // 
            SaveGroupBUT.Location = new Point(813, 589);
            SaveGroupBUT.Name = "SaveGroupBUT";
            SaveGroupBUT.Size = new Size(75, 23);
            SaveGroupBUT.TabIndex = 4;
            SaveGroupBUT.Text = "Save";
            SaveGroupBUT.UseVisualStyleBackColor = true;
            // 
            // CloseGroupBUT
            // 
            CloseGroupBUT.Location = new Point(813, 618);
            CloseGroupBUT.Name = "CloseGroupBUT";
            CloseGroupBUT.Size = new Size(75, 23);
            CloseGroupBUT.TabIndex = 5;
            CloseGroupBUT.Text = "Close";
            CloseGroupBUT.UseVisualStyleBackColor = true;
            CloseGroupBUT.Click += CloseGroup_Click;
            // 
            // GroupMgmt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 653);
            Controls.Add(CloseGroupBUT);
            Controls.Add(SaveGroupBUT);
            Controls.Add(DeleteGroupBUT);
            Controls.Add(EditGroupBUT);
            Controls.Add(AddGroupBUT);
            Controls.Add(GroupList);
            Name = "GroupMgmt";
            Text = "GroupMgmt";
            ResumeLayout(false);
        }

        #endregion

        private ListBox GroupList;
        private Button AddGroupBUT;
        private Button EditGroupBUT;
        private Button DeleteGroupBUT;
        private Button SaveGroupBUT;
        private Button CloseGroupBUT;
    }
}