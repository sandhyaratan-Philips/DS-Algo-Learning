using System;
using System.Collections.Generic;

namespace Bipartite_Graph
{

    class Program
    {
        bool isBipartite(int V, List<List<int>> adj)
        {
            List<int> colour = new List<int>();
            for (int i = 0; i < V; i++)
            {
                colour.Add(-1);
            }

            for (int i = 0; i < V; i++)
            {
                if (colour[i] == -1)
                    if (!DFS(adj, i, colour, 1))
                        return false;
            }
            return true;

        }

        private bool DFS(List<List<int>> adj, int u, List<int> colour, int c)
        {
            colour[u] = c;
            foreach (var v in adj[u])
            {
                if (colour[v] == colour[u])
                    return false;
                if (colour[v] == -1)
                {
                    if (!DFS(adj, v, colour, 1 - c))
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            List<List<int>> adj = new List<List<int>>();

            //adj.Add(new List<int> { 2, 3 });
            //adj.Add(new List<int> { 3 });
            //adj.Add(new List<int> { 0, 3 });
            //adj.Add(new List<int> { 0, 2, 1 });

            adj.Add(new List<int> { 1, 2 });
            adj.Add(new List<int> { 0 });
            adj.Add(new List<int> { 0 });



            Console.WriteLine(program.isBipartite(3, adj));
        }
    }
}
