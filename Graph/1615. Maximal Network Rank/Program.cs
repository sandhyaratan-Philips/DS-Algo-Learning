internal class Program
{
    public int MaximalNetworkRank(int n, int[][] roads)
    {
        //approch one
        //List<List<int>> adj = new List<List<int>>();
        //int maxRank = 0;
        //for (int i = 0; i < n; i++)
        //{
        //    adj.Add(new List<int>());
        //}

        //for (int i = 0;i < roads.Length; i++)
        //{
        //    adj[roads[i][0]].Add(roads[i][1]);
        //    adj[roads[i][1]].Add(roads[i][0]);
        //}

        //for(int i = 0;i<n ; i++)
        //{
        //    for(int j = i+1;j < n ; j++)
        //    {
        //        int totalRank = adj[i].Count + adj[j].Count;
        //        if (adj[i].Contains(j))
        //        {
        //            totalRank--;
        //        }

        //        maxRank= Math.Max(maxRank, totalRank);
        //    }
        //}
        //return maxRank;

        //approch 2

        int maxRank = 0;
        int[] arr = new int[n];
        bool[,] connected = new bool[n, n];

        for (int i = 0; i < roads.Length; i++)
        {
            //calculate no. of connected node
            arr[roads[i][0]]++;
            arr[roads[i][1]]++;
            connected[roads[i][0], roads[i][1]] = true;
            connected[roads[i][1], roads[i][0]] = true;
        }

        for (int i = 0;i < n;i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int totalRank = arr[i] + arr[j];
                if (connected[i,j]||connected[j,i])
                {
                    totalRank--;
                }

                maxRank = Math.Max(maxRank, totalRank);
            }
        }
    return maxRank;
    }
    private static void Main(string[] args)
    {
        Program program = new Program();
        //Console.WriteLine(program.MaximalNetworkRank(5, new int[][]{
        //    new int[]{0, 1},
        //    new int[]{0, 3},
        //    new int[]{1, 2},
        //    new int[]{1, 3},
        //    new int[]{2, 3},
        //    new int[]{2, 4}
        //    }));
        Console.WriteLine(program.MaximalNetworkRank(8, new int[][]{
            new int[]{0, 1},
            new int[]{1, 2},
            new int[]{2, 3},
            new int[]{2, 4},
            new int[]{5, 6},
            new int[]{5, 7}
            }));
    }
}