using System;
using System.Collections.Generic;

namespace _2316._Count_Unreachable_Pairs_of_Nodes_in_an_Undirected_Graph
{
    class Program
    {
        List<int> parent;
        List<int> rank;
        public long CountPairs(int n, int[][] edges)
        {
            parent = new List<int>();
            rank = new List<int>();
            Dictionary<int, int> componentSize = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                parent.Add(i);
                rank.Add(0);
            }
            long remaingNodes = n;
            long ans = 0;
            foreach (var item in edges)
            {
                union(item[0], item[1]);
            }
            for (int i = 0; i < n; i++)
            {
                int p = find(i, parent);
                if (componentSize.ContainsKey(p))
                    componentSize[p]++;
                else
                    componentSize.Add(p, 1);
            }

            foreach (var item in componentSize)
            {
                ans += item.Value * (remaingNodes - item.Value);
                remaingNodes -= item.Value;
            }
            return ans;

        }

        void union(int x, int y)
        {
            int x_parent = find(x, parent);
            int y_parent = find(y, parent);

            if (x_parent == y_parent)
                return;
            if (rank[x_parent] > rank[y_parent])
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

        private int find(int x, List<int> parent)
        {
            if (x == parent[x])
                return x;
            return parent[x] = find(parent[x], parent);
        }
        //Input: n = 7, edges = [[0,2],[0,5],[2,4],[1,6],[5,4]]
        //Output: 14
        //Explanation: There are 14 pairs of nodes that are unreachable from each other:
        //[[0,1],[0,3],[0,6],[1,2],[1,3],[1,4],[1,5],[2,3],[2,6],[3,4],[3,5],[3,6],[4,6],[5,6]].
        //Therefore, we return 14.
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.CountPairs(7, new int[][] { new int[] { 0, 2 }, new int[] { 0, 5 }, new int[] { 2, 4 }, new int[] { 1, 6 }, new int[] { 5, 4 } }));
        }
    }
}
