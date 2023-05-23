using System;
using System.Collections.Generic;

namespace _934._Shortest_Bridge
{
    // for every 1 do dfs and push the 1's cordinate in queue
    // once dfs is over which means we visited in island
    // then run bfs on the queue cordinates till it hit new 1 (new island)
    class Program
    {// O(m*n)
        int m, n;
        int[][] directions = new int[][]
        {
            new int[]{-1,0},
            new int[]{0,-1},
            new int[]{0,1},
            new int[]{1,0}
        };


        public int ShortestBridge(int[][] grid)
        {
            m = grid.Length;
            n = grid[0].Length;

            HashSet<KeyValuePair<int, int>> visitedCell = new HashSet<KeyValuePair<int, int>>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        DFS(grid, i, j, visitedCell);
                        return BFS(grid, visitedCell);
                    }
                }
            }
            return 0;

        }

        private int BFS(int[][] grid, HashSet<KeyValuePair<int, int>> visitedCell)
        {
            Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();

            foreach (var v in visitedCell)
            {
                q.Enqueue(v);
            }

            int level = 0;

            while (q.Count > 0)
            {
                int l = q.Count;
                while (l-- > 0)
                {
                    KeyValuePair<int, int> pair = q.Dequeue();
                    int x = pair.Key;
                    int y = pair.Value;

                    foreach (var dir in directions)
                    {
                        int x_new = x + dir[0];
                        int y_new = y + dir[1];
                        if (isSafe(x_new, y_new) && !visitedCell.Contains(new KeyValuePair<int, int>(x_new, y_new)))
                        {
                            if (grid[x_new][y_new] == 1)
                            {
                                return level;
                            }
                            visitedCell.Add(new KeyValuePair<int, int>(x_new, y_new));
                            q.Enqueue(new KeyValuePair<int, int>(x_new, y_new));
                        }
                    }


                }

                level++;

            }
            return level;
        }

        private void DFS(int[][] grid, int i, int j, HashSet<KeyValuePair<int, int>> visitedCell)
        {
            if (!isSafe(i, j) || grid[i][j] == 0 || visitedCell.Contains(new KeyValuePair<int, int>(i, j)))
            {
                return;
            }

            visitedCell.Add(new KeyValuePair<int, int>(i, j));

            foreach (var dir in directions)
            {
                int i_new = i + dir[0];
                int j_new = j + dir[1];

                DFS(grid, i_new, j_new, visitedCell);
            }
        }

        private bool isSafe(int i, int j)
        {
            return i >= 0 && i < m && j >= 0 && j < n;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.ShortestBridge(new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 } }));
        }
    }
}
