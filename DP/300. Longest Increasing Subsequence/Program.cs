internal class Program
{
    private int n;
    int[][] memo;
    public int LengthOfLIS(int[] nums)
    {
        n = nums.Length;
        memo=new int[2501][];
        for(int i = 0;i< 2501; i++)
        {
            memo[i] = new int[2501];
            Array.Fill(memo[i], -1);
        }
        return solve(0, -1, nums);
    }

    private int solve(int i, int p, int[] nums)
    {
        if (i >= n)
            return 0;

        if (p!=-1 && memo[i][p] != -1)
            return memo[i][p];

        int take = 0;
        if (p == -1 || nums[p] < nums[i])
            take = 1 + solve(i + 1, i, nums);
        int skip =solve(i + 1, p, nums);
        if (p != -1)
            memo[i][p] = Math.Max(skip, take);

        return Math.Max(skip, take);
    }

    private static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine(program.LengthOfLIS(new int[] { 0, 1, 0, 3, 2, 3 }));
    }
}