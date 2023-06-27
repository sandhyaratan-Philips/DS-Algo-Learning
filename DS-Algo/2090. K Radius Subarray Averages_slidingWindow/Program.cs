using System;

namespace _2090._K_Radius_Subarray_Averages_slidingWindow
{
    class Program
    {
        public int[] GetAverages(int[] nums, int k)
        {
            int n = nums.Length;
            int[] ans = new int[n];
            Array.Fill(ans, -1);

            if (k == 0)
                return nums;
            if (n < (2 * k + 1))
                return ans;
            long sum = 0;
            for (int i = 0; i <= 2 * k; i++)
            {
                sum += nums[i];
            }
            ans[k] = (int)(sum / (2 * k + 1));

            for (int i = (2 * k + 1); i < n; ++i)
            {
                sum = sum - nums[i - (2 * k + 1)] + nums[i];
                ans[i - k] = (int)(sum / (2 * k + 1));
            }


            return ans;

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.GetAverages(new int[] { 7, 4, 3, 9, 1, 8, 5, 2, 6 }, 3);
            Console.WriteLine("Hello World!");
        }
    }
}
