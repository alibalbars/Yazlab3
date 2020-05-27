using Google.OrTools.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Yazlab3.GraphElements;

namespace Yazlab3
{
    static class Methods
    {
        public static void AddNodes(this MyGraph graph, List<MyNode> listOfNodes)
        {
            
        }

        public static List<MyNode> getNodeList(int count)
        {
            if (count < 1)
            {
                return null;
            }

            var listOfNodes = new List<MyNode>();
            var listOfLetters = getAlphabet(count);
            for (int i = 0; i < count; i++)
            {
                var node = new MyNode();
                node.Name = listOfLetters[i];
                listOfNodes.Add(node);
            }
            return listOfNodes;
        }

        public static List<string> getAlphabet(int count)
        {
            int asciiNumber = 65;
            var listOfLetters = new List<string>();

            for (int i = 0; i < count; i++)
            {
                listOfLetters.Add(((char)asciiNumber).ToString());
                asciiNumber++;
            }

            return listOfLetters;
        }

        public static void findAvailablePaths(this MyGraph myGraph)
        {

        }

        public static List<MyPipe> GetPipesByNodeName(this MyGraph myGraph, string name)
        {
            var pipeList = new List<MyPipe>();
            MyNode mynode = myGraph.Nodes.Where(x => x.Name == name)
                .FirstOrDefault();

            return mynode.Pipes;
        }

        public static string getStartingPoint(this MyGraph myGraph)
        {
            string startingPoint;

            try
            {
                startingPoint = myGraph.Nodes.Where(x => x.IsStartingPoint == true)
               .FirstOrDefault().Name;
            }
            catch (Exception)
            {
                startingPoint = "A";
            }
            

            return startingPoint;
        }

        public static string getEndPoint(this MyGraph myGraph)
        {
            string endPoint;

            try
            {
                endPoint = myGraph.Nodes.Where(x => x.IsEndPoint == true)
               .FirstOrDefault().Name;
            }
            catch (Exception)
            {
                endPoint = myGraph.Nodes[myGraph.Nodes.Count() - 1].Name;
            }
            

            return endPoint;
        }

        public static long getMaxFlow(this MyGraph myGraph)
        {
            long totalFlow;
            var pipes = myGraph.Pipes;
            var nodes = myGraph.Nodes;

            int numNodes = nodes.Count();
            int numPipes = pipes.Count();

            char startingPoint = Char.Parse(myGraph.getStartingPoint());
            char endPoint = Char.Parse(myGraph.getEndPoint());

            //int[] tails = new int[numPipes];
            //int[] heads = new int[numPipes];
            //int[] capacities = new int[numPipes];

            List<int> tails, heads, capacities;
            tails = new List<int>();
            heads = new List<int>();
            capacities = new List<int>();

            foreach (var node in nodes)
            {
                foreach (var pipe in node.Pipes)
                {
                    if (pipe.StartingValue > 0)
                    {
                        tails.Add(Char.Parse(pipe.StartingPoint) - 'A');
                        heads.Add(Char.Parse(pipe.EndPoint) - 'A');
                        capacities.Add(pipe.StartingValue);
                    }
                }
                
            }

            //foreach(var pipe in pipes)
            //{
            //    if (pipe.StartingValue != 0)
            //    {
            //        tails.Add = pipe.StartingNode.Name
            //    }
            //    else if(pipe.EndingValue != 0)
            //    {
                    
            //    }
            //}
            

            MaxFlow maxFlow = new MaxFlow();
            for (int i = 0; i < numPipes; ++i)
            {
                int arc = maxFlow.AddArcWithCapacity(tails[i], heads[i], capacities[i]);
                if (arc != i) throw new Exception("Internal error");
            }
            int source = startingPoint - 'A';
            int sink = endPoint - 'A';
            Console.WriteLine("Solving max flow with " + numNodes + " nodes, and " +
                              numPipes + " arcs, source=" + source + ", sink=" + sink);
            MaxFlow.Status solveStatus = maxFlow.Solve(source, sink);
            if (solveStatus == MaxFlow.Status.OPTIMAL)
            {
                totalFlow = maxFlow.OptimalFlow();
            }
            else
            {
                Console.WriteLine("Solving the max flow problem failed. Solver status: " +
                                  solveStatus);
                totalFlow = 0;
            }

            return totalFlow;

        }
    }
}
