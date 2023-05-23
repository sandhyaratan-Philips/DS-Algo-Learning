using System;
using System.Collections.Generic;
using System.Linq;

namespace _703._Kth_Largest_Element_in_a_Stream
{
    public class Program
    {
        int K = 0;
        List<int> arr;
        public void KthLargest(int k, int[] nums)
        {
            this.K = k;
            this.arr = new List<int>();
            Array.Sort(nums);
            if (nums.Length > k)
            {
                arr = nums.TakeLast(k).ToList();
            }
            else
            {
                arr = nums.ToList();
            }
        }

        public int Add(int val)
        {
            arr.Add(val);
            arr.Sort();

            if (arr.Count > K)
            {
                arr = arr.TakeLast(K).ToList();
            }

            return arr[0];
        }

        //Input
        //["KthLargest", "add", "add", "add", "add", "add"]
        //[[3, [4, 5, 8, 2]], [3], [5], [10], [9], [4]]
        //Output
        //[null, 4, 5, 5, 8, 8]
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.KthLargest(3, new int[] { 4, 5, 8, 2 });
            //Console.WriteLine(program.Add(3));
            //Console.WriteLine(program.Add(5));
            //Console.WriteLine(program.Add(10));
            //Console.WriteLine(program.Add(9));
            //Console.WriteLine(program.Add(4));


            program.KthLargest(1, new int[] { -2 });
            Console.WriteLine(program.Add(-3));
            Console.WriteLine(program.Add(0));
            Console.WriteLine(program.Add(2));
            Console.WriteLine(program.Add(-1));
            Console.WriteLine(program.Add(4));

            Console.WriteLine("Hello World!");
        }
    }
}
