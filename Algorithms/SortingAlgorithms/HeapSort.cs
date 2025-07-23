
class MaxHeap
{
    public int[] arr { get; private set; }
    public int Count { get; private set; }
    public int Capacity { get; private set; }
    public MaxHeap(int capacity)
    {
        arr = new int[capacity];
        Count = 0;
        Capacity = capacity;

        BuildMaxHeap(arr); 
    }

    private static void BuildMaxHeap(int[] arr)
    {
        int n = arr.Length;
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }
    }

    private static void Heapify(int[] arr, int n, int i)
    {
        int largest = i;
        int leftChild = i * 2 + 1;
        int rightChild = i * 2 + 2;
        if (leftChild < n && arr[largest] < arr[leftChild])
            largest = leftChild;
        if (rightChild < n && arr[largest] < arr[rightChild])
            largest = rightChild;
        if (largest != i)
        {
            (arr[i], arr[largest]) = (arr[largest], arr[i]);
            Heapify(arr, n, largest);
        }
    }
    public void Print()
    {
        for (int i = 0; i < Count; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }

    public void Pop()
    {
        (arr[0], arr[^1]) = (arr[^1], arr[0]);
        Count--;
        Heapify(arr, Count, 0);

    }
    public void Resize()
    {
        int newCapacity = Capacity * 2;
        int[] newArr = new int[newCapacity];
        for (int i = 0; i < Count; i++)
        {
            newArr[i] = arr[i];
        }
        arr = newArr;
        Capacity = newCapacity;
    }
    public void Push(int elem)
    {
        if (Count == Capacity)
            Resize();
        arr[Count] = elem;
        int i = Count;
        Count++;

        while (i > 0)
        {
            int parent = (i - 1) / 2;
            if (arr[i] <= arr[parent])
                break;
            (arr[i], arr[parent]) = (arr[parent], arr[i]);
            i = parent; 
        }
    }
    public int Top() => this.arr[0];
}

static class Program
{
    static void Main(string[] args)
    {
        MaxHeap MaxHeap = new MaxHeap(10);
        MaxHeap.Push(7);
        MaxHeap.Push(8);
        MaxHeap.Push(19);
        MaxHeap.Push(140);
        MaxHeap.Push(43);
        MaxHeap.Print();


    }
    public static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = random.Next(0, 30);
        }
        return arr;
    }



}