using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknetIssue
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            TikTimer1.Start();
        }

        private void RelCTRSLBL_Click(object sender, EventArgs e)
        {

        }

        private void TikTimer1_Tick(object sender, EventArgs e)
        {
            LoadingBar.Value += 1;
        }
    }
}
