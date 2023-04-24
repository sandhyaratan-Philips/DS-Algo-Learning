using System;

namespace _1472._Design_Browser_History
{
    //Input:
    //["BrowserHistory","visit","visit","visit","back","back","forward","visit","forward","back","back"]
    //[["leetcode.com"],["google.com"],["facebook.com"],["youtube.com"],[1],[1],[1],["linkedin.com"],[2],[2],[7]]
    //Output:
    //[null,null,null,null,"facebook.com","google.com","facebook.com",null,"linkedin.com","google.com","leetcode.com"]

    //Explanation:
    //BrowserHistory browserHistory = new BrowserHistory("leetcode.com");
    //    browserHistory.visit("google.com");       // You are in "leetcode.com". Visit "google.com"
    //browserHistory.visit("facebook.com");     // You are in "google.com". Visit "facebook.com"
    //browserHistory.visit("youtube.com");      // You are in "facebook.com". Visit "youtube.com"
    //browserHistory.back(1);                   // You are in "youtube.com", move back to "facebook.com" return "facebook.com"
    //browserHistory.back(1);                   // You are in "facebook.com", move back to "google.com" return "google.com"
    //browserHistory.forward(1);                // You are in "google.com", move forward to "facebook.com" return "facebook.com"
    //browserHistory.visit("linkedin.com");     // You are in "facebook.com". Visit "linkedin.com"
    //browserHistory.forward(2);                // You are in "linkedin.com", you cannot move forward any steps.
    //browserHistory.back(2);                   // You are in "linkedin.com", move back two steps to "facebook.com" then to "google.com". return "google.com"
    //browserHistory.back(7);                   // You are in "google.com", you can move back only one step to "leetcode.com". return "leetcode.com"
    public class ListNode
    {
        public string data;
        public ListNode prev = null;
        public ListNode next = null;
        public ListNode(string data, ListNode prev = null, ListNode next = null)
        {
            this.data = data;
            this.prev = prev;
            this.next = next;
        }

    }
    class Program
    {
        ListNode curr;
        public Program(string homepage)
        {
            curr = new ListNode(homepage);
        }

        public void Visit(string url)
        {

            curr.next = new ListNode(url, curr);
            curr = curr.next;
        }

        public string Back(int steps)
        {
            while (curr.prev != null && steps > 0)
            {
                curr = curr.prev;
                steps -= 1;
            }
            return curr.data;
        }

        public string Forward(int steps)
        {
            while (curr.next != null && steps > 0)
            {
                curr = curr.next;
                steps -= 1;
            }
            return curr.data;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
