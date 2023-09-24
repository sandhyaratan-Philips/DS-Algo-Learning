using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class StackWithArr
    {
        private int[] stackArr;
        private int top;
        public StackWithArr()
        {
            stackArr = new int[10];
            top = -1;
        }
        public StackWithArr(int maxSize)
        {
            stackArr = new int[maxSize];
            top = -1;
        }

        public int size()
        {
            return top + 1;
        }
        public bool isEmpty()
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
                Console.WriteLine("stack is full");
                return;
            }

            top++;
            stackArr[top] = x;
        }

        public int Pop()
        {
            int x;
            if (isEmpty())
            {
                throw new InvalidOperationException("stack underflow");
            }
            x = stackArr[top];
            top--;
            return x;
        }

        public int Peek()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException("stack underflow");
            }
            return stackArr[top];
        }
    }
}
