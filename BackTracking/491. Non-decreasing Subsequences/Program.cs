using System;
using System.Collections.Generic;

namespace _491._Non_decreasing_Subsequences
{
    class Program
    {
        int n = 0;
        List<IList<int>> result;
        public IList<IList<int>> FindSubsequences(int[] nums)
        {
            n = nums.Length;
            result = new List<IList<int>>();
            List<int> curr = new List<int>();

            backtrack(nums, 0, curr, result);
            return result;

        }

        private void backtrack(int[] nums, int idx, List<int> curr, List<IList<int>> result)
        {
            if (curr.Count >= 2)
            {
                result.Add(new List<int>(curr));
            }
            HashSet<int> st = new HashSet<int>();

            for (int i = idx; i < n; i++)
            {
                int k = curr.Count - 1;
                if ((curr.Count == 0 || nums[i] >= curr[k]) && !st.Contains(nums[i]))
                {
                    curr.Add(nums[i]);
                    backtrack(nums, i + 1, curr, result);
                    curr.Remove(nums[i]);
                    st.Add(nums[i]);
                }

            }
        }

        //Input: nums = [4,6,7,7]
        //Output: [[4,6],[4,6,7],[4,6,7,7],[4,7],[4,7,7],[6,7],[6,7,7],[7,7]]
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.FindSubsequences(new int[] { 4, 6, 7, 7 }));
        }
    }
}
