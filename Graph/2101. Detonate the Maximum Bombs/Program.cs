using System;
using System.Collections.Generic;
using System.Linq;

namespace _2101._Detonate_the_Maximum_Bombs
{
    class Program
    {
        //(x1,y1); (x2,y2)= d=squroot( pow(x1-x2,2),pow(y1-y2,2))
        public int MaximumDetonation(int[][] bombs)
        {
            int n = bombs.Length;
            Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        continue;
                    int x1 = bombs[i][0];
                    int y1 = bombs[i][1];
                    int r1 = bombs[i][2];

                    int x2 = bombs[j][0];
                    int y2 = bombs[j][1];
                    int r2 = bombs[j][2];
                    double d = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));

                    if (r1 >= d)
                        if (adj.ContainsKey(i))
                            adj[i].Add(j);
                        else
                            adj.Add(i, new List<int> { j });
                }
            }
            int res = 0;
            List<bool> visited = new List<bool>(new bool[n]);

            for (int i = 0; i < n; i++)
            {
                DFS(adj, i, visited);

                int count = visited.Where(x => x == true).Count();
                res = Math.Max(res, count);
                visited = new List<bool>(new bool[n]);

            }

            return res;

        }
        private void DFS(Dictionary<int, List<int>> adj, int u, List<bool> visited)
        {
            if (visited[u])
                return;
            visited[u] = true;
            if (adj.ContainsKey(u))
                foreach (var v in adj[u])
                {
                    if (!visited[v])
                        DFS(adj, v, visited);
                }
        }

        //Input: bombs = [[2,1,3],[6,1,4]]
        //Output: 2
        //Explanation:
        //The above figure shows the positions and ranges of the 2 bombs.
        //If we detonate the left bomb, the right bomb will not be affected.
        //But if we detonate the right bomb, both bombs will be detonated.
        //So the maximum bombs that can be detonated is max(1, 2) = 2.
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.MaximumDetonation(new int[][] { new int[] { 2, 1, 3 }, new int[] { 6, 1, 4 } }));
            Console.WriteLine("Hello World!");
        }
    }
}
