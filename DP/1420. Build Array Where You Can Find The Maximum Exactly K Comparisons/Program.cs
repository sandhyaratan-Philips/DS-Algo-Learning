internal class Program
{
    int N; int M; int K; int mod = (int)(1e9 + 7);
    int[][][] memo;
    public int NumOfArrays(int n, int m, int k)
    {
        memo = new int[51][][];

        for (int i = 0; i < 51; i++)
        {
            memo[i] = new int[51][];
            for (int j = 0; j < 51; j++)
            {
                memo[i][j] = new int[101];
                Array.Fill(memo[i][j], -1);
            }
        }

        N = n; M = m; K = k;
        return solve(0, 0, 0);
    }

    private int solve(int idx, int searchCost, int max)
    {
        if (idx == N)
        {
            if (searchCost == K)
                return 1;

            return 0;
        }

        if (memo[idx][searchCost][max] != -1)
            return memo[idx][searchCost][max];

        int res = 0;
        for (int i = 1; i <= M; i++)
        {
            if (i > max)
            {
                res =(res+ solve(idx + 1, searchCost + 1, i))%mod;
            }
            else
            {
                res=(res+ solve(idx + 1, searchCost, max)) % mod;
            }
        }
        return memo[idx][searchCost][max]= res % mod;

    }

    private static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine(program.NumOfArrays(n: 2, m: 3, k: 1));
        Console.WriteLine("Hello, World!");
    }
}