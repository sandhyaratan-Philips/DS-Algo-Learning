using System;
using System.Collections.Generic;
using System.Linq;

namespace _735._Asteroid_Collision
{
    class Program
    {
        public int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> stack = new Stack<int>();
            foreach (var item in asteroids)
            {
                bool flag = true;
                while (stack.Count > 0 && (stack.Peek() > 0 && item < 0))
                {
                    if (Math.Abs(item) > stack.Peek())
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (Math.Abs(stack.Peek()) == Math.Abs(item))
                    {
                        stack.Pop();
                    }
                    flag = false;
                    break;
                }
                if (flag)
                {
                    stack.Push(item);
                }
            }
            return stack.Reverse().ToArray();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.AsteroidCollision(new int[] { 10, 2, -5 });
            Console.WriteLine("Hello World!");
        }
    }
}
