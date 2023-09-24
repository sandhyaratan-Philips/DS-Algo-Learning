using System.Linq;

public class Program
{ int N;
    //O(alpha)
    public class UnionFind
    {
        public int[] parent;
        public int[] rank;

        public UnionFind(int n)
        {
            parent = new int[n];
            rank = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
            }
        }

        public int find(int x)
        {
            if (x == parent[x])
                return x;
            return parent[x] = find(parent[x]);
        }

        public bool union(int x,int y)
        {
            int x_parent=find(x);
            int y_parent=find(y);

            if (x_parent == y_parent)
                return false;
            if (rank[x_parent] > rank[y_parent])
                parent[y_parent] = x_parent;
            else if (rank[x_parent] < rank[y_parent])
                parent[x_parent] = y_parent;
            else
            {
                parent[x_parent] = y_parent;
                rank[y_parent]++;
            }
            return true;
        }

    }
    public IList<IList<int>> FindCriticalAndPseudoCriticalEdges(int n, int[][] edges)
    {
        this.N = n;
        int l=edges.Length;

        int[][] edgeWithIdx = new int[l][];

        for (int i = 0; i < l; i++)
        {
            edgeWithIdx[i] = new int[4]; 
            edgeWithIdx[i][0] = edges[i][0];
            edgeWithIdx[i][1] = edges[i][1];
            edgeWithIdx[i][2] = edges[i][2];
            edgeWithIdx[i][3] = i;
        }
        //O(ElongE)
        edgeWithIdx=edgeWithIdx.OrderBy(x => x[2]).ThenBy(x => x[0]).ToArray();

        int Mst_Wt=Kruskal(edgeWithIdx,-1,-1);

        List<int> critical = new List<int>();
        List<int> pseudoCritical = new List<int>();
        //O(E*E*alpha)
        for (int i = 0; i < l; i++)
        {
            if (Kruskal(edgeWithIdx, i, -1) > Mst_Wt)
            {
                critical.Add(edgeWithIdx[i][3]);
            }else if (Kruskal(edgeWithIdx, -1, i) == Mst_Wt)
            {
                pseudoCritical.Add(edgeWithIdx[i][3]);
            }
        }


        return new List<IList<int>>()
        {
            critical, pseudoCritical
        };
    }

    private int Kruskal(int[][] edgeWithIdx, int skipIdx, int addIdx)
    {
        int sum = 0;
        UnionFind uf = new UnionFind(N);
        if (addIdx != -1)
        {
            uf.union(edgeWithIdx[addIdx][0], edgeWithIdx[addIdx][1]);
            sum += edgeWithIdx[addIdx][2];
        }
        //O(E*alpha)
        for (int i = 0; i < edgeWithIdx.Length; i++)
        {
            if(i==skipIdx)
                continue;
            int u = edgeWithIdx[i][0];
            int v = edgeWithIdx[i][1];
            int wt = edgeWithIdx[i][2];

            int parent_u = uf.find(u);
            int parent_v = uf.find(v);

            if (parent_u != parent_v)
            {
                uf.union(u, v);
                sum += wt;
            }

        }
        //check if graph is connected or not
        for (int i = 0; i < N; i++)
        {
            if (uf.find(i) != uf.find(0))
            {
                return int.MaxValue;
            }
        }
        return sum;
    }

  
    private static void Main(string[] args)
    {
        Program program = new Program();
        program.FindCriticalAndPseudoCriticalEdges(5,new int[][]
        {
            new int[]{0, 1, 1},new int[]{1, 2, 1},new int[]{2, 3, 2},new int[]{0, 3, 2},new int[]{0, 4, 3},new int[]{3, 4, 3},new int[]{1, 4, 6}
        });
        Console.WriteLine("Hello, World!");
    }
}