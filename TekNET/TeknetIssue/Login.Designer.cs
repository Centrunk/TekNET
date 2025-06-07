namespace TeknetIssue
{
	partial class Login
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
            UserNameLBL = new Label();
            UserNameTXT = new TextBox();
            OTPTXT = new TextBox();
            OTPLBL = new Label();
            LoginBut = new Button();
            SuspendLayout();
            // 
            // UserNameLBL
            // 
            UserNameLBL.AutoSize = true;
            UserNameLBL.Location = new Point(68, 9);
            UserNameLBL.Name = "UserNameLBL";
            UserNameLBL.Size = new Size(65, 15);
            UserNameLBL.TabIndex = 0;
            UserNameLBL.Text = "User Name";
            UserNameLBL.Click += UserNameLBL_Click;
            // 
            // UserNameTXT
            // 
            UserNameTXT.Location = new Point(54, 27);
            UserNameTXT.Name = "UserNameTXT";
            UserNameTXT.Size = new Size(100, 23);
            UserNameTXT.TabIndex = 1;
            UserNameTXT.TextChanged += UserNameTXT_TextChanged;
            // 
            // OTPTXT
            // 
            OTPTXT.Location = new Point(54, 71);
            OTPTXT.Name = "OTPTXT";
            OTPTXT.Size = new Size(100, 23);
            OTPTXT.TabIndex = 2;
            // 
            // OTPLBL
            // 
            OTPLBL.AutoSize = true;
            OTPLBL.Location = new Point(83, 53);
            OTPLBL.Name = "OTPLBL";
            OTPLBL.Size = new Size(28, 15);
            OTPLBL.TabIndex = 3;
            OTPLBL.Text = "OTP";
            // 
            // LoginBut
            // 
            LoginBut.Location = new Point(66, 100);
            LoginBut.Name = "LoginBut";
            LoginBut.Size = new Size(75, 23);
            LoginBut.TabIndex = 4;
            LoginBut.Text = "Login";
            LoginBut.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Sherbet_Pride_with_bowl;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(196, 136);
            Controls.Add(LoginBut);
            Controls.Add(OTPLBL);
            Controls.Add(OTPTXT);
            Controls.Add(UserNameTXT);
            Controls.Add(UserNameLBL);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UserNameLBL;
        private TextBox UserNameTXT;
        private TextBox OTPTXT;
        private Label OTPLBL;
        private Button LoginBut;
    }
}