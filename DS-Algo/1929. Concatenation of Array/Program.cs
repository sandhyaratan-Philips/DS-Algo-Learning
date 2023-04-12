using System;

namespace _1929._Concatenation_of_Array
{
    //Input: nums = [1,3,2,1]
    //Output: [1,3,2,1,1,3,2,1]
    class Program
    {
        public int[] GetConcatenation(int[] nums)
        {
            int n = nums.Length;
            int[] arr = new int[n * 2];
            for (int i = 0; i < n; i++)
            {
                arr[i] = nums[i];
                arr[i + n] = nums[i];
            }
            return arr;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.GetConcatenation(new int[] { 1, 3, 2, 1 }));
        }
    }
}
