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
using Yazlab3.GraphElements;
using Yazlab3.UserControls;

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
            this.ActiveControl = inputControls.tbxNodeCount;

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

        private void btnMaxFlow_Click(object sender, EventArgs e)
        {
            MyGraph myGraph = InputControls.getMyGraph();

            long maxFlow = myGraph.getMaxFlow();

            MessageBox.Show($"Başlangıç Noktası: {myGraph.getStartingPoint()}\n" +
                $"Bitiş Noktası: {myGraph.getEndPoint()}\n" +
                $"Maximum flow = {maxFlow}", "Maximum flow",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMaxFlowPaths_Click(object sender, EventArgs e)
        {
            MyGraph myGraph = InputControls.getMyGraph();
            var pathList = myGraph.getAllPaths();
            var maxFlowList = new List<int>();
            var isMaxFlowList = new List<bool>();

            for (int i = 0; i < pathList.Count(); i++)
            {
                int maxFlow = myGraph.getMaxFlowOfPath(pathList[i]);
                maxFlowList.Add(maxFlow);
            }

            int maxFlowNum = maxFlowList.Max();

            foreach (var maxFlow in maxFlowList)
            {
                if (maxFlow == maxFlowNum)
                {
                    isMaxFlowList.Add(true);
                }
                else
                {
                    isMaxFlowList.Add(false);
                }
            }

            for (int i = 0; i < pathList.Count(); i++)
            {
                FormGraph formGraph = new FormGraph(pathList[i], isMaxFlowList[i]);
                formGraph.Show();
            }
            
        }
    }
}
