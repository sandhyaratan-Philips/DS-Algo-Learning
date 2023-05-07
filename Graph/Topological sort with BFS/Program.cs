using System;
using System.Collections.Generic;

namespace Topological_sort_with_BFS
{
    class Program
    {
        public List<int> topoSort(int V, List<List<int>> adj)
        {
            List<int> inDegree = new List<int>(new int[V]);
            Queue<int> q = new Queue<int>();

            for (int u = 0; u < V; u++)
            {
                foreach (var v in adj[u])
                {
                    inDegree[v]++;
                }
            }

            for (int i = 0; i < V; i++)
            {
                if (inDegree[i] == 0)
                    q.Enqueue(i);
            }

            List<int> list = new List<int>();
            while (q.Count > 0)
            {
                int u = q.Dequeue();
                list.Add(u);
                foreach (var v in adj[u])
                {
                    inDegree[v]--;
                    if (inDegree[v] == 0)
                        q.Enqueue(v);
                }
            }

            return list;

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
