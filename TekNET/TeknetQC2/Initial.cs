using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

		private void tstpagebut_Click(object sender, EventArgs e)
		{
			string[] testt = { "tech" };
			VoiceTone.TONEOUT("Text", testt, 1, "0");
		}

		private void savebut_Click(object sender, EventArgs e)
		{
			aeskey = Encoding.ASCII.GetBytes(aeskeytxt.Text);
			serveraddr = svraddrtxt.Text;
		}
	}
}
