using System;
using System.Collections.Generic;

namespace _2328._Number_of_Increasing_Paths_in_a_Grid
{
    class Program
    {
        int m, n;
        int MOD = 1000000007;
        List<int[]> directions = new List<int[]>() { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
        int[][] t;
        public int CountPaths(int[][] grid)
        {
            t = new int[1001][];
            for (int i = 0; i < 1001; i++)
            {
                t[i] = new int[1001];
                Array.Fill(t[i], -1);
            }
            m = grid.Length;
            n = grid[0].Length;

            int result = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result = (result + dfs(i, j, grid)) % MOD;
                }

            }
            return result;
        }

        private int dfs(int i, int j, int[][] grid)
        {
            if (t[i][j] != -1)
                return t[i][j];
            int ans = 1;

            foreach (var dir in directions)
            {
                int i_ = i + dir[0];
                int j_ = j + dir[1];

                if (isSafe(i_, j_) && grid[i_][j_] < grid[i][j])
                {
                    ans = (ans + dfs(i_, j_, grid)) % MOD;
                }

            }
            t[i][j] = ans;
            return ans;
        }

        private bool isSafe(int i, int j)
        {
            return i < m && i >= 0 && j < n && j >= 0;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.CountPaths(new int[][] { new int[] { 1, 1 }, new int[] { 3, 4 } });
            Console.WriteLine("Hello World!");
        }
    }
}
