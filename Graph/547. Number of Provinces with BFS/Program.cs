using System;
using System.Collections.Generic;

namespace _547._Number_of_Provinces_with_BFS
{
    //Input: isConnected = [[1,1,0],[1,1,0],[0,0,1]]
    //Output: 2
    class Program
    {
        public int FindCircleNum(int[][] isConnected)
        {
            int V = isConnected.Length;
            List<List<int>> adj = new List<List<int>>();
            List<bool> visited = new List<bool>(new bool[V]);
            int count = 0;

            for (int i = 0; i < V; i++)
            {
                adj.Add(new List<int>());
                for (int j = 0; j < V; j++)
                {
                    if (i != j && isConnected[i][j] == 1)
                        adj[i].Add(j);
                }
            }

            for (int u = 0; u < V; u++)
            {
                if (!visited[u])
                {
                    BFS(adj, u, visited);
                    count++;
                }
            }
            return count;
        }

        private void BFS(List<List<int>> adj, int u, List<bool> visited)
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(u);
            visited[u] = true;

            while (queue.Count > 0)
            {
                int a = queue.Dequeue();
                foreach (var v in adj[a])
                {
                    if (!visited[v])
                    {
                        queue.Enqueue(v);
                        visited[v] = true;

                    }
                }
            }

        }

        static void Main(string[] args)
        {


            Program program = new Program();
            Console.WriteLine(program.FindCircleNum(new int[][] { new int[] { 1, 1, 0 }, new int[] { 1, 1, 0 }, new int[] { 0, 0, 1 } }));

            Console.WriteLine("Hello World!");
        }
    }
}
