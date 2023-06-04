using System;
using System.Collections.Generic;

namespace Shortest_Path_in_Weighted_undirected_graph
{
    class Program
    {
        List<int> shortestPath(int n, int m, List<List<int>> edges)
        {
            Dictionary<int, List<KeyValuePair<int, int>>> adj = new Dictionary<int, List<KeyValuePair<int, int>>>();

            foreach (var item in edges)
            {
                int u = item[0];
                int v = item[1];
                int w = item[2];

                if (!adj.ContainsKey(u))
                    adj.Add(u, new List<KeyValuePair<int, int>>());
                adj[u].Add(new KeyValuePair<int, int>(v, w));

                if (!adj.ContainsKey(v))
                    adj.Add(v, new List<KeyValuePair<int, int>>());
                adj[v].Add(new KeyValuePair<int, int>(u, w));

            }

            SortedSet<KeyValuePair<int, int>> set = new SortedSet<KeyValuePair<int, int>>(Comparer<KeyValuePair<int, int>>.Create((x, y) => x.Value - y.Value));

            int[] result = new int[n + 1];
            Array.Fill(result, int.MaxValue);

            int[] parent = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
            }

            result[1] = 0;
            set.Add(new KeyValuePair<int, int>(0, 1));


            while (set.Count > 0)
            {
                var it = set.Min;
                set.Remove(it);
                int d = it.Key;
                int node = it.Value;
                foreach (var v in adj[node])
                {

                    int adjNode = v.Key;
                    int adjDist = v.Value;
                    if (d + adjDist < result[adjNode])
                    {
                        if (result[adjNode] != int.MaxValue)
                        {
                            set.Remove(new KeyValuePair<int, int>(result[adjNode], adjNode));
                        }
                        result[adjNode] = d + adjDist;
                        set.Add(new KeyValuePair<int, int>(d + adjDist, adjNode));
                        parent[adjNode] = node;
                    }


                }
            }
            int destinationNode = n;
            List<int> ans = new List<int>();
            if (parent[destinationNode] != int.MaxValue)
            {
                while (parent[destinationNode] != destinationNode)
                {
                    ans.Add(destinationNode);
                    destinationNode = parent[destinationNode];
                }
                ans.Add(destinationNode);
            }
            else
            {
                ans.Add(-1);
            }
            ans.Reverse();
            return ans;
        }
        //Input:
        //n = 5, m= 6
        //edges = [[1,2,2], [2,5,5], [2,3,4], [1,4,1],[4,3,3],[3,5,1]]
        //Output:
        //1 4 3 5
        //Explaination:
        //Shortest path from 1 to n is by the path 1 4 3 5
        static void Main(string[] args)
        {


            int n = 5; int m = 6;
            Program program = new Program();
            Console.WriteLine(program.shortestPath(n, m, new List<List<int>>() { new List<int>() { 1, 2, 2 }, new List<int>() { 2, 5, 5 }, new List<int>() { 2, 3, 4 }, new List<int>() { 1, 4, 1 }, new List<int>() { 4, 3, 3 }, new List<int>() { 3, 5, 1 } }));
        }
    }
}
