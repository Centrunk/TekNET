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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Initial));
			savebut = new Button();
			comboBox1 = new ComboBox();
			AudioOutDropLab = new Label();
			rs232pttcmd = new Label();
			textBox1 = new TextBox();
			svrstatus = new Button();
			svraddrtxt = new TextBox();
			serveraddrlab = new Label();
			tstpagebut = new Button();
			listBox1 = new ListBox();
			label1 = new Label();
			textBox3 = new TextBox();
			aeskeytxt = new Label();
			otplabel = new Label();
			otpbox = new TextBox();
			faclab = new Label();
			FACbox = new TextBox();
			portlab = new Label();
			portTXT = new TextBox();
			SuspendLayout();
			// 
			// savebut
			// 
			savebut.Location = new Point(640, 327);
			savebut.Name = "savebut";
			savebut.Size = new Size(75, 23);
			savebut.TabIndex = 0;
			savebut.Text = "Save";
			savebut.UseVisualStyleBackColor = true;
			savebut.Click += savebut_Click;
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(624, 48);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(121, 23);
			comboBox1.TabIndex = 1;
			// 
			// AudioOutDropLab
			// 
			AudioOutDropLab.AutoSize = true;
			AudioOutDropLab.Location = new Point(653, 30);
			AudioOutDropLab.Name = "AudioOutDropLab";
			AudioOutDropLab.Size = new Size(62, 15);
			AudioOutDropLab.TabIndex = 2;
			AudioOutDropLab.Text = "Audio Out";
			// 
			// rs232pttcmd
			// 
			rs232pttcmd.AutoSize = true;
			rs232pttcmd.Location = new Point(640, 79);
			rs232pttcmd.Name = "rs232pttcmd";
			rs232pttcmd.Size = new Size(87, 15);
			rs232pttcmd.TabIndex = 3;
			rs232pttcmd.Text = "Serial PTT CMD";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(624, 97);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(121, 23);
			textBox1.TabIndex = 4;
			// 
			// svrstatus
			// 
			svrstatus.BackColor = Color.Red;
			svrstatus.Location = new Point(292, 1);
			svrstatus.Name = "svrstatus";
			svrstatus.Size = new Size(216, 23);
			svrstatus.TabIndex = 5;
			svrstatus.Text = "Server Status";
			svrstatus.UseVisualStyleBackColor = false;
			svrstatus.Click += svrstatus_Click;
			// 
			// svraddrtxt
			// 
			svraddrtxt.Location = new Point(581, 199);
			svraddrtxt.Name = "svraddrtxt";
			svraddrtxt.Size = new Size(111, 23);
			svraddrtxt.TabIndex = 6;
			// 
			// serveraddrlab
			// 
			serveraddrlab.AutoSize = true;
			serveraddrlab.Location = new Point(595, 181);
			serveraddrlab.Name = "serveraddrlab";
			serveraddrlab.Size = new Size(84, 15);
			serveraddrlab.TabIndex = 7;
			serveraddrlab.Text = "Server Address";
			// 
			// tstpagebut
			// 
			tstpagebut.Location = new Point(12, 148);
			tstpagebut.Name = "tstpagebut";
			tstpagebut.Size = new Size(267, 23);
			tstpagebut.TabIndex = 8;
			tstpagebut.Text = "Test Page";
			tstpagebut.UseVisualStyleBackColor = true;
			tstpagebut.Click += tstpagebut_Click;
			// 
			// listBox1
			// 
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 15;
			listBox1.Location = new Point(12, 30);
			listBox1.Name = "listBox1";
			listBox1.Size = new Size(267, 109);
			listBox1.TabIndex = 9;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(103, 9);
			label1.Name = "label1";
			label1.Size = new Size(69, 15);
			label1.TabIndex = 10;
			label1.Text = "Active Page";
			// 
			// textBox3
			// 
			textBox3.Location = new Point(581, 148);
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(212, 23);
			textBox3.TabIndex = 11;
			// 
			// aeskeytxt
			// 
			aeskeytxt.AutoSize = true;
			aeskeytxt.Location = new Point(644, 130);
			aeskeytxt.Name = "aeskeytxt";
			aeskeytxt.Size = new Size(84, 15);
			aeskeytxt.TabIndex = 12;
			aeskeytxt.Text = "Server AES Key";
			// 
			// otplabel
			// 
			otplabel.AutoSize = true;
			otplabel.Location = new Point(664, 230);
			otplabel.Name = "otplabel";
			otplabel.Size = new Size(28, 15);
			otplabel.TabIndex = 14;
			otplabel.Text = "OTP";
			// 
			// otpbox
			// 
			otpbox.Location = new Point(606, 248);
			otpbox.Name = "otpbox";
			otpbox.Size = new Size(160, 23);
			otpbox.TabIndex = 13;
			// 
			// faclab
			// 
			faclab.AutoSize = true;
			faclab.Location = new Point(640, 280);
			faclab.Name = "faclab";
			faclab.Size = new Size(75, 15);
			faclab.TabIndex = 16;
			faclab.Text = "Facility Code";
			// 
			// FACbox
			// 
			FACbox.Location = new Point(606, 298);
			FACbox.Name = "FACbox";
			FACbox.Size = new Size(160, 23);
			FACbox.TabIndex = 15;
			// 
			// portlab
			// 
			portlab.AutoSize = true;
			portlab.Location = new Point(726, 181);
			portlab.Name = "portlab";
			portlab.Size = new Size(29, 15);
			portlab.TabIndex = 18;
			portlab.Text = "Port";
			// 
			// portTXT
			// 
			portTXT.Location = new Point(698, 199);
			portTXT.Name = "portTXT";
			portTXT.Size = new Size(93, 23);
			portTXT.TabIndex = 17;
			// 
			// Initial
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ControlDark;
			BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
			BackgroundImageLayout = ImageLayout.Zoom;
			ClientSize = new Size(800, 450);
			Controls.Add(portlab);
			Controls.Add(portTXT);
			Controls.Add(faclab);
			Controls.Add(FACbox);
			Controls.Add(otplabel);
			Controls.Add(otpbox);
			Controls.Add(aeskeytxt);
			Controls.Add(textBox3);
			Controls.Add(label1);
			Controls.Add(listBox1);
			Controls.Add(tstpagebut);
			Controls.Add(serveraddrlab);
			Controls.Add(svraddrtxt);
			Controls.Add(svrstatus);
			Controls.Add(textBox1);
			Controls.Add(rs232pttcmd);
			Controls.Add(AudioOutDropLab);
			Controls.Add(comboBox1);
			Controls.Add(savebut);
			DoubleBuffered = true;
			Name = "Initial";
			Text = "Initial";
			Load += Initial_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button savebut;
		private ComboBox comboBox1;
		private Label AudioOutDropLab;
		private Label rs232pttcmd;
		private TextBox textBox1;
		private Button svrstatus;
		private TextBox svraddrtxt;
		private Label serveraddrlab;
		private Button tstpagebut;
		private ListBox listBox1;
		private Label label1;
		private TextBox textBox3;
		private Label aeskeytxt;
		private Label otplabel;
		private TextBox otpbox;
		private Label faclab;
		private TextBox FACbox;
		private Label portlab;
		private TextBox portTXT;
	}
}