using System;

namespace _2448._Minimum_Cost_to_Make_Array_Equal
{
    class Program
    {
        public long MinCost(int[] nums, int[] cost)
        {
            int left = 1000001, right = 0;
            foreach (int num in nums)
            {
                left = Math.Min(left, num);
                right = Math.Max(right, num);
            }
            long answer = 0;

            while (left < right)
            {
                int mid = (right + left) / 2;
                long cost1 = getCost(nums, cost, mid);
                long cost2 = getCost(nums, cost, mid + 1);
                answer = Math.Min(cost1, cost2);

                if (cost1 > cost2)
                    left = mid + 1;
                else
                    right = mid;
            }
            return answer;
        }

        private long getCost(int[] nums, int[] cost, int target)
        {
            long result = 0L;
            for (int i = 0; i < nums.Length; ++i)
                result += 1L * Math.Abs(nums[i] - target) * cost[i];
            return result;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.MinCost(new int[] { 1, 3, 5, 2 }, new int[] { 2, 3, 1, 14 });
            Console.WriteLine("Hello World!");
        }
    }
}
