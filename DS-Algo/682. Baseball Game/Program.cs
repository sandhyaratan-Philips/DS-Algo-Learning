using System;
using System.Collections.Generic;

namespace _682._Baseball_Game
{
    //Input: ops = ["5","-2","4","C","D","9","+","+"]
    //Output: 27
    class Program
    {
        public int CalPoints(string[] operations)
        {
            Stack<int> stack = new Stack<int>();
            int sum = 0;
            for (int i = 0; i < operations.Length; i++)
            {
                if (stack.Count >= 2 && operations[i].Equals("+"))
                {
                    int first = stack.Pop();
                    int second = stack.Peek();
                    stack.Push(first);
                    stack.Push(first + second);
                    sum += stack.Peek();
                }
                else if (stack.Count > 0 && operations[i].Equals("D"))
                {
                    stack.Push(stack.Peek() * 2);
                    sum += stack.Peek();
                }
                else if (stack.Count > 0 && operations[i].Equals("C"))
                {
                    sum -= stack.Pop();

                }
                else
                {
                    stack.Push(Convert.ToInt32(operations[i]));
                    sum += stack.Peek();
                }
            }
            return sum;

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.CalPoints(new string[] { "5", "-2", "4", "C", "D", "9", "+", "+" }));
        }
    }
}
