using System;
using System.Collections.Generic;

namespace _802._Find_Eventual_Safe_States
{
    class Program
    {
        public IList<int> EventualSafeNodes(int[][] graph)
        {
            int V = graph.Length;
            List<int> res = new List<int>();
            List<int> inDegree = new List<int>(new int[V]);
            Queue<int> q = new Queue<int>();
            List<List<int>> adj = new List<List<int>>();

            for (int i = 0; i < V; i++)
            {
                adj.Add(new List<int>());
            }

            for (int u = 0; u < V; u++)
            {
                foreach (var node in graph[u])
                {
                    adj[node].Add(u);

                    inDegree[u]++;
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
                res.Add(u);
                foreach (var v in adj[u])
                {
                    inDegree[v]--;
                    if (inDegree[v] == 0)
                        q.Enqueue(v);
                }
            }
            res.Sort();
            return res;
        }



        static void Main(string[] args)
        {
            Program program = new Program();
            program.EventualSafeNodes(new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 5 }, new int[] { 0 }, new int[] { 5 }, new int[] { }, new int[] { } });
            Console.WriteLine("Hello World!");
        }
    }
}
