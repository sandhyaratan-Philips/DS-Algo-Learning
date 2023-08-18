using System.Diagnostics;

internal class Program
{
    int n;
    List<int> ans;
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        LinkedList<int> dequeue= new LinkedList<int>();
        ans = new List<int>();
        int n=nums.Length;

        for (int i = 0; i < n; i++)
        {
            while (dequeue.Count > 0 && dequeue.Last.Value <= i - k)
            {
                dequeue.RemoveLast();
            }

            while (dequeue.Count > 0 && nums[dequeue.First.Value] <= nums[i])
            {
                dequeue.RemoveFirst();
            }

            dequeue.AddFirst(i);

            if (i >= k - 1)
            {
                ans.Add(nums[dequeue.Last.Value]);
            }
        }




        return ans.ToArray();
    }


    private static void Main(string[] args)
    {
        Program program = new Program();
        program.MaxSlidingWindow(new int[] {1, 3, 1, 2, 0, 5},3);
        //program.MaxSlidingWindow(new int[] {1, 3, -1, -3, 5, 3, 6, 7},3);
        //program.MaxSlidingWindow(new int[] {7,4,2},2);
        Console.WriteLine("Hello, World!");
    }
}