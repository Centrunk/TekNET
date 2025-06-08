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
            AddFacilityBUT = new Button();
            EditFacilityBUT = new Button();
            DeleteFacilityBUT = new Button();
            SaveFacilityBUT = new Button();
            CloseFacilityBUT = new Button();
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
            // AddFacilityBUT
            // 
            AddFacilityBUT.Location = new Point(550, 12);
            AddFacilityBUT.Name = "AddFacilityBUT";
            AddFacilityBUT.Size = new Size(94, 23);
            AddFacilityBUT.TabIndex = 1;
            AddFacilityBUT.Text = "Add Facility";
            AddFacilityBUT.UseVisualStyleBackColor = true;
            // 
            // EditFacilityBUT
            // 
            EditFacilityBUT.Location = new Point(550, 41);
            EditFacilityBUT.Name = "EditFacilityBUT";
            EditFacilityBUT.Size = new Size(94, 23);
            EditFacilityBUT.TabIndex = 2;
            EditFacilityBUT.Text = "Edit Facility";
            EditFacilityBUT.UseVisualStyleBackColor = true;
            EditFacilityBUT.Click += button2_Click;
            // 
            // DeleteFacilityBUT
            // 
            DeleteFacilityBUT.Location = new Point(550, 70);
            DeleteFacilityBUT.Name = "DeleteFacilityBUT";
            DeleteFacilityBUT.Size = new Size(94, 23);
            DeleteFacilityBUT.TabIndex = 3;
            DeleteFacilityBUT.Text = "Delete Facility";
            DeleteFacilityBUT.UseVisualStyleBackColor = true;
            // 
            // SaveFacilityBUT
            // 
            SaveFacilityBUT.Location = new Point(820, 564);
            SaveFacilityBUT.Name = "SaveFacilityBUT";
            SaveFacilityBUT.Size = new Size(75, 23);
            SaveFacilityBUT.TabIndex = 4;
            SaveFacilityBUT.Text = "Save";
            SaveFacilityBUT.UseVisualStyleBackColor = true;
            // 
            // CloseFacilityBUT
            // 
            CloseFacilityBUT.Location = new Point(820, 593);
            CloseFacilityBUT.Name = "CloseFacilityBUT";
            CloseFacilityBUT.Size = new Size(75, 23);
            CloseFacilityBUT.TabIndex = 5;
            CloseFacilityBUT.Text = "Close";
            CloseFacilityBUT.UseVisualStyleBackColor = true;
            // 
            // FacilityMgmt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(907, 628);
            Controls.Add(CloseFacilityBUT);
            Controls.Add(SaveFacilityBUT);
            Controls.Add(DeleteFacilityBUT);
            Controls.Add(EditFacilityBUT);
            Controls.Add(AddFacilityBUT);
            Controls.Add(FacilityList);
            Name = "FacilityMgmt";
            Text = "FacilityMgmt";
            ResumeLayout(false);
        }

        #endregion

        private ListBox FacilityList;
        private Button AddFacilityBUT;
        private Button EditFacilityBUT;
        private Button DeleteFacilityBUT;
        private Button SaveFacilityBUT;
        private Button CloseFacilityBUT;
    }
}