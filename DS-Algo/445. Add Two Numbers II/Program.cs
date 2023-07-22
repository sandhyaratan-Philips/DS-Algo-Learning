using System;
using System.Collections.Generic;

namespace _445._Add_Two_Numbers_II
{
    internal class Program
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

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            Stack<int> st1=new Stack<int>();
            Stack<int> st2 = new Stack<int>();

            while(l1 != null && l2!=null)
            {
                st1.Push(l1.val);
                l1= l1.next;
                st2.Push(l2.val);
                l2 = l2.next;
            }

            if(l1 != null)
            {
                while(l1!=null)
                {
                    st1.Push(l1.val);
                    l1 = l1.next;
                }
            }

            if (l2 != null)
            {
                while (l2 != null)
                {
                    st2.Push(l2.val);
                    l2 = l2.next;
                }
            }

            int totalSum = 0, carry = 0;
            ListNode ans = new ListNode();
            while (st1.Count>0 || st2.Count>0)
            {
                if (st1.Count > 0) totalSum += st1.Pop();
                if (st2.Count > 0) totalSum += st2.Pop();

                ans.val = totalSum % 10;
                carry = totalSum / 10;
                ListNode head = new ListNode(carry);
                head.next = ans;
                ans = head;
                totalSum = carry;
            }

            return carry == 0 ? ans.next : ans;



        }
        static void Main(string[] args)
        {
            Program program = new Program();
            ListNode l1 = new ListNode(1,new ListNode(9));
            ListNode l2 = new ListNode(1, new ListNode(3));
            program.AddTwoNumbers(l1, l2);
            Console.WriteLine("Hello World!");
        }
    }
}
