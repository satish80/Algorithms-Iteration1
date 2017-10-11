using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = CreateGraph();
            //InvokeKruskalMST();
            #region DFS
            DFSGraph g = new DFSGraph(4);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            
            DFSInGraph obj = new DFSInGraph();
            obj.DoDFS(g);

            #endregion

            Console.Read();
        }
        

        private static Graph CreateGraph()
        {
            Edge edge1 = new Edge()
            {
                Source = (int)0,
                Destination = (int)1,
                Weight = 10
            };
            Edge edge2 = new Edge()
            {
                Source = (int)0,
                Destination = (int)2,
                Weight = 6
            };
            Edge edge3 = new Edge()
            {
                Source = (int)0,
                Destination = (int)3,
                Weight = 5
            };
            Edge edge4 = new Edge()
            {
                Source = (int)1,
                Destination = (int)3,
                Weight = 15
            };
            Edge edge5 = new Edge()
            {
                Source = (int)2,
                Destination = (int)3,
                Weight = 4
            };

            Graph givenGraph = new Graph();
            Edge[] givenEdgList = new Edge[] { edge5, edge3, edge2, edge1, edge4 };

            givenGraph.Edges = givenEdgList;

            return givenGraph;
        }

        #region Kruskal MST
        private static void InvokeKruskalMST()
        {
            Graph mst = ConstructMST(CreateGraph());

            for (int idx = 0; idx < mst.Edges.Length; idx++)
            {
                Console.WriteLine("{0} {1}", mst.Edges[idx].Source, mst.Edges[idx].Destination);
            }

        }
        private static Graph ConstructMST(Graph givenGraph)
        {
            int mstIdx = 0;
            Graph MST = new Graph();
            Edge[] mstEdgeList = new Edge[givenGraph.Edges.Length];

            mstEdgeList[mstIdx] = givenGraph.Edges[0];
            MST.Edges = mstEdgeList;

            for (int idx = 1; idx < givenGraph.Edges.Length; idx++)
            {
                if (!CheckCycle(MST, givenGraph.Edges[idx]))
                {
                    mstEdgeList[++mstIdx] = givenGraph.Edges[idx];
                }
            }

            return MST; 
        }

        private static bool CheckCycle(Graph MST, Edge edgeForIncl)
        {
            Edge[] edgeList = MST.Edges;

            for (int idx = 0; idx < edgeList.Length; idx++)
            {
                if (edgeForIncl.Source == edgeList[idx].Source)
                {
                    for (int destIdx = 0; destIdx < edgeList.Length; destIdx++)
                    {
                        if (edgeForIncl.Destination == edgeList[destIdx].Source)
                            if (edgeList[idx].Destination == edgeList[destIdx].Destination)
                                return true;
                    }
                }
                else if (edgeForIncl.Source == edgeList[idx].Destination)
                {
                    for (int destIdx = 0; destIdx < edgeList.Length; destIdx++)
                    {
                        if (edgeForIncl.Destination == edgeList[destIdx].Destination)
                            if (edgeList[idx].Source == edgeList[destIdx].Source)
                                return true;
                    }
                }
            }
            return false;
        }
    }

    public struct Graph
    {
        public Edge[] Edges;
    }

    public struct Edge
    {
        public int? Source;
        public int? Destination;
        public int Weight;
    }
        #endregion Kruskal MST

    public class DFSGraph
    {
        //No of vertices
        public int V;

        public Dictionary<int,List<int>> AdjList;

        public DFSGraph(int V)
        {
            this.V = V;
            AdjList = new Dictionary<int, List<int>>(V);
        }

        public void AddEdge(int vertex, int w)
        {
            if (AdjList.Count == 0)
            {
                List<int> list = new List<int>();
                list.Add(w);

                AdjList.Add(vertex, list);
            }
            else if (! AdjList.ContainsKey(vertex))
            {                
                List<int> list = new List<int>();
                list.Add(w);

                AdjList.Add(vertex,list);
            }
            else
                AdjList[vertex].Add(w);
        }
    }
}