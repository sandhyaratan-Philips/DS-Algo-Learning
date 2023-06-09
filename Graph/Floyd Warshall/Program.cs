using System;

namespace Floyd_Warshall
{
    class Program
    {
        void shortest_distance(int[][] matrix)
        {
            int n = matrix.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == -1)
                        matrix[i][j] = 100000;
                }

            }

            for (int via = 0; via < n; via++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == j)
                            continue;
                        matrix[i][j] = Math.Min(matrix[i][j], matrix[i][via] + matrix[via][j]);


                    }

                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 100000)
                        matrix[i][j] = -1;
                }

            }

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.shortest_distance(new int[][] { new int[] { 0, 1, 43 }, new int[] { 1, 0, 6 }, new int[] { -1, -1, 0 } });
            Console.WriteLine("Hello World!");
        }
    }
}
