internal class Program
{
    int n;
    int[][] memo;
    public int FindLongestChain(int[][] pairs)
    {
        memo = new int[1001][];
        for (int i = 0;i< 1001;i++)
        {
            memo[i] = new int[1001];
            Array.Fill(memo[i],-1);
        }
        n=pairs.Length;
        Array.Sort(pairs, (a, b) => a[0] - b[0]);
        return solve(-1, 0, pairs);
    }

    private int solve(int prev_idx, int curr_idx, int[][] pairs)
    {
        if(curr_idx>=n)
            return 0;

        if(prev_idx!=-1 && memo[prev_idx][curr_idx]!=-1)
            return memo[prev_idx][curr_idx];

        int take = 0;
        if(prev_idx==-1|| pairs[prev_idx][1] < pairs[curr_idx][0])
        {
            take=1+solve(curr_idx,curr_idx+1, pairs);
        }
        int skip = solve(prev_idx, curr_idx + 1, pairs);

        if (prev_idx != -1)
            memo[prev_idx][curr_idx]= Math.Max(take, skip);

        return Math.Max(take, skip);
    }

    private static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine(program.FindLongestChain(new int[][]
        {
            new int[] {3,10},new int[] {3, 7},new int[] {7, 10},new int[] {7, 9},new int[] {-1, 7},new int[] {-9, 5},new int[] {2, 8 } 
        }));
    }
}