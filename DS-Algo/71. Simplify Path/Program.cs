using System;
using System.Collections.Generic;
using System.Linq;

namespace _71._Simplify_Path
{
    //Input: path = "/home//foo/"
    //Output: "/home/foo"
    class Program
    {
        public string SimplifyPath(string path)
        {
            string[] str = path.Split('/');
            Stack<string> stack = new Stack<string>();

            foreach (var item in str)
            {
                if (string.IsNullOrEmpty(item) || item.Equals("."))
                    continue;
                if (item.Equals(".."))
                {
                    if (stack.Count > 0) stack.Pop();
                }
                else
                {
                    stack.Push(item.Trim());
                }
            }

            return "/" + string.Join('/', stack.Reverse());
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.SimplifyPath("/ a//b////c/d//././/..")); //=> /a/b/c
        }
    }
}
