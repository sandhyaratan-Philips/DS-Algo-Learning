internal class Program
{
    public int LengthOfLIS(int[] nums)
    {
        int n=nums.Length;
        int[] state = new int[n];
        int maxLis = 1; // for input like [7,7,7,7,7,7,7,7]
        Array.Fill(state, 1);
        for(int i=0; i<n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                {
                    state[i] = Math.Max(state[i], state[j] + 1);
                    maxLis = Math.Max(maxLis, state[i]);
                }
            }
        }
        return maxLis;
    }
    private static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine(program.LengthOfLIS(new int[] { 0, 1, 0, 3, 2, 3 }));
    }
}