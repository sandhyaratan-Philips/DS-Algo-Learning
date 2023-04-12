using System;

namespace _206._Reverse_Linked_List
{

    //Input: head = [1,2,3,4,5]
    //Output: [5,4,3,2,1]
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
        //public ListNode ReverseList(ListNode head)
        //{
        //    ListNode node = ReverseList(head, null);
        //    return node;
        //}

        //public ListNode ReverseList(ListNode node, ListNode pre)
        //{
        //    if (node == null) return pre;

        //    ListNode temp = node.next;
        //    node.next = pre;
        //    return ReverseList(temp, node);
        //}

        public ListNode ReverseList(ListNode head)
        {
            ListNode pre = null;
            ListNode curr = head;

            while (curr != null)
            {
                ListNode temp = curr.next;
                curr.next = pre;
                pre = curr;
                curr = temp;
            }
            return pre;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            ListNode root = new ListNode(1, null);
            root.next = new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, null))));
            program.ReverseList(root);
            Console.WriteLine("Hello World!");
        }
    }
}
