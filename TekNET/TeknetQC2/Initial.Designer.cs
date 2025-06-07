namespace TeknetQC2
{
	partial class Initial
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
			savebut = new Button();
			comboBox1 = new ComboBox();
			label1 = new Label();
			label2 = new Label();
			textBox1 = new TextBox();
			SuspendLayout();
			// 
			// savebut
			// 
			savebut.Location = new Point(653, 146);
			savebut.Name = "savebut";
			savebut.Size = new Size(75, 23);
			savebut.TabIndex = 0;
			savebut.Text = "Save";
			savebut.UseVisualStyleBackColor = true;
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(632, 48);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(121, 23);
			comboBox1.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(669, 31);
			label1.Name = "label1";
			label1.Size = new Size(38, 15);
			label1.TabIndex = 2;
			label1.Text = "label1";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(673, 79);
			label2.Name = "label2";
			label2.Size = new Size(38, 15);
			label2.TabIndex = 3;
			label2.Text = "label2";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(632, 97);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(121, 23);
			textBox1.TabIndex = 4;
			// 
			// Initial
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackgroundImage = Properties.Resources.IMG_1451;
			BackgroundImageLayout = ImageLayout.Center;
			ClientSize = new Size(800, 450);
			Controls.Add(textBox1);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(comboBox1);
			Controls.Add(savebut);
			Name = "Initial";
			Text = "Initial";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button savebut;
		private ComboBox comboBox1;
		private Label label1;
		private Label label2;
		private TextBox textBox1;
	}
}