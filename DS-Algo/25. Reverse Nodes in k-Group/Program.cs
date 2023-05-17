using System;

namespace _25._Reverse_Nodes_in_k_Group
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    class Program
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode curr = head;
            int count = 0;

            while (count < k && curr != null)
            {
                count++;
                curr = curr.next;
            }

            if (count == k)
            {

                ListNode reverse_head = Reverse(head, k);
                head.next = ReverseKGroup(curr, k);
                return reverse_head;
            }


            return head;
        }

        private ListNode Reverse(ListNode head, int k)
        {
            ListNode new_head = null;
            ListNode temp = head;
            while (k > 0)
            {
                ListNode next = temp.next;
                temp.next = new_head;
                new_head = temp;
                temp = next;

                k--;
            }
            return new_head;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            head = program.ReverseKGroup(head, 3);

            Console.WriteLine("Hello World!");
        }
    }
}
