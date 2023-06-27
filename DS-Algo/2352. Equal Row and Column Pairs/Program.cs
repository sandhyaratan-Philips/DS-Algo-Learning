using System;
using System.Collections.Generic;

namespace _2352._Equal_Row_and_Column_Pairs
{
    class Program
    {
        public int EqualPairs(int[][] grid)
        {
            int n = grid.Length;
            int count = 0;
            Dictionary<string, int> rowCounter = new Dictionary<string, int>();

            foreach (int[] row in grid)
            {
                string rowString = string.Join(",", row);
                if (!rowCounter.ContainsKey(rowString))
                    rowCounter.Add(rowString, 0);
                rowCounter[rowString]++;
            }

            // Add up the frequency of each column in map.
            for (int c = 0; c < n; c++)
            {
                int[] colArray = new int[n];
                for (int r = 0; r < n; ++r)
                {
                    colArray[r] = grid[r][c];
                }
                string colString = string.Join(",", colArray);
                if (rowCounter.ContainsKey(colString))
                    count += 1;
            }

            return count;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.EqualPairs(new int[][] { new int[] { 3, 2, 1 }, new int[] { 1, 7, 6 }, new int[] { 2, 7, 7 } });
            Console.WriteLine("Hello World!");
        }
    }
}
