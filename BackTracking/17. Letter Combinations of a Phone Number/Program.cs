internal class Program
{
    Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
    List<string> result = new List<string>();
    public IList<string> LetterCombinations(string digits)
    {
        if(digits.Length == 0) return result;
        map.Add("2", new List<string>() { "a", "b", "c" });
        map.Add("3", new List<string>() { "d", "e", "f" });
        map.Add("4", new List<string>() { "g", "h", "i" });
        map.Add("5", new List<string>() { "j", "k", "l" });
        map.Add("6", new List<string>() { "m", "n", "o" });
        map.Add("7", new List<string>() { "p", "q", "r","s" });
        map.Add("8", new List<string>() { "t", "u", "v" });
        map.Add("9", new List<string>() { "w", "x", "y","z" });
       
        solve(0,new List<string>(), digits);
        return result;
    }

    private void solve(int idx, List<string> temp, string digits)
    {
        if (idx>= digits.Length)
        {
            result.Add(string.Join("",temp));
            return;
        }

        char ch = digits[idx];

        var str = map[ch.ToString()];
        for (int i = 0; i < str.Count; i++)
        {
            temp.Add(str[i]);
            int n= temp.Count-1;
            solve(idx + 1, temp, digits);
            temp.RemoveAt(n);
        }
    }

    private static void Main(string[] args)
    {
        Program program = new Program();
        program.LetterCombinations("999");
        Console.WriteLine("Hello, World!");
    }
}