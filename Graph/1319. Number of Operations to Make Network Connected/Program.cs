using System;
using System.Collections.Generic;

namespace _1319._Number_of_Operations_to_Make_Network_Connected
{
    class Program
    {
        List<int> parent;
        List<int> rank;
        public int MakeConnected(int n, int[][] connections)
        {
            if (connections.Length < n - 1)
                return -1;
            parent = new List<int>();
            rank = new List<int>();
            for (int i = 0; i < n; i++)
            {
                rank.Add(0);
                parent.Add(i);
            }
            int connectionNumber = n;
            foreach (var item in connections)
            {
                if (find(item[0]) != find(item[1]))
                {
                    union(item[0], item[1]);
                    connectionNumber--;
                }
            }
            return connectionNumber - 1;
        }

        void union(int x, int y)
        {
            int x_parent = find(x);
            int y_parent = find(y);
            if (x_parent == y_parent)
            {
                return;
            }
            else if (rank[x_parent] > rank[y_parent])
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

        private int find(int x)
        {
            if (x == parent[x])
                return x;
            return parent[x] = find(parent[x]);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.MakeConnected(6, new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 },, new int[] { 0, 3 }, new int[] { 1, 2 }, new int[] { 1, 3 } }));
        }
    }
}
