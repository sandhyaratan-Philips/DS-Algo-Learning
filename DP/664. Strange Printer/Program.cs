internal class Program
{
    int[][] dp;
    public int StrangePrinter(string s)
    {
        int n=s.Length;
        dp= new int[n][];

        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                dp[i][j] = -1;
            }
        }

        return solve(s, n, 0, n - 1)+1;
    }

    private int solve(string s, int n, int l, int r)
    {
        if (dp[l][r] != -1)
        {
            return dp[l][r];
        }

        dp[l][r] = n;

        int j = -1;

        for (int i = l;i < r;i++)
        {
            if (s[i] != s[r] && j == -1)
            {
                j = i;
            }

            if (j != -1)
            {
                dp[l][r] = Math.Min(dp[l][r],Math.Min(1+solve(s,n,j,i),solve(s,n,i+1,r)));
            }
        }
        if (j == -1)
        {
            dp[l][r] = 0;
        }
        return dp[l][r];
    }

    private static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine(program.StrangePrinter("aba"));
        Console.WriteLine("Hello, World!");
    }
}