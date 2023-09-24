public class MinHeap
{
    private int capacity = 10;
    private int size = 0;
    int[] items;

    public MinHeap()
    {
        items = new int[capacity];
    }
    private int getLeftChildIndex(int parentIdx) { return 2 * parentIdx + 1; }
    private int getRightChildIndex(int parentIdx) { return 2 * parentIdx + 2; }
    private int getParentIndex(int childIdx) { return (childIdx -1)/2; }


    private bool hasLeftChildIndex(int idx) { return getLeftChildIndex(idx) < size; }
    private bool hasRightChildIndex(int idx) { return getRightChildIndex(idx) < size; }
    private bool hasParent(int idx) { return getParentIndex(idx) >=0; }
    

    private int leftChild(int idx) { return items[getLeftChildIndex(idx)]; }
    private int rightChild(int idx) { return items[getRightChildIndex(idx)]; }
    private int parent(int idx) { return items[getParentIndex(idx)]; }

    private void swap(int idxOne,int idxTwo)
    {
        int temp = items[idxOne];
        items[idxOne] = items[idxTwo];
        items[idxTwo] = temp;
    }

    private void ensureExtraCapacity()
    {
        if(size==capacity)
        {
            int[] temp = new int[capacity*2];
            Array.Copy(items,temp,capacity);
            items = temp;
            capacity *= 2;
        }
    }

    public int peek()
    {
        if(size==0) throw new ArgumentNullException("size is zero");
        return items[0];
    }
    public int pull()
    {
        if(size==0) throw new ArgumentNullException("size is zero");

        int item = items[0];
        items[0] = items[size - 1];
        size--;
        heapifyDown();
        return item;
    }

    public void add(int item)
    {
        ensureExtraCapacity();
        items[size]= item;
        size++;
        heapifyUp();
    }

    private void heapifyUp()
    {
        int idx=size-1;

        while(hasParent(idx) && parent(idx) > items[idx])
        {
            swap(getParentIndex(idx),idx);
            idx = getParentIndex(idx);
        }
    }

    private void heapifyDown()
    {
        int idx = 0;

        while (hasLeftChildIndex(idx))
        {
            int smallerChildIdx=getLeftChildIndex(idx);
            if(hasRightChildIndex(idx) && rightChild(idx)<leftChild(idx))
            {
                smallerChildIdx = rightChild(idx);
            }
            if (items[idx] < items[smallerChildIdx])
                break;
            else
            {
                swap(idx, smallerChildIdx);
            }

            idx = smallerChildIdx;
        }
    }

}



internal class Program
{
    private static void Main(string[] args)
    {

        MinHeap minHeap = new MinHeap();
        minHeap.add(40);
        minHeap.add(30);
        minHeap.add(80);
        minHeap.add(70);


        Console.WriteLine("Hello, World!");
    }
}