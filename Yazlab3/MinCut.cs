using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yazlab3.GraphElements;

namespace Yazlab3
{
    class MinCut
    {

        // Returns true if there is a path 
        // from source 's' to sink 't' in residual  
        // graph. Also fills parent[] to store the path  
        private static bool bfs(int[,] rGraph, int s,
                                int t, int[] parent)
        {

            // Create a visited array and mark  
            // all vertices as not visited      
            bool[] visited = new bool[rGraph.Length];

            // Create a queue, enqueue source vertex 
            // and mark source vertex as visited      
            Queue<int> q = new Queue<int>();
            q.Enqueue(s);
            visited[s] = true;
            parent[s] = -1;

            // Standard BFS Loop      
            while (q.Count != 0)
            {
                int v = q.Dequeue();
                for (int i = 0; i < rGraph.GetLength(0); i++)
                {
                    if (rGraph[v, i] > 0 && !visited[i])
                    {
                        q.Enqueue(i);
                        visited[i] = true;
                        parent[i] = v;
                    }
                }
            }

            // If we reached sink in BFS starting  
            // from source, then return true, else false      
            return (visited[t] == true);
        }

        // A DFS based function to find all reachable  
        // vertices from s. The function marks visited[i]  
        // as true if i is reachable from s. The initial  
        // values in visited[] must be false. We can also  
        // use BFS to find reachable vertices 
        private static void dfs(int[,] rGraph, int s,
                                bool[] visited)
        {
            visited[s] = true;
            for (int i = 0; i < rGraph.GetLength(0); i++)
            {
                if (rGraph[s, i] > 0 && !visited[i])
                {
                    dfs(rGraph, i, visited);
                }
            }
        }

        // Prints the minimum s-t cut 
        public static int[,] minCut(int[,] graph, int s, int t)
        {
            int u, v;
            List<List<int>> list = new List<List<int>>();
            

            // Create a residual graph and fill the residual  
            // graph with given capacities in the original  
            // graph as residual capacities in residual graph 
            // rGraph[i,j] indicates residual capacity of edge i-j 
            int[,] rGraph = new int[graph.Length, graph.Length];
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    rGraph[i, j] = graph[i, j];
                }
            }

            // This array is filled by BFS and to store path 
            int[] parent = new int[graph.Length];

            // Augment the flow while there is path 
            // from source to sink      
            while (bfs(rGraph, s, t, parent))
            {

                // Find minimum residual capacity of the edhes  
                // along the path filled by BFS. Or we can say  
                // find the maximum flow through the path found. 
                int pathFlow = int.MaxValue;
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    pathFlow = Math.Min(pathFlow, rGraph[u, v]);
                }

                // update residual capacities of the edges and  
                // reverse edges along the path 
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    rGraph[u, v] = rGraph[u, v] - pathFlow;
                    rGraph[v, u] = rGraph[v, u] + pathFlow;
                }
            }

            // Flow is maximum now, find vertices reachable from s      
            bool[] isVisited = new bool[graph.Length];
            dfs(rGraph, s, isVisited);

            // Print all edges that are from a reachable vertex to 
            // non-reachable vertex in the original graph      
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (graph[i, j] > 0 &&
                        isVisited[i] && !isVisited[j])
                    {
                        //Console.WriteLine(i + " - " + j);
                        list.Add(new List<int> { i, j });
                    }
                }
            }
            int[,] array = new int[list.Count(), 2];

            int k = 0;
            foreach (var item in list)
            {
                array[k, 0] = item[0];
                array[k, 1] = item[1];
                k++;
            }

            return array;
        }

        public static int[,] getMatrixOfGraph(MyGraph myGraph)
        {
            bool flag = false;
            int nodeCount = myGraph.Nodes.Count();
            int[,] graphMatrix = new int[nodeCount, nodeCount];

            for (int i = 0; i < nodeCount; i++)
            {
                var currentNodeName = getNodeName(i);
                var node = myGraph.Nodes.Where(x => x.Name == currentNodeName).FirstOrDefault();
                var pipeEndPoints = getPipeEndPoints(node.Pipes);

                for (int j = 0; j < nodeCount; j++)
                {
                    //j ninci node
                    var neighborNodeName = getNodeName(j);

                    if (pipeEndPoints.Contains(neighborNodeName))
                    {
                        var pipe = node.Pipes.Where(x => x.StartingPoint == node.Name &&
                        x.EndPoint == neighborNodeName).FirstOrDefault();

                        graphMatrix[i, j] = pipe.StartingValue;
                    }
                    else
                    {
                        graphMatrix[i, j] = 0;
                    }


                    //foreach (var pipe in node.Pipes)
                    //{
                    //    if (pipe.EndPoint == neighborNodeName)
                    //    {
                    //        //graphMatrix[i, j] = 1;
                    //        flag = true;
                    //        //break;
                    //    }
                    //    else
                    //    {
                    //        //graphMatrix[i, j] = 0;
                    //        flag = false;
                    //    }

                    //    if (flag)
                    //    {
                    //        graphMatrix[i, j] = pipe.StartingValue;
                    //    }
                    //    else
                    //    {
                    //        graphMatrix[i, j] = 0;
                    //    }

                    //}

                }
                //flag = false;
            }
            return graphMatrix;
        }

        public static int getNodeNum(string name)
        {
            return Char.Parse(name) - 'A';
        }

        public static string getNodeName(int num)
        {
            return ((char)('A' + num)).ToString();
        }

        private static List<string> getPipeEndPoints(List<MyPipe> pipes)
        {
            List<string> pipeEndPoints = new List<string>();
            foreach (var item in pipes)
            {
                pipeEndPoints.Add(item.EndPoint);
            }
            return pipeEndPoints;
        }

    }
}
