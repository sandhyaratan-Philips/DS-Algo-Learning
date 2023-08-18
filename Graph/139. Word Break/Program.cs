internal class Program
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        int n=s.Length;
        HashSet<string> words = new HashSet<string>(wordDict);
        bool[] seen = new bool[n+1];
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(0);

        while (queue.Count > 0)
        {
           int  start=queue.Dequeue();
            if (start == n)
            {
                return true;
            }

            for (int end=start+1; end <= n; end++)
            {
                if (seen[end])
                    continue;

                if (words.Contains(s.Substring(start, end-start))){
                    queue.Enqueue(end);
                    seen[end]=true;
                }
            }
        }

        return false;


    }
    private static void Main(string[] args)
    {
        Program program= new Program();
        Console.WriteLine(program.WordBreak(s : "applepenapple", wordDict :new List<string>() { "apple", "pen" }));
    }
}