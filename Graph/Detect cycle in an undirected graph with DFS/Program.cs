using System;
using System.Collections.Generic;

namespace Detect_cycle_in_an_undirected_graph_with_DFS
{
    class Program
    {
        public
    bool isCycle(int V, List<List<int>> adj)
        {
            List<bool> visited = new List<bool>();
            for (int i = 0; i < V; i++)
            {
                visited.Add(false);
            }
            for (int i = 0; i < V; i++)
            {
                if (!visited[i] && isCycleDFS(adj, i, visited, -1))
                    return true;
            }
            return false;
        }

        private bool isCycleDFS(List<List<int>> adj, int u, List<bool> visited, int parent)
        {
            visited[u] = true;

            foreach (var v in adj[u])
            {
                if (v == parent)
                    continue;
                if (visited[v])
                    return true;
                if (isCycleDFS(adj, v, visited, u))
                    return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            List<List<int>> adj = new List<List<int>>();
            //V = 4, E = 2
            //adj = { { }, { 2}, { 1, 3}, { 2} }
            adj.Add(new List<int> { });
            adj.Add(new List<int> { 2 });
            adj.Add(new List<int> { 1, 3 });
            adj.Add(new List<int> { 2 });

            Program program = new Program();
            program.isCycle(4, adj);
            Console.WriteLine("Hello World!");
        }
    }
}
