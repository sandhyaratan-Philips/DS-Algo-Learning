using System;
using System.Linq;

namespace _1751._Maximum_Number_of_Events_That_Can_Be_Attended_II
{
    class Program
    {
        int n;
        public int MaxValue(int[][] events, int k)
        {
            n = events.Length;
            events = events.OrderBy(x => x[0]).ToArray();

            return 0;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.MaxValue(new int[][] { new int[] { 1, 1, 1 }, new int[] { 2, 2, 2 }, new int[] { 3, 3, 3 }, new int[] { 4, 4, 4 } }, 3);
            Console.WriteLine("Hello World!");
        }
    }
}
