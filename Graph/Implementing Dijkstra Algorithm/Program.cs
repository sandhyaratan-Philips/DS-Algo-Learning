internal class Program
{
    public List<int> dijkstra(int V, List<List<List<int>>> adj, int S)
    {
        int[] ans = new int[V];


        Array.Fill(ans, int.MaxValue);
        ans[S] = 0;
        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < V; i++)
            map.Add(i, 1000000007);

        Queue<int> nodes = new Queue<int>();
        Queue<int> distances = new Queue<int>();
        nodes.Enqueue(S);
        distances.Enqueue(0);
        map[S] = 0;
        while (nodes.Count != 0)
        {
            int node = nodes.Dequeue();
            int distance = distances.Dequeue();
            for (int i = 0; i < adj[node].Count(); i++)
            {
                int newNode = adj[node][i][0];
                int extraDistance = adj[node][i][1];
                if (distance + extraDistance < map[newNode])
                {
                    map[newNode] = distance + extraDistance;
                    nodes.Enqueue(newNode);
                    distances.Enqueue(distance + extraDistance);
                }
            }
        }

        for (int i = 0; i < V; i++)
            ans[i] = map[i];
        return ans.ToList();
    }
    private static void Main(string[] args)
    {
        List<List<List<int>>> adj = new List<List<List<int>>>();
        var v=new List<List<int>>();
        v.Add(new List<int> { 1,6 });
        adj.Add(v);
        v.Add(new List<int> { 3,1 });
        adj.Add(v);
        v.Add(new List<int> { 3,6 });
        adj.Add(v);
        Program program=new Program();
        program.dijkstra(3, adj,2);
        Console.WriteLine("Hello, World!");
    }
}