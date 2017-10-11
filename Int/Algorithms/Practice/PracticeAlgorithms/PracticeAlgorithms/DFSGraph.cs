using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithms
{
    public class DFSGraph
    {
        public Dictionary<int, List<int>> AdjList;
        public int Vertex;
        public Dictionary<int, bool> Visited;

        public DFSGraph(int Vertex)
        {
            this.Vertex = Vertex;
            AdjList = new Dictionary<int, List<int>>(Vertex);
            Visited = new Dictionary<int, bool>(Vertex);
        }

        public void AddEdge(int Vertex, int Weight)
        {
            if(AdjList.Count == 0 || !AdjList.ContainsKey(Vertex))
            {
                AdjList.Add(Vertex, new List<int>(Weight));
            }
            else if(AdjList.ContainsKey(Vertex))
            {
                AdjList[Vertex].Add(Weight);
            }
        }

        public void TraverseGraph(DFSGraph graph)
        {
            for(int i=0; i < graph.AdjList.Count -1; i++)
            {
                if(!Visited.ContainsKey(i))
                {
                    DFSGraphTraverse(graph, i);
                }

            }
        }

        private void DFSGraphTraverse(DFSGraph graph, int Vertex)
        {
            Visited[Vertex] = true;

            List<int> adjList = graph.AdjList[Vertex];

            for(int i= 0; i < adjList.Count; i++)
            {
                if(! Visited.ContainsKey(adjList[i]) && ! Visited[adjList[i]])
                {
                    DFSGraphTraverse(graph, adjList[i]);
                }
            }
        }
    }
}
