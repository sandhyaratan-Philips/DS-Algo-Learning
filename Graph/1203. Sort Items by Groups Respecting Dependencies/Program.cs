using System.Text.RegularExpressions;

internal class Program
{
    public int[] SortItems(int n, int m, int[] group, IList<IList<int>> beforeItems)
    {
        for (int i = 0; i < n; i++)
        {
            if (group[i] == -1)
                group[i] = m++;
        }
        Dictionary<int, List<int>> groupToItemInOrder = new Dictionary<int, List<int>>();
        //make group graph n group indegree
        Dictionary<int, List<int>> itemGraph = new Dictionary<int, List<int>>();
        int[] itemIndegree = new int[n];

        for (int i = 0; i < n; i++)
        {
            itemGraph.Add(i, new List<int>());
        }

        //make group graph n group indegree
        Dictionary<int, List<int>> groupGraph = new Dictionary<int, List<int>>();
        int[] groupIndegree = new int[m];
        for (int i = 0; i < m; i++)
        {
            groupGraph.Add(i, new List<int>());
            groupToItemInOrder.Add(i, new List<int>());
        }

        //fill all above
        for (int i = 0; i < n; i++)
        {
            foreach (int prev in beforeItems[i])
            {
                itemGraph[prev].Add(i);
                itemIndegree[i]++;

                if (group[i] != group[prev])
                {
                    groupGraph[group[prev]].Add(group[i]);
                    groupIndegree[group[i]]++;
                }
            }
        }

        //call topologicalSort
        List<int> itemOrder = topologicalSort(itemGraph, itemIndegree);
        List<int> GraphOrder = topologicalSort(groupGraph, groupIndegree);

        

        foreach (int item in itemOrder)
        {
            int itemGroup = group[item];
            groupToItemInOrder[itemGroup].Add(item);
        }

        List<int> res = new List<int>();

        foreach (int g in GraphOrder)
        {
            res.AddRange(groupToItemInOrder[g]);
        }
        return res.ToArray();
    }

    private List<int> topologicalSort(Dictionary<int, List<int>> adj, int[] indegree)
    {
        Queue<int> queue = new Queue<int>();

        for (int i = 0; i < adj.Count; i++)
        {
            if (indegree[i]==0)
                queue.Enqueue(i);
        }

        List<int> result = new List<int>();
        while(queue.Count > 0)
        {
            int u=queue.Dequeue();
            result.Add(u);

            foreach (int v in adj[u])
            {
                indegree[v]--;
                if (indegree[v]==0)
                    queue.Enqueue(v);
            }

        }

        return result.Count==adj.Count?result:new List<int>();
    }

    private static void Main(string[] args)
    {
        Program program = new Program();
        program.SortItems(n: 8, m: 2, group: new int[] { -1, -1, 1, 0, 0, 1, 0, -1 }, beforeItems: new int[][] { new int[] { }, new int[] { 6 }, new int[] { 5 }, new int[] { 6 }, new int[] { 3, 6 }, new int[] { }, new int[] { }, new int[] { } });
        Console.WriteLine("Hello, World!");
    }
}