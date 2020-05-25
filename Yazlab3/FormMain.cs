using Microsoft.Msagl.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazlab3
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            graphView.Hide();
            inputControls.Show();
        }

        private void btnControlPnl_Click(object sender, EventArgs e)
        {
            graphView.Hide();
            inputControls.Show();
        }

        private void btnGraphView_Click(object sender, EventArgs e)
        {
            FormGraph formGraph = new FormGraph();
            formGraph.Show();
        }
    }
}
