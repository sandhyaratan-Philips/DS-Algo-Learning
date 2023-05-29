using System.Collections.Generic;

namespace Shortest_path_using_bfs
{
    class Program
    {
        List<int> shortestPath(List<List<int>> adj, int V)
        {
            Queue<int> q = new Queue<int>();

            List<bool> visited = new List<bool>(new bool[V]);
            List<int> dist = new List<int>(new int[V]);
            q.Enqueue(0);
            visited[0] = true;

            while (q.Count > 0)
            {
                int u = q.Dequeue();
                foreach (var v in adj[u])
                {
                    if (!visited[v])
                    {
                        q.Enqueue(v);
                        visited[v] = true;
                        dist[v] = dist[u] + 1;
                    }
                }
            }
            return dist;
        }

        static void Main(string[] args)
        {
            List<List<int>> adj = new List<List<int>>();
            adj.Add(new List<int> { 1, 2 });
            adj.Add(new List<int> { 2, 3 });
            adj.Add(new List<int> { 3 });
            adj.Add(new List<int> { });
            Program p = new Program();
            p.shortestPath(adj, 4);
            //Console.WriteLine();
        }
    }
}
