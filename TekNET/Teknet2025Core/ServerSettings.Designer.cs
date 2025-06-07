namespace Teknet2025Core
{
	partial class ServerSettings
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
			textBox1 = new TextBox();
			enckeylab = new Label();
			savebut = new Button();
			portLab = new Label();
			porttxb = new TextBox();
			SuspendLayout();
			// 
			// textBox1
			// 
			textBox1.Location = new Point(12, 30);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(313, 23);
			textBox1.TabIndex = 0;
			// 
			// enckeylab
			// 
			enckeylab.AutoSize = true;
			enckeylab.Location = new Point(112, 9);
			enckeylab.Name = "enckeylab";
			enckeylab.Size = new Size(86, 15);
			enckeylab.TabIndex = 1;
			enckeylab.Text = "Encryption Key";
			// 
			// savebut
			// 
			savebut.Location = new Point(356, 415);
			savebut.Name = "savebut";
			savebut.Size = new Size(75, 23);
			savebut.TabIndex = 2;
			savebut.Text = "Save";
			savebut.UseVisualStyleBackColor = true;
			// 
			// portLab
			// 
			portLab.AutoSize = true;
			portLab.Location = new Point(56, 80);
			portLab.Name = "portLab";
			portLab.Size = new Size(29, 15);
			portLab.TabIndex = 4;
			portLab.Text = "Port";
			// 
			// porttxb
			// 
			porttxb.Location = new Point(12, 98);
			porttxb.Name = "porttxb";
			porttxb.Size = new Size(129, 23);
			porttxb.TabIndex = 3;
			// 
			// ServerSettings
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.Control;
			ClientSize = new Size(800, 450);
			Controls.Add(portLab);
			Controls.Add(porttxb);
			Controls.Add(savebut);
			Controls.Add(enckeylab);
			Controls.Add(textBox1);
			Name = "ServerSettings";
			Text = "ServerSettings";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox1;
		private Label enckeylab;
		private Button savebut;
		private Label portLab;
		private TextBox porttxb;
	}
}