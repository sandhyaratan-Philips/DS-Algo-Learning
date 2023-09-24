internal class Program
{
    Dictionary<int, int> mp;
    int n;
    int[][] memo = new int[2001][];
    public bool CanCross(int[] stones)
    {
        mp = new Dictionary<int, int>();
        n=stones.Length;
        int i = 0;
        foreach (int stone in stones)
        {
            mp.Add(stone, i++);
        }
        for (int j = 0; j < stones.Length; j++)
        {
            memo[j] = new int[2001];
            Array.Fill(memo[j], -1);
        }
        return solve(0, mp[0], stones);
    }

    private bool solve(int PervJump, int CurrStone_idx, int[] stones)
    {
        if (CurrStone_idx == n - 1)
            return true;

        if (memo[CurrStone_idx][PervJump] != -1)
            return Convert.ToBoolean(memo[CurrStone_idx][PervJump]);

        bool res=false;
        for(int i = PervJump - 1; i <= PervJump + 1; i++)
        {
            if (i > 0)
            {
                int next_stone = stones[CurrStone_idx] + i;
                if(mp.ContainsKey(next_stone))
                    res=res||solve(i, mp[next_stone], stones);
            }
        }
        memo[CurrStone_idx][PervJump] = Convert.ToInt32(res);
        return res;
    }

    private static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine(program.CanCross(new int[] { 0, 1, 3, 5, 6, 8, 12, 17 }));
    }
}