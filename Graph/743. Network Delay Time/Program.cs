using System;
using System.Collections.Generic;

namespace _743._Network_Delay_Time
{
    class Program
    {
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            Dictionary<int, List<KeyValuePair<int, int>>> adj = new Dictionary<int, List<KeyValuePair<int, int>>>();

            foreach (var item in times)
            {
                int u = item[0];
                int v = item[1];
                int w = item[2];

                if (!adj.ContainsKey(u))
                    adj.Add(u, new List<KeyValuePair<int, int>>());
                adj[u].Add(new KeyValuePair<int, int>(v, w));
            }

            SortedSet<KeyValuePair<int, int>> set = new SortedSet<KeyValuePair<int, int>>(Comparer<KeyValuePair<int, int>>.Create((x, y) => x.Value - y.Value));

            int[] result = new int[n + 1];
            Array.Fill(result, int.MaxValue);

            result[k] = 0;
            set.Add(new KeyValuePair<int, int>(0, k));

            while (set.Count > 0)
            {
                var t = set.Min;
                set.Remove(t);
                int dist = t.Key;
                int node = t.Value;

                if (adj.ContainsKey(node))
                    foreach (var item in adj[node])
                    {
                        int adjDist = item.Value;
                        int adjNode = item.Key;

                        if (adjDist + dist < result[adjNode])
                        {
                            if (result[adjNode] != int.MaxValue)
                            {
                                set.Remove(new KeyValuePair<int, int>(result[adjNode], adjNode));
                            }
                            result[adjNode] = adjDist + dist;
                            set.Add(new KeyValuePair<int, int>(adjDist + dist, adjNode));
                        }

                    }

            }
            int ans = 0;
            for (int i = 1; i <= n; i++)
            {
                ans = Math.Max(ans, result[i]);
            }
            return ans != int.MaxValue ? ans : -1;
        }
        //Input: times = [[2,1,1],[2,3,1],[3,4,1]], n = 4, k = 2
        //Output: 2
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.NetworkDelayTime(new int[][] { new int[] { 2, 1, 1 }, new int[] { 2, 3, 1 }, new int[] { 3, 4, 1 }, }, 4, 2));
            Console.WriteLine("Hello World!");
        }
    }
}
