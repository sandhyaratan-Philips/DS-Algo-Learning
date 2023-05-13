using System;
using System.Collections.Generic;

namespace _1964._Find_the_Longest_Valid_Obstacle_Course_at_Each_Position
{
    //Input: obstacles = [1,2,3,2]
    //Output: [1,2,3,3]
    //Explanation: The longest valid obstacle course at each position is:
    //- i = 0: [1], [1] has length 1.
    //- i = 1: [1,2], [1,2] has length 2.
    //- i = 2: [1,2,3], [1,2,3] has length 3.
    //- i = 3: [1,2,3,2], [1,2,2] has length 3.
    class Program
    {
        public int[] LongestObstacleCourseAtEachPosition(int[] obstacles)
        {
            List<int> ans = new List<int>();

            List<int> tail = new List<int>();

            foreach (int obstacle in obstacles)
                if (tail.Count - 1 >= 0 && (tail.Count != 0 || obstacle >= tail[tail.Count - 1]))
                {
                    tail.Add(obstacle);
                    ans.Add(tail.Count);
                }
                else
                {
                    int index = firstGreater(tail, obstacle);
                    tail[index] = obstacle;
                    ans.Add(index + 1);
                }

            return ans.ToArray();
        }

        private int firstGreater(List<int> A, int target)
        {
            int l = 0;
            int r = A.Count;

            while (l < r)
            {
                int m = (l + r) / 2;
                if (A[m] > target)
                    r = m;
                else
                    l = m + 1;
            }

            return l;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.LongestObstacleCourseAtEachPosition(new int[] { 1, 2, 3, 2 });
            Console.WriteLine("Hello World!");
        }
    }
}
