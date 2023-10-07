internal class Program
{
    private static void Main(string[] args)
    {
        MyHashMap myHashMap = new MyHashMap();
        myHashMap.Put(1, 1);
        Console.WriteLine("Hello, World!");
    }
}
public class MyHashMap
{
    List<KeyValuePair<int,int>>[] bucket;
    int size;
    public MyHashMap()
    {
        size = (int)1e4;
        bucket = new List<KeyValuePair<int, int>>[size];
        for(int i=0;i<size;i++)
        {
           bucket[i] = new List<KeyValuePair<int, int>>();
        }
    }

    public void Put(int key, int value)
    {
        int bucketNo=key%size;


        KeyValuePair<int, int> removeItem=default;
        foreach (var item in bucket[bucketNo])
        {
            if (item.Key == key)
            {
                removeItem = item;
            }        
        }
        bucket[bucketNo].Add(new KeyValuePair<int, int>(key,value));
        if (!removeItem.Equals(default(KeyValuePair<int, int>)))
            bucket[bucketNo].Remove(removeItem);
    }

    public int Get(int key)
    {
        int bucketNo = key % size;
        if (bucket[bucketNo].Count == 0)
            return -1;

        foreach (var item in bucket[bucketNo])
        {
            if (item.Key == key)
            {
                return item.Value;
            }
        }
        return -1;
    }

    public void Remove(int key)
    {

        int bucketNo = key % size;


        KeyValuePair<int, int> removeItem = default;
        foreach (var item in bucket[bucketNo])
        {
            if (item.Key == key)
            {
                removeItem = item;
            }
        }
        if (!removeItem.Equals(default(KeyValuePair<int, int>)))
            bucket[bucketNo].Remove(removeItem);
    }
}