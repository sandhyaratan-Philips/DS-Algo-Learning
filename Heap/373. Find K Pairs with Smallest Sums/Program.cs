internal class Program
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        var result = new List<IList<int>>();
        var pq = new PriorityQueue<List<int>, int>(Comparer<int>.Create((p1Sum, p2Sum) => p2Sum - p1Sum));

        for (var i = 0; i < nums1.Length && i < k; i++)
        {
            for (var j = 0; j < nums2.Length && j < k; j++)
            {
                var pair = new List<int> { nums1[i], nums2[j] };
                if (pq.Count < k)
                {
                    pq.Enqueue(pair, pair.Sum());
                }
                else
                {
                    if (nums1[i] + nums2[j] > pq.Peek()[0] + pq.Peek()[1])
                    {
                        break;
                    }
                    pq.Dequeue();
                    pq.Enqueue(pair, pair.Sum());
                }
            }
        }

        while (pq.Count > 0)
        {
            result.Add(pq.Dequeue());
        }

        return result;
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        
        }
    }
}