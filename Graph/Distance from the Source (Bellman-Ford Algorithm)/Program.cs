using System;

namespace Distance_from_the_Source__Bellman_Ford_Algorithm_
{
    class Program
    {
        int[] bellman_ford(int V, int[][] edges, int S)
        {
            int[] res = new int[V];
            Array.Fill(res, int.MaxValue);
            res[S] = 0;

            for (int i = 0; i <= V - 1; i++)
            {
                foreach (var e in edges)
                {
                    int u = e[0];
                    int v = e[1];
                    int w = e[2];

                    if (res[u] != int.MaxValue && w + res[u] < res[v])
                    {
                        res[v] = w + res[u];
                    }
                }
            }
            foreach (var e in edges)
            {
                int u = e[0];
                int v = e[1];
                int w = e[2];

                if (res[u] != int.MaxValue && w + res[u] < res[v])
                {
                    return new int[] { -1 };
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.bellman_ford(4, new int[][] { new int[] { 0, 1, 5 }, new int[] { 1, 0, 3 }, new int[] { 1, 2, -1 }, new int[] { 2, 0, 1 } }, 2);
            Console.WriteLine("Hello World!");
        }
    }
}
