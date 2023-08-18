internal class Program
{
    int n, goal, k;
    int MOD = 1_000_000_007;
    int[][] t = new int[101][];
    public int NumMusicPlaylists(int n, int goal, int k)
    {
        this.n = n;
        this.goal = goal;
        this.k = k;
        for (int i = 0; i < 101; i++)
        {
            t[i] = new int[101];
            Array.Fill(t[i], -1);
        }
        return (int)solve(0, 0);
    }

    private long solve(int CountUnique, int CountOfSong)
    {
        if (t[CountUnique][CountOfSong] != -1)
            return t[CountUnique][CountOfSong];
        if (CountOfSong == goal)
        {
            if (CountUnique == n)
                return t[CountUnique][CountOfSong]= 1;
            return 0;
        }

        long result = 0;
        //non repeated songs
        if (CountUnique < n)
            result += (n - CountUnique) * (solve(CountUnique + 1, CountOfSong + 1));
        //repeated songs
        if (CountUnique > k)
            result += (CountUnique - k) * (solve(CountUnique, CountOfSong + 1));
        return t[CountUnique][CountOfSong]= (int)(result % MOD);
    }

    private static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine(program.NumMusicPlaylists(n: 2, goal: 3, k: 1));
    }
}