using System;
using System.Collections.Generic;

namespace _1970._Last_Day_Where_You_Can_Still_Cross
{
    //t= o(nlogn *row*col)
    class Program
    {
        int days;
        int ROW;
        int COL;
        List<List<int>> directions = new List<List<int>>()
        {
            new List<int>{1,0},
            new List<int>{-1,0},
            new List<int>{0,1},
            new List<int>{0,-1}
        };
        public int LatestDayToCross(int row, int col, int[][] cells)
        {
            ROW = row;
            COL = col;
            int l = 0;
            int r = cells.Length - 1;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (canCross(cells, mid))
                {
                    days = mid + 1;
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
            return days;
        }

        private bool canCross(int[][] cells, int mid)
        {
            int[,] visited = new int[ROW, COL];
            //fill land with water
            for (int i = 0; i <= mid; i++)
            {
                int x = cells[i][0] - 1;
                int y = cells[i][1] - 1;
                visited[x, y] = 1;

            }
            //do dfs on remaining land
            for (int j = 0; j < COL; j++)
            {
                if (visited[0, j] == 0 && dfs(visited, 0, j))
                {
                    return true;
                }
            }
            return false;
        }

        private bool dfs(int[,] grid, int i, int j)
        {
            if (i < 0 || i >= ROW || j < 0 || j >= COL || grid[i, j] == 1)
                return false;

            if (i == ROW - 1)
            {
                return true;
            }
            grid[i, j] = 1;
            foreach (var dir in directions)
            {
                int new_i = i + dir[0];
                int new_j = j + dir[1];

                if (dfs(grid, new_i, new_j))
                    return true;

            }
            return false;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.LatestDayToCross(3, 3, new int[][] { new int[] { 1, 2 }, new int[] { 2, 1 }, new int[] { 3, 3 }, new int[] { 2, 2 }, new int[] { 1, 1 }, new int[] { 1, 3 }, new int[] { 2, 3 }, new int[] { 3, 2 }, new int[] { 3, 1 } }));
            Console.WriteLine("Hello World!");
        }
    }
}
