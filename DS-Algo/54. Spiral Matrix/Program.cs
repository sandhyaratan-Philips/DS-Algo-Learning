using System;
using System.Collections.Generic;

namespace _54._Spiral_Matrix
{
    class Program
    {
        int t, b, l, r;
        public IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> list = new List<int>();
            int m = matrix.Length;
            int n = matrix[0].Length;
            t = 0; b = m;
            l = 0; r = n;
            while (l < r && t < b)
            {
                for (int i = l; i < r; i++)
                {
                    list.Add(matrix[t][i]);
                }
                t++;

                for (int i = t; i < b; i++)
                {
                    list.Add(matrix[i][r - 1]);
                }
                r--;

                if (!(l < r && t < b))
                    break;

                for (int i = r - 1; i >= l; i--)
                {
                    list.Add(matrix[b - 1][i]);
                }
                b--;

                for (int i = b - 1; i >= t; i--)
                {
                    list.Add(matrix[i][l]);
                }
                l++;
            }
            return list;
        }

        public int[][] GenerateMatrix(int n)
        {
            int[][] ans = new int[n][];
            int count = 1;

            for (int i = 0; i < n; i++)
            {
                ans[i] = new int[n];
            }

            for (int min = 0; min < n / 2; ++min)
            {
                int max = n - min - 1;
                for (int i = min; i < max; ++i)
                    ans[min][i] = count++;
                for (int i = min; i < max; ++i)
                    ans[i][max] = count++;
                for (int i = max; i > min; --i)
                    ans[max][i] = count++;
                for (int i = max; i > min; --i)
                    ans[i][min] = count++;
            }

            if (n % 2 == 1)
                ans[(n / 2)][(n / 2)] = count;

            return ans;
        }
        static void Main(string[] args)
        {
            Program program = new Program();


            program.GenerateMatrix(3);
            program.SpiralOrder(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } });
            Console.WriteLine("Hello World!");
        }
    }
}
