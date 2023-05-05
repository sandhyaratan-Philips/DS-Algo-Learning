using System;
using System.Collections.Generic;

namespace Topological_sort_with_DFS
{
    class Program
    {
        public List<int> topoSort(int V, List<List<int>> adj)
        {
            List<bool> visited = new List<bool>(new bool[V]);
            Stack<int> stack = new Stack<int>();
            List<int> list = new List<int>();
            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                {
                    DFS(adj, i, visited, stack);
                }
            }
            while (stack.Count > 0)
            {
                list.Add(stack.Pop());
            }


            return list;
        }

        private void DFS(List<List<int>> adj, int u, List<bool> visited, Stack<int> stack)
        {
            visited[u] = true;
            foreach (var v in adj[u])
            {
                if (!visited[v])
                {
                    DFS(adj, v, visited, stack);
                }
            }
            stack.Push(u);
        }

        static void Main(string[] args)
        {
            List<List<int>> adj = new List<List<int>>();
            //V = 4

            adj.Add(new List<int> { });
            adj.Add(new List<int> { 3 });
            adj.Add(new List<int> { 3 });
            adj.Add(new List<int> { });
            adj.Add(new List<int> { 0, 1 });
            adj.Add(new List<int> { 0, 2 });

            Program program = new Program();

            Console.WriteLine(program.topoSort(6, adj));
        }
    }
}
