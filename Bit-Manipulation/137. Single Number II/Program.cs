using System;

namespace _137._Single_Number_II
{
    class Program
    {
        //left shift -> 1100 <<=1    -> 1000; 1100 <<=2    -> 0000

        //find if Kth bit is 1;
        // (1<<Value) & 1

        //set Kth bit;
        // (1<<Value) | 1
        public int SingleNumber(int[] nums)
        {
            //approch 1-> store frequency in dictionary and find the one whose freqency is 1; T=O(N) S=O(N)

            //approch 2-> sort array and iterate; T=O(N) S=O(1)

            //approch 3
            int res = 0;
            for (int i = 0; i < 32; i++)//ith bit
            {
                int temp = (1 << i);
                int countOne = 0;
                int countZero = 0;
                foreach (var num in nums)
                {
                    if ((temp & num) == 0)
                    {
                        countZero++;
                    }
                    else
                    {
                        countOne++;
                    }
                }

                if (countOne % 3 == 1)
                    res = (res | temp);
            }

            return res;
        }
        static void Main(string[] args)
        {
            //0,1,0,1,0,1,99
            Program program = new Program();
            Console.WriteLine(program.SingleNumber(new int[] { 0, 1, 0, 1, 0, 1, 99 }));
            Console.WriteLine("Hello World!");
        }
    }
}
