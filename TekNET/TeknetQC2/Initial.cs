using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TN_API;

namespace TeknetQC2
{
	public partial class Initial : Form
	{
		public string serveraddr;
		public Initial()
		{
			InitializeComponent();
		}

		internal byte[] IV = new byte[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		private static byte[] aeskey = Encoding.ASCII.GetBytes(@"");

		internal SimpleTCP.SimpleTcpClient STPC = new SimpleTCP.SimpleTcpClient();
		internal int svrport;
		internal void Connect()
		{
			try {
				STPC.Connect(svraddrtxt.Text, svrport);
				string sendy = "0x01" + "0x00" + FACbox.Text + otpbox.Text;
				STPC.WriteLineAndGetReply(sendy, TimeSpan.FromSeconds(3));
			} 
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
		}
		internal bool svrconstat;
		private void tstpagebut_Click(object sender, EventArgs e)
		{
			string[] testt = { "tech" };
			VoiceTone.TONEOUT("Text", testt, 1, "0");
		}

		private void savebut_Click(object sender, EventArgs e)
		{
			aeskey = Encoding.ASCII.GetBytes(aeskeytxt.Text);
			serveraddr = svraddrtxt.Text;
			svrport = int.Parse(portTXT.Text);
		}

		private void Initial_Load(object sender, EventArgs e)
		{
			portTXT.Text = "8650";
			STPC.StringEncoder = Encoding.ASCII;
			STPC.DataReceived += STPC_DataReceived;
		}

		private void STPC_DataReceived(object? sender, SimpleTCP.Message e)
		{
			throw new NotImplementedException();
		}

		private void svrstatus_Click(object sender, EventArgs e)
		{
			if (svrconstat == false) 
			{
				Connect();
			}

		}
	}
}
