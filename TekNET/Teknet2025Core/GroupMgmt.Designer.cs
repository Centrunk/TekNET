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
            AddGroup = new Button();
            EditGroup = new Button();
            DeleteGroup = new Button();
            SaveGroup = new Button();
            CloseGroup = new Button();
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
            // AddGroup
            // 
            AddGroup.Location = new Point(510, 12);
            AddGroup.Name = "AddGroup";
            AddGroup.Size = new Size(87, 23);
            AddGroup.TabIndex = 1;
            AddGroup.Text = "Add Group";
            AddGroup.UseVisualStyleBackColor = true;
            // 
            // EditGroup
            // 
            EditGroup.Location = new Point(510, 41);
            EditGroup.Name = "EditGroup";
            EditGroup.Size = new Size(87, 23);
            EditGroup.TabIndex = 2;
            EditGroup.Text = "EditGroup";
            EditGroup.UseVisualStyleBackColor = true;
            // 
            // DeleteGroup
            // 
            DeleteGroup.Location = new Point(510, 70);
            DeleteGroup.Name = "DeleteGroup";
            DeleteGroup.Size = new Size(87, 23);
            DeleteGroup.TabIndex = 3;
            DeleteGroup.Text = "DeleteGroup";
            DeleteGroup.UseVisualStyleBackColor = true;
            // 
            // SaveGroup
            // 
            SaveGroup.Location = new Point(813, 589);
            SaveGroup.Name = "SaveGroup";
            SaveGroup.Size = new Size(75, 23);
            SaveGroup.TabIndex = 4;
            SaveGroup.Text = "Save";
            SaveGroup.UseVisualStyleBackColor = true;
            // 
            // CloseGroup
            // 
            CloseGroup.Location = new Point(813, 618);
            CloseGroup.Name = "CloseGroup";
            CloseGroup.Size = new Size(75, 23);
            CloseGroup.TabIndex = 5;
            CloseGroup.Text = "Close";
            CloseGroup.UseVisualStyleBackColor = true;
            CloseGroup.Click += CloseGroup_Click;
            // 
            // GroupMgmt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 653);
            Controls.Add(CloseGroup);
            Controls.Add(SaveGroup);
            Controls.Add(DeleteGroup);
            Controls.Add(EditGroup);
            Controls.Add(AddGroup);
            Controls.Add(GroupList);
            Name = "GroupMgmt";
            Text = "GroupMgmt";
            ResumeLayout(false);
        }

        #endregion

        private ListBox GroupList;
        private Button AddGroup;
        private Button EditGroup;
        private Button DeleteGroup;
        private Button SaveGroup;
        private Button CloseGroup;
    }
}