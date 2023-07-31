internal class Program
{
    int[][] pairs = new int[][]
    {
        new int[] { 100, 0 },
         new int[] { 75, 25 },
         new int[] { 50, 50 },
         new int[] { 25, 75 },
    };
    double[][] dp;
    public double SoupServings(int n)
    {
        if (n >= 4000)
            return 1;
        dp = new double[n + 1][];
        for (int i = 0; i < n+1; i++)
        {
            dp[i]=new double[n+1];
            Array.Fill(dp[i], -1);
        }
        return solve(n,n);
    }

    private double solve(int An, int Bn)
    {
        
        if (An <= 0 && Bn<=0)
            return 0.5;

        if (An <= 0)
            return  1.0;

        if (Bn <= 0)
            return 0;

        if (dp[An][Bn] != -1)
        {
            return dp[An][Bn];
        }

        double prob = 0;
        foreach(var pair in pairs)
        {
            prob += solve(An - pair[0], Bn - pair[1]);
        }
        return dp[An][Bn]=0.25 * prob;
    }

    private static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine(program.SoupServings(50));
    }
}