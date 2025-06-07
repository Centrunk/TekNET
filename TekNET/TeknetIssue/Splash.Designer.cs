namespace TeknetIssue
{
	partial class Splash
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
            TNSplashLBL = new Label();
            RelCTRSLBL = new Label();
            SuspendLayout();
            // 
            // TNSplashLBL
            // 
            TNSplashLBL.AutoSize = true;
            TNSplashLBL.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TNSplashLBL.Location = new Point(133, 9);
            TNSplashLBL.Name = "TNSplashLBL";
            TNSplashLBL.Size = new Size(160, 15);
            TNSplashLBL.TabIndex = 0;
            TNSplashLBL.Text = "Welcome to TekNet 2025";
            // 
            // RelCTRSLBL
            // 
            RelCTRSLBL.AutoSize = true;
            RelCTRSLBL.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RelCTRSLBL.Location = new Point(29, 192);
            RelCTRSLBL.Name = "RelCTRSLBL";
            RelCTRSLBL.Size = new Size(368, 15);
            RelCTRSLBL.TabIndex = 1;
            RelCTRSLBL.Text = "A product of the Centeral Texas Trunked Radio System";
            RelCTRSLBL.Click += RelCTRSLBL_Click;
            // 
            // Splash
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Flags_vert;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(428, 216);
            Controls.Add(RelCTRSLBL);
            Controls.Add(TNSplashLBL);
            DoubleBuffered = true;
            Name = "Splash";
            Text = "Splash";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TNSplashLBL;
        private Label RelCTRSLBL;
    }
}