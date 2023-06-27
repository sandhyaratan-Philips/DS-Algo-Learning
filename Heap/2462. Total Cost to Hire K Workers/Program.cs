internal class Program
{
    public long TotalCost(int[] costs, int k, int candidates)
    {
        int left = 0;
        int right = costs.Length-1;
        long ans = 0L;

        PriorityQueue<int,int> rightPq = new PriorityQueue<int,int>();
        PriorityQueue<int, int> leftPq = new PriorityQueue<int, int>();

        while (k-- > 0)
        {
            while(leftPq.Count <candidates && left <= right)
            {
                leftPq.Enqueue(costs[left], costs[left]);
                left++;
            }

            while (rightPq.Count < candidates && left <= right)
            {
                rightPq.Enqueue(costs[right], costs[right]);
                right--;
            }

            int leftSession=leftPq.Count>0? leftPq.Peek() : int.MaxValue;
            int rightSession = rightPq.Count > 0 ? rightPq.Peek() : int.MaxValue;

            if(leftSession <= rightSession)
            {
                ans += leftPq.Dequeue();
            }
            else
            {
                ans += rightPq.Dequeue();
            }


        }

        return ans;
    }
    private static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine(program.TotalCost(new int[] { 1, 2, 4, 1 }, 3, 3));
        Console.WriteLine("Hello, World!");
    }
}