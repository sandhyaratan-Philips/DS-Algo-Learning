using System;

namespace _707._Design_Linked_List
{
    //Input ["MyLinkedList", "addAtHead", "addAtTail", "addAtIndex", "get", "deleteAtIndex", "get"]
    //[[], [1], [3], [1, 2], [1], [1], [1]]
    //Output [null, null, null, null, 2, null, 3]

    public class ListNode
    {
        public int data;
        public ListNode prev = null;
        public ListNode next = null;
        public ListNode(int data)
        {
            this.data = data;
            this.prev = null;
            this.next = null;
        }

    }

    class Program
    {

        private ListNode right = null;
        private ListNode left = null;
        private int count = 0;
        public Program()
        {
            left = new ListNode(0);
            right = new ListNode(0);
            left.next = right;
            right.prev = left;
        }

        public int Get(int index)
        {
            ListNode cur = left.next;
            while (cur != null && index > 0)
            {
                cur = cur.next;
                index -= 1;
            }


            if (cur != null && cur != right && index == 0)
            {
                return cur.data;
            }
            return -1;
        }

        public void AddAtHead(int val)
        {
            ListNode node = new ListNode(val);
            ListNode prev = left;
            ListNode next = left.next;
            node.next = next;
            node.prev = prev;
            next.prev = node;
            prev.next = node;
        }

        public void AddAtTail(int val)
        {
            ListNode node = new ListNode(val);
            ListNode prev = right.prev;
            ListNode next = right;
            node.next = next;
            node.prev = prev;
            next.prev = node;
            prev.next = node;
        }

        public void AddAtIndex(int index, int val)
        {
            ListNode next = left.next;
            while (next != null && index > 0)
            {
                next = next.next;
                index -= 1;
            }


            if (next != null && index == 0)
            {
                ListNode node = new ListNode(val);
                ListNode prev = next.prev;
                node.next = next;
                node.prev = prev;
                next.prev = node;
                prev.next = node;
            }
        }

        public void DeleteAtIndex(int index)
        {
            ListNode node = left.next;
            while (node != null && index > 0)
            {
                node = node.next;
                index -= 1;
            }


            if (node != null && node != right && index == 0)
            {
                node.prev.next = node.next;
                node.next.prev = node.prev;
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.AddAtHead(1);
            program.AddAtTail(3);
            program.AddAtIndex(1, 2);
            program.Get(1);
            program.DeleteAtIndex(1);
            program.Get(1);

            Console.WriteLine("Hello World!");
        }
    }
}
