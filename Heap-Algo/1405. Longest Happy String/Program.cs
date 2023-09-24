using System.Collections.Generic;
using System.Text;

internal class Program
{
    public string LongestDiverseString(int a, int b, int c)
    {
        var sb=new StringBuilder();
        var pq=new PriorityQueue<char,int>(Comparer<int>.Create((a,b)=>b.CompareTo(a)));
        if (a != 0) pq.Enqueue('a', a);
        if (b != 0) pq.Enqueue('b', b);
        if (c != 0) pq.Enqueue('c', c);

        while(pq.Count > 0)
        {
            pq.TryDequeue(out var currChar, out var currCount);
            int n = sb.Length;
            if (n>=2 && sb[n - 1] == sb[n-2] && sb[n - 1] == currChar)
            {
                if(!pq.TryDequeue(out var nextChar, out var nextCount))
                {
                    break;
                }
                sb.Append(nextChar);
                nextCount--;
                if (nextCount != 0)
                    pq.Enqueue(nextChar, nextCount);
            }
            else
            {
                sb.Append(currChar);
                currCount--;
            }
            if(currCount!=0)
                pq.Enqueue(currChar,currCount);
           
        }

        return sb.ToString();

    }
    private static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine(program.LongestDiverseString(a : 1, b : 1, c : 7));
    }
}