using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class QueueWithArr
    {
        private int[] queueArr;
        private int front;
        private int rear;
        public QueueWithArr()
        {
            queueArr = new int[10];
            front = -1;
            rear = -1;
        }

        public QueueWithArr(int maxSize)
        {
            queueArr = new int[maxSize];
            front = -1;
            rear = -1;
        }

        public bool IsEmpty()
        {
            return (front==-1 && rear==-1);
        }

        public bool IsFull()
        {
            return (rear == queueArr.Length);
        }

        public int size()
        {
            if(IsEmpty())
                return 0;
            return rear-front+1;
        }

        public void insert(int x)
        {
            if(IsFull())
            {
                Console.WriteLine("queue is full");
                return;
            }
            if (front == -1)
                front = 0;
            rear += 1;
            queueArr[rear] = x;
        }

        public int Delete()
        {
            int x;
            if (IsEmpty())
                throw new InvalidOperationException("queue underflow");

            x = queueArr[front];
            front += 1;
            return x;
        }
        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("queue underflow");

            return queueArr[front];
        }
    }
}
