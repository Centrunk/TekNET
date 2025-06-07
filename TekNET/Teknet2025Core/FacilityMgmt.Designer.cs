namespace Teknet2025Core
{
	partial class FacilityMgmt
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
            FacilityList = new ListBox();
            AddFacility = new Button();
            EditFacility = new Button();
            DeleteFacility = new Button();
            SaveFacility = new Button();
            CloseFacility = new Button();
            SuspendLayout();
            // 
            // FacilityList
            // 
            FacilityList.FormattingEnabled = true;
            FacilityList.ItemHeight = 15;
            FacilityList.Items.AddRange(new object[] { "FacilityID-Status-Version" });
            FacilityList.Location = new Point(12, 12);
            FacilityList.Name = "FacilityList";
            FacilityList.Size = new Size(480, 604);
            FacilityList.TabIndex = 0;
            // 
            // AddFacility
            // 
            AddFacility.Location = new Point(550, 12);
            AddFacility.Name = "AddFacility";
            AddFacility.Size = new Size(94, 23);
            AddFacility.TabIndex = 1;
            AddFacility.Text = "Add Facility";
            AddFacility.UseVisualStyleBackColor = true;
            // 
            // EditFacility
            // 
            EditFacility.Location = new Point(550, 41);
            EditFacility.Name = "EditFacility";
            EditFacility.Size = new Size(94, 23);
            EditFacility.TabIndex = 2;
            EditFacility.Text = "Edit Facility";
            EditFacility.UseVisualStyleBackColor = true;
            EditFacility.Click += button2_Click;
            // 
            // DeleteFacility
            // 
            DeleteFacility.Location = new Point(550, 70);
            DeleteFacility.Name = "DeleteFacility";
            DeleteFacility.Size = new Size(94, 23);
            DeleteFacility.TabIndex = 3;
            DeleteFacility.Text = "Delete Facility";
            DeleteFacility.UseVisualStyleBackColor = true;
            // 
            // SaveFacility
            // 
            SaveFacility.Location = new Point(820, 564);
            SaveFacility.Name = "SaveFacility";
            SaveFacility.Size = new Size(75, 23);
            SaveFacility.TabIndex = 4;
            SaveFacility.Text = "Save";
            SaveFacility.UseVisualStyleBackColor = true;
            // 
            // CloseFacility
            // 
            CloseFacility.Location = new Point(820, 593);
            CloseFacility.Name = "CloseFacility";
            CloseFacility.Size = new Size(75, 23);
            CloseFacility.TabIndex = 5;
            CloseFacility.Text = "Close";
            CloseFacility.UseVisualStyleBackColor = true;
            // 
            // FacilityMgmt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(907, 628);
            Controls.Add(CloseFacility);
            Controls.Add(SaveFacility);
            Controls.Add(DeleteFacility);
            Controls.Add(EditFacility);
            Controls.Add(AddFacility);
            Controls.Add(FacilityList);
            Name = "FacilityMgmt";
            Text = "FacilityMgmt";
            ResumeLayout(false);
        }

        #endregion

        private ListBox FacilityList;
        private Button AddFacility;
        private Button EditFacility;
        private Button DeleteFacility;
        private Button SaveFacility;
        private Button CloseFacility;
    }
}