using System;
using System.Collections.Generic;

namespace Detect_cycle_in_a_directed_graph_with_BFS
{
    class Program
    {
        public bool isCyclic(int V, List<List<int>> adj)
        {
            Queue<int> q = new Queue<int>();
            int nodeCount = 1;

            List<int> inDegree = new List<int>(new int[V]);

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

            while (q.Count > 0)
            {
                int u = q.Dequeue();
                foreach (var v in adj[u])
                {
                    inDegree[v]--;
                    if (inDegree[v] == 0)
                    {
                        q.Enqueue(v);
                        nodeCount++;
                    }
                }
            }



            return !(nodeCount == V);
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
