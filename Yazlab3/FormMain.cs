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
            //inputControls.Show();
            this.ActiveControl = inputControls.tbxNodeCount;

        }

        private void btnControlPnl_Click(object sender, EventArgs e)
        {
            graphView.Hide();
            //inputControls.Show();
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
                FormGraph formGraph = new FormGraph(pathList[i], isMaxFlowList[i]/*, maxFlowList[i]*/);
                formGraph.Text = "Net Flow: " + maxFlowList[i].ToString();
                formGraph.Show();
            }
            
        }

        private void btnMinCut_Click(object sender, EventArgs e)
        {
            var myGraph = InputControls.getMyGraph();

            var matrixOfGraph = MinCut.getMatrixOfGraph(myGraph);
            string start = myGraph.getStartingPoint();
            string end = myGraph.getEndPoint();

            int startNum = MinCut.getNodeNum(start);
            int endNum = MinCut.getNodeNum(end);

            var pipeList = MinCut.minCut(matrixOfGraph, startNum, endNum);
            //var pipeList = MinCut.minCut(matrixOfGraph, Int32.Parse(myGraph.getStartingPoint()),
            //    Int32.Parse(myGraph.getEndPoint()));

            FormGraph formGraph = new FormGraph(pipeList);
            formGraph.Text = "MinCut";
            formGraph.Show();

            StringBuilder sb = new StringBuilder("MinCut Edges:\n");

            for (int i = 0; i < pipeList.GetLength(0); i++)
            {
                sb.Append(MinCut.getNodeName(pipeList[i, 0]) + " - " + MinCut.getNodeName(pipeList[i, 1]) + "\n");
            }

            MessageBox.Show(sb.ToString(), "MinCut Kenarları",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            //var pipeNameArray = new int[pipeList.GetLength(0), pipeList.GetLength(1)];
            //for (int i = 0; i < pipeList.GetLength(0); i++)
            //{
            //    for (int i = 0; i < length; i++)
            //    {

            //    }
            //    pipeNameArray[i, 0] = MinCut.getNodeName(pipeList[i, 0]);
            //}
        }

    }
}
