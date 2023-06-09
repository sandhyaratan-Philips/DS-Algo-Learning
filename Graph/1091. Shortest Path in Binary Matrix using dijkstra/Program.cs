using System;
using System.Collections.Generic;

namespace _1091._Shortest_Path_in_Binary_Matrix_using_dijkstra
{
    class Program
    {
        public int Compare(KeyValuePair<int, KeyValuePair<int, int>> u1, KeyValuePair<int, KeyValuePair<int, int>> u2)
        {
            int res = u1.Key.CompareTo(u2.Key);

            if (res == 0)
            {
                res = u2.Value.Key.CompareTo(u1.Value.Key);
            }

            if (res == 0)
            {
                res = u2.Value.Value.CompareTo(u1.Value.Value);
            }

            return res;
        }
        int n;
        int m;
        int[][] directions = new int[][] { new int[] { 1, 1 }, new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 }, new int[] { -1, -1 }, new int[] { 1, -1 }, new int[] { -1, 1 } };
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            m = grid.Length;
            n = grid[0].Length;
            if (m == 0 || n == 0 || grid[0][0] != 0)
                return -1;

            int[][] result = new int[m][];

            for (int i = 0; i < m; i++)
            {
                result[i] = new int[n];
                Array.Fill(result[i], int.MaxValue);
            }

            SortedSet<KeyValuePair<int, KeyValuePair<int, int>>> set = new SortedSet<KeyValuePair<int, KeyValuePair<int, int>>>(Comparer<KeyValuePair<int, KeyValuePair<int, int>>>.Create((x, y) => (Compare(x, y))));

            set.Add(new KeyValuePair<int, KeyValuePair<int, int>>(0, new KeyValuePair<int, int>(0, 0)));
            result[0][0] = 0;

            while (set.Count > 0)
            {
                var it = set.Min;
                set.Remove(it);

                int d = it.Key;
                int x = it.Value.Key;
                int y = it.Value.Value;

                foreach (var dir in directions)
                {
                    int x_ = x + dir[0];
                    int y_ = y + dir[1];
                    int dist = 1;

                    if (isSafe(x_, y_) && grid[x_][y_] == 0 && d + dist < result[x_][y_])
                    {
                        set.Add(new KeyValuePair<int, KeyValuePair<int, int>>(d + dist, new KeyValuePair<int, int>(x_, y_)));
                        grid[x_][y_] = 1;
                        result[x_][y_] = d + dist;
                    }
                }
            }

            if (result[m - 1][n - 1] == int.MaxValue)
                return -1;

            return result[m - 1][n - 1] + 1;
        }
        private bool isSafe(int i, int j)
        {
            return i >= 0 && i < m && j >= 0 && j < n;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.ShortestPathBinaryMatrix(new int[][] { new int[] { 0, 1, 0, 1, 0 }, new int[] { 1, 0, 0, 0, 1 }, new int[] { 0, 0, 1, 1, 1 }, new int[] { 0, 0, 0, 0, 0 }, new int[] { 1, 0, 1, 0, 0 } }));
            Console.WriteLine("Hello World!");
        }
    }
}
