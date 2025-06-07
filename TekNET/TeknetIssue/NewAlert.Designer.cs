namespace TeknetIssue
{
	partial class NewAlert
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
            AlertTypeLBL = new Label();
            AlertTypeList = new ComboBox();
            AlertContLBL = new Label();
            label1AlrtClassLBL = new Label();
            AlertClassList = new ComboBox();
            AlertDestLBL = new Label();
            AlertDestTXT = new TextBox();
            AlertContTXT = new RichTextBox();
            ClearAlertBut = new Button();
            SendAlertBut = new Button();
            SuspendLayout();
            // 
            // AlertTypeLBL
            // 
            AlertTypeLBL.AutoSize = true;
            AlertTypeLBL.Location = new Point(82, 35);
            AlertTypeLBL.Name = "AlertTypeLBL";
            AlertTypeLBL.Size = new Size(59, 15);
            AlertTypeLBL.TabIndex = 0;
            AlertTypeLBL.Text = "Alert Type";
            // 
            // AlertTypeList
            // 
            AlertTypeList.FormattingEnabled = true;
            AlertTypeList.Items.AddRange(new object[] { "System Wide", "Regional", "Group", "Invidual Tone", "Invidual Data", "Invidual Advanced" });
            AlertTypeList.Location = new Point(79, 53);
            AlertTypeList.Name = "AlertTypeList";
            AlertTypeList.Size = new Size(121, 23);
            AlertTypeList.TabIndex = 1;
            // 
            // AlertContLBL
            // 
            AlertContLBL.AutoSize = true;
            AlertContLBL.Location = new Point(79, 94);
            AlertContLBL.Name = "AlertContLBL";
            AlertContLBL.Size = new Size(83, 15);
            AlertContLBL.TabIndex = 2;
            AlertContLBL.Text = "Alert Contents";
            // 
            // label1AlrtClassLBL
            // 
            label1AlrtClassLBL.AutoSize = true;
            label1AlrtClassLBL.Location = new Point(286, 35);
            label1AlrtClassLBL.Name = "label1AlrtClassLBL";
            label1AlrtClassLBL.Size = new Size(62, 15);
            label1AlrtClassLBL.TabIndex = 4;
            label1AlrtClassLBL.Text = "Alert Class";
            // 
            // AlertClassList
            // 
            AlertClassList.FormattingEnabled = true;
            AlertClassList.Items.AddRange(new object[] { "Normal", "Urgent", "Critical", "Catastrophix", "WXR" });
            AlertClassList.Location = new Point(283, 53);
            AlertClassList.Name = "AlertClassList";
            AlertClassList.Size = new Size(121, 23);
            AlertClassList.TabIndex = 5;
            // 
            // AlertDestLBL
            // 
            AlertDestLBL.AutoSize = true;
            AlertDestLBL.Location = new Point(479, 31);
            AlertDestLBL.Name = "AlertDestLBL";
            AlertDestLBL.Size = new Size(67, 15);
            AlertDestLBL.TabIndex = 6;
            AlertDestLBL.Text = "Destination";
            AlertDestLBL.Click += AlertDestLBL_Click;
            // 
            // AlertDestTXT
            // 
            AlertDestTXT.Location = new Point(477, 53);
            AlertDestTXT.Name = "AlertDestTXT";
            AlertDestTXT.Size = new Size(100, 23);
            AlertDestTXT.TabIndex = 7;
            // 
            // AlertContTXT
            // 
            AlertContTXT.Location = new Point(79, 112);
            AlertContTXT.Name = "AlertContTXT";
            AlertContTXT.Size = new Size(498, 96);
            AlertContTXT.TabIndex = 8;
            AlertContTXT.Text = "";
            AlertContTXT.TextChanged += richTextBox1_TextChanged;
            // 
            // ClearAlertBut
            // 
            ClearAlertBut.Location = new Point(200, 214);
            ClearAlertBut.Name = "ClearAlertBut";
            ClearAlertBut.Size = new Size(75, 23);
            ClearAlertBut.TabIndex = 9;
            ClearAlertBut.Text = "Clear";
            ClearAlertBut.UseVisualStyleBackColor = true;
            // 
            // SendAlertBut
            // 
            SendAlertBut.Location = new Point(370, 214);
            SendAlertBut.Name = "SendAlertBut";
            SendAlertBut.Size = new Size(75, 23);
            SendAlertBut.TabIndex = 10;
            SendAlertBut.Text = "Send Alert";
            SendAlertBut.UseVisualStyleBackColor = true;
            // 
            // NewAlert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 270);
            Controls.Add(SendAlertBut);
            Controls.Add(ClearAlertBut);
            Controls.Add(AlertContTXT);
            Controls.Add(AlertDestTXT);
            Controls.Add(AlertDestLBL);
            Controls.Add(AlertClassList);
            Controls.Add(label1AlrtClassLBL);
            Controls.Add(AlertContLBL);
            Controls.Add(AlertTypeList);
            Controls.Add(AlertTypeLBL);
            Name = "NewAlert";
            Text = "NewAlert";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AlertTypeLBL;
        private ComboBox AlertTypeList;
        private Label AlertContLBL;
        private Label label1AlrtClassLBL;
        private ComboBox AlertClassList;
        private Label AlertDestLBL;
        private TextBox AlertDestTXT;
        private RichTextBox AlertContTXT;
        private Button ClearAlertBut;
        private Button SendAlertBut;
    }
}