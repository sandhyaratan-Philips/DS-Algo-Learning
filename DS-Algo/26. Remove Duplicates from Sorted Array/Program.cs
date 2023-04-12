using System;

namespace _26._Remove_Duplicates_from_Sorted_Array
{
    //Input: nums = [0,0,1,1,1,2,2,3,3,4]
    //Output: 5, nums = [0,1,2,3,4, _, _, _, _, _]

    class Program
    {
        public int RemoveDuplicates(int[] nums)
        {
            int l = 1;
            for (int r = 1; r < nums.Length; r++)
            {
                if (nums[r - 1] != nums[r])
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
            //program.RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 });
            Console.WriteLine(program.RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }));
        }
    }
}
