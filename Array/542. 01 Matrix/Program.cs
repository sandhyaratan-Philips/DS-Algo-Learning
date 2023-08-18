internal class Program
{
    int n, m;
    int[][] res;
    int[][] direction = new int[][] { 
    new int[] { 1, 0 },
    new int[] { 0, 1 },
    new int[] { -1, 0 },
    new int[] { 0, -1 }
    };
    public int[][] UpdateMatrix(int[][] mat)
    {
        this.n = mat[0].Length;
        this.m = mat.Length;

        res = new int[this.m][];
        for (int i = 0; i < m; i++)
        {
            res[i] = new int[n];
            Array.Fill(res[i], -1);
        }

        //bfs
        Queue<(int,int)> q=new System.Collections.Generic.Queue<(int, int)> ();
        
        for (int i = 0;i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 0)
                {
                    res[i][j] = 0;
                    q.Enqueue((i, j));
                }
            }
        }

        while (q.Count > 0)
        {
            var data=q.Dequeue();
            int i=data.Item1, j=data.Item2;

            foreach (var item in direction)
            {
                int i_new = i + item[0];
                int j_new = j + item[1];

                if(i_new>=0 && i_new<m && j_new >= 0 && j_new < n && res[i_new][j_new]==-1)
                {
                    res[i_new][j_new] = res[i][j]+1;
                    q.Enqueue((i_new, j_new));
                }
            }
        }
        return res;

    }
    private static void Main(string[] args)
    {
        Program program = new Program();
       // program.UpdateMatrix(new int[][]
        //{
        //    new int[]{0,0,0},
        //    new int[]{0,1,0},
        //    new int[]{1,1,2}
        //}); 
        program.UpdateMatrix(new int[][]
        {
            new int[]{0},new int[]{0},new int[]{0},new int[]{0},new int[]{0}
        });
        Console.WriteLine("Hello, World!");
    }
}