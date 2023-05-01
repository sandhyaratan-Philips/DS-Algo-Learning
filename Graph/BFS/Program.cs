using System;
using System.Collections.Generic;

namespace BFS
{
    class Program
    {
        List<int> bfsOfGraph(int V, List<List<int>> adj)
        {
            List<bool> visited = new List<bool>();
            List<int> ans = new List<int>();

            for (int i = 0; i < V; i++)
            {
                visited.Add(false);
            }

            bfs(0, adj, visited, ans);
            return ans;
        }

        private void bfs(int u, List<List<int>> adj, List<bool> visited, List<int> ans)
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(u);
            visited[u] = true;
            ans.Add(u);
            while (queue.Count > 0)
            {
                int a = queue.Dequeue();
                foreach (var v in adj[a])
                {
                    if (!visited[v])
                    {
                        queue.Enqueue(v);
                        visited[v] = true;
                        ans.Add(v);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            List<List<int>> adj = new List<List<int>>();
            //V = 5 , adj = [[1,2,3] , [], [4], [], []]
            adj.Add(new List<int> { 1, 2, 3 });
            adj.Add(new List<int> { });
            adj.Add(new List<int> { 4 });
            adj.Add(new List<int> { });
            adj.Add(new List<int> { });

            Program program = new Program();
            program.bfsOfGraph(5, adj);


            Console.WriteLine("Hello World!");
        }
    }
}
