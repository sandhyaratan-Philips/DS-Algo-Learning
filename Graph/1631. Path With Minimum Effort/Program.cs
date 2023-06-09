using System;
using System.Collections.Generic;

namespace _1631._Path_With_Minimum_Effort
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
        List<KeyValuePair<int, int>> Directions = new List<KeyValuePair<int, int>>();

        public int MinimumEffortPath(int[][] heights)
        {
            Directions.Add(new KeyValuePair<int, int>(1, 0));
            Directions.Add(new KeyValuePair<int, int>(-1, 0));
            Directions.Add(new KeyValuePair<int, int>(0, 1));
            Directions.Add(new KeyValuePair<int, int>(0, -1));

            n = heights.Length;
            m = heights[0].Length;

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
                int diff = it.Key;
                int x = it.Value.Key;
                int y = it.Value.Value;

                set.Remove(it);

                if (x == m - 1 && y == n - 1)
                    return diff;

                foreach (var dir in Directions)
                {
                    int x_ = x + dir.Key;
                    int y_ = y + dir.Value;


                    if (isSafe(x_, y_))
                    {
                        int absDist = Math.Abs(heights[x][y] - heights[x_][y_]);
                        int maxDiff = Math.Max(diff, absDist);

                        if (result[x_][y_] > maxDiff)

                            set.Add(new KeyValuePair<int, KeyValuePair<int, int>>(maxDiff, new KeyValuePair<int, int>(x_, y_)));
                        result[x_][y_] = maxDiff;
                    }
                }
            }

            return result[m - 1][n - 1];


        }
        private bool isSafe(int i, int j)
        {
            return i >= 0 && i < m && j >= 0 && j < n;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.MinimumEffortPath(new int[][] { new int[] { 1, 10, 6, 7, 9, 10, 4, 9 } })); //2
            Console.WriteLine("Hello World!");
        }
    }
}
