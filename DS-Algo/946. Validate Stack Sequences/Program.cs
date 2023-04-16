using System;
using System.Collections.Generic;

namespace _946._Validate_Stack_Sequences
{
    //Input: pushed = [1,2,3,4,5], popped = [4,3,5,1,2]
    //Output: false
    //Explanation: 1 cannot be popped before 2.
    class Program
    {
        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            Stack<int> stack = new Stack<int>();
            int i = 0;
            foreach (var item in pushed)
            {
                stack.Push(item);
                while (stack.Count > 0 && stack.Peek() == popped[i])
                {
                    stack.Pop();
                    i++;
                }
            }
            return stack.Count == 0;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.ValidateStackSequences(new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 3, 5, 1, 2 }));
        }
    }
}
