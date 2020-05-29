using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yazlab3.GraphElements;

namespace Yazlab3.UserControls
{
    partial class InputControls : UserControl
    {
        static MyGraph myGraph = new MyGraph();
        static List<MyNode> listOfNodes = new List<MyNode>();

        public InputControls()
        {
            InitializeComponent();
        }

        private void btnNodeCount_Click(object sender, EventArgs e)
        {
            if (!tbxNodeCount.Text.All(char.IsDigit))
            {
                return;
            }
            if (String.IsNullOrEmpty(tbxNodeCount.Text))
            {
                return;
            }

            pnlFlowLayout.Controls.Clear();

            var lbl = new Label();
            lbl.Text = "Yeni kenar oluştur";
            pnlFlowLayout.Controls.Add(lbl);

            var btnAddPipe = new Button();
            btnAddPipe.Text = "Ekle";
            btnAddPipe.Click += new EventHandler(btnAddPipeClickEvent);

            int nodeCount;

            nodeCount = Int32.Parse(tbxNodeCount.Text);
            var listOfLetters = Methods.getAlphabet(nodeCount);

            for (int i = 0; i < nodeCount; i++)
            {
                CheckBox cb = new CheckBox();
                cb.Name = "rb" + listOfLetters[i];
                cb.Text = listOfLetters[i];
                cb.Checked = false;
                pnlFlowLayout.Controls.Add(cb);
            }

            pnlFlowLayout.Controls.Add(btnAddPipe);
            pnlFlowLayout.Show();
            pnlSelectPoints.Show();

            //Node oluştur
            listOfNodes = Methods.getNodeList(nodeCount);
            myGraph.Nodes = listOfNodes;
        }

        public void btnAddPipeClickEvent(object sender, EventArgs e)
        {
            var endPoints = new string[2];
            int flag = 0;
            foreach (var rb in pnlFlowLayout.Controls.OfType<CheckBox>())
            {
                if (rb.Checked && flag < 2)
                {
                    endPoints[flag] = rb.Text;
                    flag++;
                }
            }
            lblPipeName1.Text = endPoints[0];
            lblPipeName2.Text = endPoints[1];
            pnlPipeCapacity.Show();

        }

        private void tbxNodeCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnNodeCount_Click(null, null);
            }
        }

        private void InputControls_Load(object sender, EventArgs e)
        {
            pnlFlowLayout.Hide();
            pnlPipeCapacity.Hide();
            pnlSelectPoints.Hide();
        }

        private void btnPipeCapacity_Click(object sender, EventArgs e)
        {
            MyPipe pipe = new MyPipe();
            MyPipe pipe2 = new MyPipe();
            int capacity1;
            int capacity2;
            string name1;
            string name2;
            MyNode node1 = new MyNode();
            MyNode node2 = new MyNode();
            MyNode node = new MyNode();

            //Textbox boş ise
            if (String.IsNullOrEmpty(tbxPipe1Capacity.Text))
            {
                capacity1 = 0;
            }
            else
            {
                capacity1 = Int32.Parse(tbxPipe1Capacity.Text);
            }
            //Textbox boş ise
            if (String.IsNullOrEmpty(tbxPipe2Capacity.Text))
            {
                capacity2 = 0;
            }
            else
            {
                capacity2 = Int32.Parse(tbxPipe2Capacity.Text);
            }

            tbxPipe1Capacity.Text = string.Empty;
            tbxPipe2Capacity.Text = string.Empty;

            name1 = lblPipeName1.Text;
            name2 = lblPipeName2.Text;

            //baslangic
            if (capacity1 != 0)
            {
                pipe.StartingPoint = name1;
                pipe.EndPoint = name2;
                pipe.StartingValue = capacity1;
                node = listOfNodes.Where(x => x.Name == name1).FirstOrDefault();
                node.Pipes.Add(pipe);

                myGraph.Pipes.Add(pipe);
                myGraph.Nodes = listOfNodes;
            }
            else if (capacity2 != 0)
            {
                pipe.StartingPoint = name2;
                pipe.EndPoint = name1;
                pipe.StartingValue = capacity2;
                node = listOfNodes.Where(x => x.Name == name2).FirstOrDefault();
                node.Pipes.Add(pipe);

                myGraph.Pipes.Add(pipe);
                myGraph.Nodes = listOfNodes;
            }

            /*
            pipe.StartingPoint = name1;
            pipe.EndPoint = name2;

            pipe2.StartingPoint = name2;
            pipe2.EndPoint = name1;


            pipe.StartingValue = capacity1;
            pipe.EndingValue = capacity2;

            pipe2.StartingValue = capacity2;
            pipe2.EndingValue = capacity1;

            node1 = listOfNodes.Where(x => x.Name == name1).FirstOrDefault();
            node2 = listOfNodes.Where(x => x.Name == name2).FirstOrDefault();

            myGraph.Pipes.Add(pipe);
            myGraph.Nodes = listOfNodes;

            node1.Pipes.Add(pipe);
            
            node2.Pipes.Add(pipe2);
            */
            pnlPipeCapacity.Hide();
        }

        private void btnSelectPoints_Click(object sender, EventArgs e)
        {
            string start = tbxStartingPoint.Text.ToUpper();
            string end = tbxEndPoint.Text.ToUpper();
            var startNode = new MyNode(); 
            var endNode = new MyNode();

            foreach (var node in listOfNodes)
            {
                node.IsEndPoint = false;
                node.IsStartingPoint = false;
            }

            startNode = listOfNodes.Where(x => x.Name == start).FirstOrDefault();
            endNode = listOfNodes.Where(x => x.Name == end).FirstOrDefault();

            startNode.IsStartingPoint = true;
            endNode.IsEndPoint = true;
            myGraph.Nodes = listOfNodes;
        }

        public static List<MyNode> getListOfNodes()
        {
            return listOfNodes;
        }

        public static MyGraph getMyGraph()
        {
            return myGraph;
        }

        private void tbxPipe1Capacity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPipeCapacity_Click(null, null);
            }
        }

        private void tbxPipe2Capacity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPipeCapacity_Click(null, null);
            }
        }
    }
}
