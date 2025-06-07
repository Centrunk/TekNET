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
		public Initial()
		{
			InitializeComponent();
		}

		private void tstpagebut_Click(object sender, EventArgs e)
		{
			VoiceTone.TONEOUT();
		}
	}
}
