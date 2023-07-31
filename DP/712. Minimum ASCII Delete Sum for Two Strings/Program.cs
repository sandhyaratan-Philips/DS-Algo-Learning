internal class Program
{
    int n, m;
    int[][] dp = new int[1001][];
    public int MinimumDeleteSum(string s1, string s2)
    {
        n = s1.Length; m = s2.Length;
        for (int i = 0; i < 1001; i++)
        {
            dp[i] = new int[1001];
            Array.Fill(dp[i],-1);
        }
       
        return solve(s1, 0, s2, 0);
    }

    private int solve(string s1, int i, string s2, int j)
    {
        if (dp[i][j] != -1)
            return dp[i][j];
        if (i>=n && j>=m)
            return 0;
        if(i>=n)
            return dp[i][j] = s2[j]+solve(s1, i, s2, j+1);
        if(j>=m)
            return dp[i][j] = s1[i]+solve(s1, i+1, s2, j);

        if (s1[i] == s2[j])
            return dp[i][j] = solve(s1, i + 1, s2, j + 1);

        int deleteIthofS1= s1[i]+ solve(s1,i+1, s2, j);
        int deleteJthofS2 = s2[j] + solve(s1, i , s2, j+1);

        return dp[i][j]= Math.Min(deleteJthofS2 , deleteIthofS1);
    }

    private static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine(program.MinimumDeleteSum(s1:"delete", s2: "leet"));
    }
}