using System;
using System.Collections.Generic;

namespace _20._Valid_Parentheses
{
    //Input: s = "()[]{}"
    //Output: true
    class Program
    {
        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> parenthesesDic = new Dictionary<char, char>();

            parenthesesDic.Add(')', '(');
            parenthesesDic.Add('}', '{');
            parenthesesDic.Add(']', '[');


            for (int i = 0; i < s.Length; i++)
            {
                if (parenthesesDic.ContainsKey(s[i]))
                {
                    if (stack.Count > 0 && stack.Peek().Equals(parenthesesDic[s[i]]))
                    {
                        stack.Pop();
                    }
                    else
                        return false;
                }
                else
                {
                    stack.Push(s[i]);
                }
            }
            return stack.Count == 0;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.IsValid("([}]{}"));
        }
    }
}
