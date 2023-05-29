using System;
using System.Collections.Generic;

namespace _980._Unique_Paths_III
{
    //m x n integer array grid where grid[i][j] could be:

    //1 representing the starting square.There is exactly one starting square.
    //2 representing the ending square. There is exactly one ending square.
    //0 representing empty squares we can walk over.
    //-1 representing obstacles that we cannot walk over.
    class Program
    {
        int m, n; int nonObs = 0;

        List<KeyValuePair<int, int>> directions = new List<KeyValuePair<int, int>>()
        {
            new KeyValuePair<int, int>(-1,0),
            new KeyValuePair<int, int>(1,0),
            new KeyValuePair<int, int>(0,-1),
            new KeyValuePair<int, int>(0,1)
        };
        public int UniquePathsIII(int[][] grid)
        {
            nonObs = 0;
            int x = 0, y = 0;
            m = grid.Length;
            n = grid[0].Length;
            int ways = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        nonObs++;
                    }

                    if (grid[i][j] == 1)
                    {
                        x = i;
                        y = j;
                        nonObs++;
                    }
                }
            }

            backTracking(grid, x, y, 0, ref ways);


            return ways;
        }

        private void backTracking(int[][] grid, int x, int y, int count, ref int ways)
        {
            if (x >= m || x < 0 || y < 0 || y >= n || grid[x][y] == -1)
                return;

            if (grid[x][y] == 2)
            {
                if (count == nonObs)
                    ways++;
                return;
            }
            int temp = grid[x][y];

            grid[x][y] = -1;
            foreach (var dir in directions)
            {
                int x_new = x + dir.Key;
                int y_new = y + dir.Value;

                backTracking(grid, x_new, y_new, count + 1, ref ways);
            }
            grid[x][y] = temp;
        }

        //Input: grid = [[1,0,0,0],[0,0,0,0],[0,0,2,-1]]
        //Output: 2
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
