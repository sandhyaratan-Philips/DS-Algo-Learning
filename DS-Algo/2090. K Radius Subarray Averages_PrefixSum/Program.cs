using System;

namespace _2090._K_Radius_Subarray_Averages_PrefixSum
{
    class Program
    {
        public int[] GetAverages(int[] nums, int k)
        {
            int n = nums.Length;

            if (k == 0)
                return nums;

            int[] result = new int[n];
            Array.Fill(result, -1);

            if (n < 2 * k + 1)
                return result;

            long[] prefixSum = new long[n];
            prefixSum[0] = nums[0];

            for (int i = 1; i < n; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + nums[i];

            }

            for (int i = k; i < n - k; i++)
            {

                int left_idx = i - k;
                int right_idx = i + k;

                long sum = prefixSum[right_idx];

                if (left_idx > 0)
                    sum -= prefixSum[left_idx - 1];


                int avg = (int)(sum / (2 * k + 1));

                result[i] = avg;


            }

            return result;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.GetAverages(new int[] { 7, 4, 3, 9, 1, 8, 5, 2, 6 }, 3);
            Console.WriteLine("Hello World!");
        }
    }
}
