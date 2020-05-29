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

            MaxFlow maxFlow = new MaxFlow();
            for (int i = 0; i < tails.Count(); ++i)
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

        public static List<List<string>> getAllPaths(this MyGraph myGraph)
        {
            List<int> tails, heads, capacities;
            tails = myGraph.getTailList();
            heads = myGraph.getHeadList();
            capacities = myGraph.getCapacityList();

            int numNodes = myGraph.Nodes.Count();
            int numEdges = myGraph.Nodes.Count();

            GraphPath g = new GraphPath(numNodes);
            int source = Char.Parse(myGraph.getStartingPoint()) - 'A';
            int destination = Char.Parse(myGraph.getEndPoint()) - 'A';

            for (int i = 0; i < tails.Count(); i++)
            {
                g.addEdge(tails[i], heads[i]);
            }

            g.printAllPaths(source, destination);
            //g.allPathsStr.ForEach(Console.WriteLine);

            //"0" "1" "2" "4" 
            //"0" "1" "3" "4"
            List<List<int>> listOfSplittedPaths = new List<List<int>>();
            List<List<string>> listOfSplittedPathsStr = new List<List<string>>();
            foreach (var path in g.allPathsStr)
            {
                var splittedPathStr = new List<string>();
                var splittedPathInt = new List<int>();
                var splittedPathChr = new List<string>();

                splittedPathStr = path.Split(' ').ToList();
                splittedPathStr.ForEach(x => splittedPathChr.Add(((char)('A' + Int32.Parse(x))).ToString()));
                splittedPathStr.ForEach(x => splittedPathInt.Add(Int32.Parse(x)));

                listOfSplittedPaths.Add(splittedPathInt);
                listOfSplittedPathsStr.Add(splittedPathChr);
            }

            return listOfSplittedPathsStr;
        }

        public static List<int> getTailList(this MyGraph myGraph)
        {
            var tails = new List<int>();
            var pipes = myGraph.Pipes;
            var nodes = myGraph.Nodes;

            foreach (var node in nodes)
            {
                foreach (var pipe in node.Pipes)
                {
                    if (pipe.StartingValue > 0)
                    {
                        tails.Add(Char.Parse(pipe.StartingPoint) - 'A');
                    }
                }

            }
            return tails;
        }

        public static List<int> getHeadList(this MyGraph myGraph)
        {
            var heads = new List<int>();
            var pipes = myGraph.Pipes;
            var nodes = myGraph.Nodes;

            foreach (var node in nodes)
            {
                foreach (var pipe in node.Pipes)
                {
                    if (pipe.StartingValue > 0)
                    {
                        heads.Add(Char.Parse(pipe.EndPoint) - 'A');
                    }
                }

            }
            return heads;
        }

        public static List<int> getCapacityList(this MyGraph myGraph)
        {
            var capacities = new List<int>();
            var pipes = myGraph.Pipes;
            var nodes = myGraph.Nodes;

            foreach (var node in nodes)
            {
                foreach (var pipe in node.Pipes)
                {
                    if (pipe.StartingValue > 0)
                    {
                        capacities.Add(pipe.StartingValue);
                    }
                }

            }
            return capacities;
        }

        //path => {"A","B","C","E"}
        public static List<List<string>> getBinaryPaths(List<string> path)
        {
            //verilen path'teki pipe ları bul
            //var pipes = myGraph.Pipes;

            List<List<string>> binaryPaths = new List<List<string>>();

            for (int i = 0; i < path.Count() - 1; i++)
            {
                binaryPaths.Add(new List<string> { path[i], path[i + 1] });
            }

            return binaryPaths;
        }

        //path => "A" "B" "C" "E"
        public static int getMaxFlowOfPath(this MyGraph myGraph, List<string> path)
        {
            //verilen path'teki pipe ları bul
            //var pipes = myGraph.Pipes;
            //var maxFlow = 0;
            var pipeValueList = new List<int>();
            for (int i = 0; i < path.Count()-1; i++)
            {
                var node = myGraph.Nodes.Where(x => x.Name == path[i]).FirstOrDefault();
                var pipe = node.Pipes.Where(x => x.EndPoint == path[i + 1]).FirstOrDefault();
                var pipeValue = pipe.StartingValue;
                pipeValueList.Add(pipeValue);
            }

            return pipeValueList.Min();
        }
    }
}
