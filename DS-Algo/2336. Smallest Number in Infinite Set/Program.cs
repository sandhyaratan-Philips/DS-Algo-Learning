using System;

namespace _2336._Smallest_Number_in_Infinite_Set
{
    //Input
    //["SmallestInfiniteSet", "addBack", "popSmallest", "popSmallest", "popSmallest", "addBack", "popSmallest", "popSmallest", "popSmallest"]
    //[[], [2], [], [], [], [1], [], [], []]
    //Output
    //[null, null, 1, 2, 3, null, 1, 4, 5]

    //Explanation
    //SmallestInfiniteSet smallestInfiniteSet = new SmallestInfiniteSet();
    //    smallestInfiniteSet.addBack(2);    // 2 is already in the set, so no change is made.
    //smallestInfiniteSet.popSmallest(); // return 1, since 1 is the smallest number, and remove it from the set.
    //smallestInfiniteSet.popSmallest(); // return 2, and remove it from the set.
    //smallestInfiniteSet.popSmallest(); // return 3, and remove it from the set.
    //smallestInfiniteSet.addBack(1);    // 1 is added back to the set.
    //smallestInfiniteSet.popSmallest(); // return 1, since 1 was added back to the set and
    //                                   // is the smallest number, and remove it from the set.
    //smallestInfiniteSet.popSmallest(); // return 4, and remove it from the set.
    //smallestInfiniteSet.popSmallest(); // return 5, and remove it from the set.
    class Program
    {
        bool[] arr;
        int i = 0;
        public Program()
        {
            arr = new bool[1001];
            i = 1;
        }

        public int PopSmallest()
        {
            int result = i;
            arr[i] = true;
            for (int j = i + 1; j < 1001; j++)
            {
                if (!arr[j])
                {
                    i = j;
                    break;
                }
            }
            return result;

        }

        public void AddBack(int num)
        {
            arr[i] = false;
            if (i > num)
            {
                i = num;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
