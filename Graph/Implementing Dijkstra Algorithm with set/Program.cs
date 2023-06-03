using System;
using System.Collections.Generic;
using System.Linq;

namespace Implementing_Dijkstra_Algorithm_with_set
{
    class Program
    {
        //working
        public List<int> dijkstra(int V, List<List<List<int>>> adj, int S)
        {
            //Comparer<KeyValuePair<int, int>>.Create((x,y)=> x.Key-y.Key)
            SortedSet<KeyValuePair<int, int>> set = new SortedSet<KeyValuePair<int, int>>(Comparer<KeyValuePair<int, int>>.Create((x, y) => x.Value - y.Value));

            int[] result = new int[V];
            Array.Fill(result, int.MaxValue);

            result[S] = 0;
            set.Add(new KeyValuePair<int, int>(0, S));

            while (set.Count > 0)
            {
                var it = set.Min;
                set.Remove(it);
                int d = it.Key;
                int node = it.Value;
                int i = 0;
                foreach (var v in adj[node])
                {
                    if (v.Count > 0)
                    {
                        int adjNode = i;
                        int adjDist = v[0];
                        if (d + adjDist < result[adjNode])
                        {
                            if (result[adjNode] != int.MaxValue)
                            {
                                set.Remove(new KeyValuePair<int, int>(result[adjNode], adjNode));
                            }
                            result[adjNode] = d + adjDist;
                            set.Add(new KeyValuePair<int, int>(d + adjDist, adjNode));
                        }
                    }
                    i++;
                }


            }
            return result.ToList();


        }
        static void Main(string[] args)
        {

            List<List<List<int>>> adj = new List<List<List<int>>>();

            for (int i = 0; i < 4; i++)
            {
                adj.Add(new List<List<int>>());
                for (int j = 0; j < 4; j++)
                {
                    adj[i].Add(new List<int>());
                }
            }
            adj[0][1].Add(9);
            adj[0][2].Add(1);
            adj[0][3].Add(1);

            adj[1][0].Add(9);
            adj[1][3].Add(3);

            adj[2][0].Add(1);
            adj[2][3].Add(2);

            adj[3][0].Add(1);
            adj[3][2].Add(2);
            adj[3][1].Add(3);

            Program program = new Program();
            program.dijkstra(4, adj, 0);
            Console.WriteLine("Hello World!");
        }
    }
}
