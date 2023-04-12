using System;

namespace _27._Remove_Element
{
    //Input: nums = [0,1,2,2,3,0,4,2], val = 2
    //Output: 5, nums = [0,1,4,0,3, _, _, _]



    class Program
    {
        public int RemoveElement(int[] nums, int val)
        {
            int l = 0;

            for (int r = 0; r < nums.Length; r++)
            {
                if (nums[r] != val)
                {
                    nums[l] = nums[r];
                    l++;
                }
            }
            return l;
        }
        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine(program.RemoveElement(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2));
        }
    }
}
