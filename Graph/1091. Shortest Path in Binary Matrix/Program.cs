using System;
using System.Collections.Generic;

namespace _1091._Shortest_Path_in_Binary_Matrix
{
    class Program
    {
        int n;
        int m;
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            m = grid.Length;
            n = grid[0].Length;

            int[][] directions = new int[][] { new int[] { 1, 1 }, new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 }, new int[] { -1, -1 }, new int[] { 1, -1 }, new int[] { -1, 1 } };


            Queue<KeyValuePair<int, int>> que = new Queue<KeyValuePair<int, int>>();
            if (m == 0 || n == 0 || grid[0][0] != 0)
                return -1;

            que.Enqueue(new KeyValuePair<int, int>(0, 0));
            grid[0][0] = 1;


            int steps = 1;

            while (que.Count > 0)
            {

                int N = que.Count;
                while (N-- != 0)
                {

                    var curr = que.Dequeue();
                    int x = curr.Key;
                    int y = curr.Value;

                    if (x == m - 1 && y == n - 1)
                        return steps;

                    foreach (var dir in directions)
                    {
                        int x_ = x + dir[0];
                        int y_ = y + dir[1];

                        if (isSafe(x_, y_) && grid[x_][y_] == 0)
                        {
                            que.Enqueue(new KeyValuePair<int, int>(x_, y_));
                            grid[x_][y_] = 1;
                        }
                    }
                }
                steps++;
            }

            return -1;
        }

        private bool isSafe(int i, int j)
        {
            return i >= 0 && i < m && j >= 0 && j < n;
        }

        //Input: grid = [[0,0,0],[1,1,0],[1,1,0]]
        //Output: 4
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.ShortestPathBinaryMatrix(new int[][] { new int[] { 0, 0, 0 }, new int[] { 1, 1, 0 }, new int[] { 1, 1, 0 } }));
            Console.WriteLine("Hello World!");
        }
    }
}
