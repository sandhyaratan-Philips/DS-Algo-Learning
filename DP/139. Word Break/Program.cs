internal class Program
{
    int n;
    public bool WordBreak(string s, IList<string> wordDict)
    {
        n = s.Length;
        return solve(0,s,wordDict);
    }

    private bool solve(int idx, string s, IList<string> wordDict)
    {
        if (idx >= s.Length)
        {
            return true;
        }

        if(wordDict.Contains(s))
        {
            return true;
        }

        for (int l = 1; l < n; l++)
        {
            string temp= s.Substring(idx,l);
            if (!wordDict.Contains(temp) && solve(l,temp,wordDict))
            {
                return true;
            }


        }

        return false;

    }

    private static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine(program.WordBreak(s : "applepenapple", wordDict :new List<string>() { "apple", "pen" }));
    }
}