using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infix_To_Postfix
{
    public class StackInt
    {
        private int[] stackArr;
        private int top;
        public StackInt()
        {
            stackArr = new int[10];
            top = -1;
        }

        public StackInt(int maxSize)
        {
            stackArr = new int[maxSize];
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
            return top == stackArr.Length - 1;
        }

        public void Push(int x)
        {
            if (IsFull())
            {
                Console.WriteLine("is full");
                return;
            }
            top++;
            stackArr[top] = x;
        }

        public int Pop()
        {
            int x;
            if (IsEmpty())
            {
                throw new InvalidOperationException("stack under flow");
            }
            x = stackArr[top];
            top--;
            return x;
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("stack under flow");
            }
            return stackArr[top];
        }
    }
}
