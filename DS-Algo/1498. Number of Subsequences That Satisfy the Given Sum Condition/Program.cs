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
            Array.Sort(nums);
            int n = nums.Length;
            //pre compute Math.pow
            int[] pow = new int[n];
            pow[0] = 1;
            for (int i = 1; i < n; i++)
            {
                pow[i] = (int)((pow[i - 1] * 2) % (10e9 + 7));
            }

            int l = 0, r = n - 1;
            int res = 0;
            while (l < r)
            {
                if (nums[l] + nums[r] <= target)
                {
                    res = (int)((res % (10e9 + 7)) + (pow[r - l] % (10e9 + 7)));
                    l++;
                }
                else { r--; }
            }
            return res;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.NumSubseq(new int[] { 5, 3, 6, 7 }, 9);
            Console.WriteLine("Hello World!");
        }
    }
}
