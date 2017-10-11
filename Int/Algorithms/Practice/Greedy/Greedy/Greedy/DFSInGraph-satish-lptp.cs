using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public class DFSInGraph
    {
        List<int> Parent = new List<int>();
        Dictionary<int, bool> visited ;

        public void DoDFS(DFSGraph graph)
        {
            visited = new Dictionary<int, bool>(graph.V);
            DFS(graph);
        }

        private void DFS(DFSGraph graph)
        {
            for (int idx = 0; idx < graph.V; idx++)
            {                     
                if (visited.Count == 0 || !visited[idx])
                {
                    //visited[idx] = true;
                    DFS_Visit(idx,graph);
                }
            }
        }

        private void DFS_Visit(int V, DFSGraph graph)
        {
            List<int> adjList = graph.AdjList[V];

            visited[V] = true;

            for (int idx = 0; idx < adjList.Count; idx++)
            {
                if (!visited.ContainsKey(adjList[idx]) || !(visited[adjList[idx]]))
                    DFS_Visit(adjList[idx], graph);
            }
        }
    }
}
