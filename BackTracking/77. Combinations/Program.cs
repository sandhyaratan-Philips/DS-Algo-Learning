internal class Program
{
    IList<IList<int>> result = new List<IList<int>>();
    int n;
    public IList<IList<int>> Combine(int n, int k)
    {
        this.n = n;
        var temp = new List<int>();
        solve(1, k, temp);
        return result;
    }

    private void solve(int start, int k, List<int> temp)
    {
        if(k == 0)
        {
            result.Add(new List<int>(temp));
            return;
        }
        if (start > n)
            return;
        temp.Add(start);
        solve(start+1, k-1,temp);
        temp.Remove(start);
        solve(start + 1, k, temp);
    }

    private static void Main(string[] args)
    {
        Program program =new Program();
        program.Combine(n : 4, k : 2);
        Console.WriteLine("Hello, World!");
    }
}