using System;

namespace _2551._Put_Marbles_in_Bags
{
    class Program
    {
        public long PutMarbles(int[] weights, int k)
        {
            int n = weights.Length;
            int[] pairSum = new int[n - 1];

            for (int i = 0; i < n - 1; i++)
            {
                pairSum[i] = weights[i] + weights[i + 1];
            }
            Array.Sort(pairSum);

            long maxSum = 0;
            long minSum = 0;

            for (int i = 0; i < k - 1; i++)
            {
                minSum += pairSum[i];
                maxSum += pairSum[n - 1 - 1 - i];
            }
            return maxSum - minSum;

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.PutMarbles(new[] { 3, 2, 1, 4, 5, 2 }, 2));
            Console.WriteLine("Hello World!");
        }
    }
}
