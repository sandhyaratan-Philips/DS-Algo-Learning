using System;

namespace _1498._Number_of_Subsequences_That_Satisfy_the_Given_Sum_Condition
{
    //Input: nums = [3,5,6,7], target = 9
    //Output: 4
    //Explanation: There are 4 subsequences that satisfy the condition.
    //[3] -> Min value + max value <= target(3 + 3 <= 9)
    //[3,5] -> (3 + 5 <= 9)
    //[3,5,6] -> (3 + 6 <= 9)
    //[3,6] -> (3 + 6 <= 9)

    //Algo:
    //sort arr
    //l=0 and r = n - 1
    //if(nums[l]+nums[r]<=target){res+=pow of(2, r-l); l++}else r--;
    class Program
    {
        public int NumSubseq(int[] nums, int target)
        {

            int kMod = 1_000_000_007;
            int n = nums.Length;
            int ans = 0;
            int[] pows = new int[n];
            pows[0] = 1;

            for (int i = 1; i < n; ++i)
                pows[i] = pows[i - 1] * 2 % kMod;

            Array.Sort(nums);

            for (int l = 0, r = n - 1; l <= r;)
                if (nums[l] + nums[r] <= target)
                {
                    ans += pows[r - l];
                    ans %= kMod;
                    ++l;
                }
                else
                {
                    --r;
                }

            return ans;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.NumSubseq(new int[] { 5, 3, 6, 7 }, 9);
            Console.WriteLine("Hello World!");
        }
    }
}
