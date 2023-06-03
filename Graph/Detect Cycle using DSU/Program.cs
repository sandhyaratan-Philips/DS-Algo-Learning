using System;
using System.Collections.Generic;

namespace Detect_Cycle_using_DSU
{
    class Program
    {
        List<int> parent;
        List<int> rank;
        public int detectCycle(int V, List<List<int>> adj)
        {
            parent = new List<int>();
            rank = new List<int>();
            for (int i = 0; i < V; i++)
            {
                rank.Add(0);
                parent.Add(i);
            }

            for (int u = 0; u < V; u++)
            {
                foreach (var v in adj[u])
                {
                    if (u < v)
                    {
                        int u_parent = find(u);
                        int v_parent = find(v);

                        if (u_parent == v_parent)
                            return 1;
                        union(u, v);
                    }
                }
            }
            return 0;
        }
        void union(int x, int y)
        {
            int x_parent = find(x);
            int y_parent = find(y);
            if (x_parent == y_parent)
            {
                return;
            }
            else if (rank[x_parent] > rank[y_parent])
            {
                parent[y_parent] = x_parent;
            }
            else if (rank[y_parent] > rank[x_parent])
            {
                parent[x_parent] = y_parent;
            }
            else
            {
                parent[x_parent] = y_parent;
                rank[y_parent]++;
            }
        }

        private int find(int x)
        {
            if (x == parent[x])
                return x;
            return parent[x] = find(parent[x]);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            List<List<int>> adj = new List<List<int>>();
            adj.Add(new List<int> { 3, 2, 4 });
            adj.Add(new List<int> { 3 });
            adj.Add(new List<int> { 4, 0 });
            adj.Add(new List<int> { 0, 1 });
            adj.Add(new List<int> { 0, 2 });

            Console.WriteLine(program.detectCycle(5, adj));
        }
    }
}
