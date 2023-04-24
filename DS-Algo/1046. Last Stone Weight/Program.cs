using System;
using System.Collections.Generic;
using System.Linq;

namespace _1046._Last_Stone_Weight
{
    //Input: stones = [2,7,4,1,8,1]
    //Output: 1
    //Explanation: 
    //We combine 7 and 8 to get 1 so the array converts to[2, 4, 1, 1, 1] then,
    //we combine 2 and 4 to get 2 so the array converts to[2, 1, 1, 1] then,
    //we combine 2 and 1 to get 1 so the array converts to[1, 1, 1] then,
    //we combine 1 and 1 to get 0 so the array converts to[1] then that's the value of the last stone.
    class Program
    {
        public int LastStoneWeight(int[] stones)
        {
            List<int> stoneList = stones.ToList();



            while (stoneList.Count() > 1)
            {
                stoneList = stoneList.OrderByDescending(x => x).ToList();
                int first = stoneList[0];
                int second = stoneList[1];

                if (first == second)
                {
                    stoneList.RemoveAt(1);
                    stoneList.RemoveAt(0);

                }
                else
                {
                    stoneList[0] = first - second;
                    stoneList.RemoveAt(1);
                }

            }
            if (stoneList.Count() == 1)
                return stoneList[0];
            else
                return 0;

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.LastStoneWeight(new int[] { 2, 2 });
            Console.WriteLine("Hello World!");
        }
    }
}
