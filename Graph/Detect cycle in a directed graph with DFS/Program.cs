using System;
using System.Collections.Generic;

namespace Detect_cycle_in_a_directed_graph_with_DFS
{
    class Program
    {
        public bool isCyclic(int V, List<List<int>> adj)
        {
            List<bool> visited = new List<bool>(new bool[V]);
            List<bool> inRecursion = new List<bool>(new bool[V]);

            for (int i = 0; i < V; i++)
            {
                if (!visited[i] && isCyclicDFS(adj, i, visited, inRecursion))
                {
                    return true;
                }
            }
            return false;
        }

        private bool isCyclicDFS(List<List<int>> adj, int u, List<bool> visited, List<bool> currentRecursion)
        {
            visited[u] = true;
            currentRecursion[u] = true;

            foreach (var v in adj[u])
            {
                if (!visited[v] && isCyclicDFS(adj, v, visited, currentRecursion))
                    return true;
                else if (currentRecursion[v])
                    return true;
            }
            currentRecursion[u] = false;
            return false;
        }

        static void Main(string[] args)
        {
            List<List<int>> adj = new List<List<int>>();
            //V = 4
            //adj = { {1 }, { 2}, { 3}, { 3} }
            adj.Add(new List<int> { 1 });
            adj.Add(new List<int> { 2 });
            adj.Add(new List<int> { 3 });
            adj.Add(new List<int> { 1 });

            Program program = new Program();

            Console.WriteLine(program.isCyclic(4, adj));
        }
    }
}
