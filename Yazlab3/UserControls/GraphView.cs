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
using Microsoft.Msagl.Drawing;

namespace Yazlab3.UserControls
{
    partial class GraphView : UserControl
    {
        List<MyNode> listOfNodes;
        MyGraph myGraph;
        public GraphView()
        {
            //this.Update();
            //this.Controls.Clear();
            InitializeComponent();
            
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

            listOfNodes = InputControls.getListOfNodes();
            myGraph = InputControls.getMyGraph();
            //foreach (var pipe in myGraph.Pipes)
            //{
            //    graph.AddEdge(pipe.StartingPoint, pipe.EndPoint);
            //}
            var nodeList = new List<Node>();
            foreach (var myNode in listOfNodes)
            {
                graph.AddNode(new Node(myNode.Name));
            }
            //Microsoft.Msagl.Drawing.Node node = new Microsoft.Msagl.Drawing.Node("a");
            
            //graph.AddEdge("Ali", "Veli");

            //graph.AddEdge("B", "C");
            //graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            //graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            //graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            //Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            //c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            //c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            viewer.Graph = graph;
            this.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(viewer);
            this.ResumeLayout();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
