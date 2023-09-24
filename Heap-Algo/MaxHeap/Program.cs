public class MaxHeap
{
    int capacity = 10;
    int size = 0;

    int[] items;
    public MaxHeap()
    {
        items = new int[capacity];
    }

    private int getLeftChildIdx(int idx) { return idx * 2 + 1; }
    private int getRightChildIdx(int idx) { return idx * 2 + 2; }
    private int getParentIdx(int idx) { return (idx-1)/2; }

    private int leftChild(int idx) { return items[getLeftChildIdx(idx)]; }
    private int rightChild(int idx) { return items[getRightChildIdx(idx)]; }
    private int parent(int idx) { return items[getParentIdx(idx)]; }

    private bool hasLeftChild(int idx) { return getLeftChildIdx(idx) < size; }
    private bool hasRightChild(int idx) { return getRightChildIdx(idx) < size; }
    private bool hasParent(int idx) { return getParentIdx(idx) >= 0; ; }

    private void swap(int idxOne, int idxTwo)
    {
        int temp = items[idxOne];
        items[idxOne] = items[idxTwo];
        items[idxTwo] = temp;
    }

    private void ensureExtraCapacity()
    {
        if (size == capacity)
        {
            int[] temp = new int[capacity * 2];
            Array.Copy(items, temp, capacity);
            items = temp;
            capacity *= 2;
        }
    }

    public int peek()
    {
        if (size == 0) throw new ArgumentNullException("size is zero");
        return items[0];
    }

    public void add(int item)
    {
        ensureExtraCapacity();
        items[size++] = item;
        heapifyUp();
    }

    public int pull()
    {
        if (size == 0) throw new ArgumentNullException("size is zero");

        int item = items[0];
        size--;
        heapifyDown();
        return item;
    }

    private void heapifyDown()
    {
        int idx = 0;

        while (hasLeftChild(idx))
        {
            int gretestChildIdx=getLeftChildIdx(idx);
            if(hasRightChild(idx) && rightChild(idx) > leftChild(idx))
            {
                gretestChildIdx = getRightChildIdx(idx);
            }

            if (items[idx] > items[gretestChildIdx])
                break;
            else
            {
                swap(idx, gretestChildIdx);
            }
            idx = gretestChildIdx;

        }


    }

    private void heapifyUp()
    {
        int idx = size - 1;
        while(hasParent(idx) && parent(idx) < items[idx])
        {
            swap(getParentIdx(idx), idx);
            idx=getParentIdx(idx);
        }
    }

}

internal class Program
{
    private static void Main(string[] args)
    {
        MaxHeap maxHeap = new MaxHeap();
        maxHeap.add(40);
        maxHeap.add(30);
        maxHeap.add(80);
        maxHeap.add(70);
        Console.WriteLine("Hello, World!");
    }
}