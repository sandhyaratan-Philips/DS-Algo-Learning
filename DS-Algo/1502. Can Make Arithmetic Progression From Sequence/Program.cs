using System;

namespace _1502._Can_Make_Arithmetic_Progression_From_Sequence
{
    class Program
    {
        public bool CanMakeArithmeticProgression(int[] arr)
        {
            Array.Sort(arr);
            int diff = arr[1] - arr[0];
            for (int i = 2; i < arr.Length; i++)
            {
                if (arr[i] - arr[i - 1] != diff)
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.CanMakeArithmeticProgression(new int[] { 3, 5, 1 });

            Console.WriteLine("Hello World!");
        }
    }
}
