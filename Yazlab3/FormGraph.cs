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
using Microsoft.Msagl.Drawing;

namespace Yazlab3
{
    public partial class FormGraph : Form
    {
        List<MyNode> listOfNodes;
        MyGraph myGraph;
        public FormGraph()
        {
            InitializeComponent();
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

            //listOfNodes = InputControls.getListOfNodes();
            myGraph = InputControls.getMyGraph();
            var nodeList = new List<Node>();
            foreach (var myNode in myGraph.Nodes)
            {
                graph.AddNode(new Node(myNode.Name));
            }

            foreach (var myPipe in myGraph.Pipes)
            {
                if (myPipe.StartingValue != 0)
                {
                    graph.AddEdge(myPipe.StartingPoint, myPipe.StartingValue.ToString() , myPipe.EndPoint);
                }
                if (myPipe.EndingValue != 0)
                {
                    graph.AddEdge(myPipe.EndPoint, myPipe.EndingValue.ToString(), myPipe.StartingPoint);
                }
            }

            string startingPointName = myGraph.Nodes.Where(x => x.IsStartingPoint == true)
                .Select(x => x.Name).FirstOrDefault();

            string endPointName = myGraph.Nodes.Where(x => x.IsEndPoint == true)
                .Select(x => x.Name).FirstOrDefault();

            if (startingPointName != null && endPointName != null)
            {
                graph.FindNode(startingPointName).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
                graph.FindNode(startingPointName).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                graph.FindNode(endPointName).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                graph.FindNode(endPointName).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
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

        //maxFlowPath => { "A", "B", "C", "E" }
        public FormGraph(List<string> maxFlowPath, bool isMaxFlowPath)
        {
            List<string[]> binaryList = new List<string[]>();
            InitializeComponent();
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

            //listOfNodes = InputControls.getListOfNodes();
            myGraph = InputControls.getMyGraph();
            var nodeList = new List<Node>();

            //node ekle
            foreach (var myNode in myGraph.Nodes)
            {
                graph.AddNode(new Node(myNode.Name));
            }

            List<List<string>> binaryPaths = new List<List<string>>();
            
            for (int i = 0; i < maxFlowPath.Count() - 1; i++)
            {
                binaryPaths.Add(new List<string> { maxFlowPath[i] , maxFlowPath[i + 1]});
            }

            //edge ekle
            foreach (var myPipe in myGraph.Pipes)
            {
                if (myPipe.StartingValue != 0)
                {
                    if (IsOnThePath(myPipe, binaryPaths))
                    {
                        if (isMaxFlowPath)
                        {
                            graph.AddEdge(myPipe.StartingPoint, myPipe.StartingValue.ToString(),
                                myPipe.EndPoint).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                        }
                        else
                        {
                            graph.AddEdge(myPipe.StartingPoint, myPipe.StartingValue.ToString(),
                                myPipe.EndPoint).Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                        }
                        

                    }
                    else
                    {
                        graph.AddEdge(myPipe.StartingPoint, myPipe.StartingValue.ToString(), myPipe.EndPoint);

                    }

                }

                if (myPipe.EndingValue != 0)
                {
                    if (IsOnThePath(myPipe, binaryPaths))
                    {
                        if (isMaxFlowPath)
                        {
                            graph.AddEdge(myPipe.EndPoint, myPipe.EndingValue.ToString(),
                            myPipe.StartingPoint).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                        }
                        else
                        {
                            graph.AddEdge(myPipe.EndPoint, myPipe.EndingValue.ToString(),
                            myPipe.StartingPoint).Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                        }
                        
                        
                    }
                    else
                    {
                        graph.AddEdge(myPipe.EndPoint, myPipe.EndingValue.ToString(), myPipe.StartingPoint);
                    }
                }
            }

            string startingPointName = myGraph.Nodes.Where(x => x.IsStartingPoint == true)
                .Select(x => x.Name).FirstOrDefault();

            string endPointName = myGraph.Nodes.Where(x => x.IsEndPoint == true)
                .Select(x => x.Name).FirstOrDefault();

            if (startingPointName != null && endPointName != null)
            {
                graph.FindNode(startingPointName).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
                graph.FindNode(startingPointName).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                graph.FindNode(endPointName).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                graph.FindNode(endPointName).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
            }

            viewer.Graph = graph;
            this.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(viewer);
            this.ResumeLayout();
        }

        private bool IsOnThePath(MyPipe pipe, List<List<string>> binaryPaths)
        {
            foreach (var binaryPath in binaryPaths)
            {
                if (pipe.StartingPoint == binaryPath[0] && pipe.EndPoint == binaryPath[1])
                {
                    return true;
                }
            }
            return false;
        }

        private void FormGraph_Load(object sender, EventArgs e)
        {

        }
    }
}
