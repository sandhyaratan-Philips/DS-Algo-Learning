using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infix_To_Postfix
{
    public class StackChar
    {
        private char[] stackArr;
        private int top;
        public StackChar()
        {
            stackArr = new char[10];
            top = -1;
        }

        public StackChar(int maxSize)
        {
            stackArr=new char[maxSize];
            top = -1;
        }

        public int Size()
        {
            return top + 1;
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public bool IsFull()
        {
            return top==stackArr.Length-1;
        }

        public void Push(char x)
        {
            if(IsFull())
            {
                Console.WriteLine("is full");
                return;
            }
            top++;
            stackArr[top] = x;
        }

        public char Pop()
        {
            char x;
            if(IsEmpty())
            {
                throw new InvalidOperationException("stack under flow");
            }
            x = stackArr[top];
            top--;
            return x;
        }

        public char Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("stack under flow");
            }
            return stackArr[top];
        }
        }
}
