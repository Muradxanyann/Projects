using System.Collections.Concurrent;
using System.Diagnostics.Metrics;

class Sort
{
    public static void BubbleSort(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
            for (int j = 0; j < nums.Length - i - 1; j++)
                if (nums[j] > nums[j + 1])
                    (nums[j], nums[j + 1]) = (nums[j + 1], nums[j]);
    }

    public static void SelectionSort(int[] nums)
    {
        int n = nums.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (nums[j] < nums[minIndex])
                    minIndex = j;
            }
            if (minIndex != i)
                (nums[minIndex], nums[i]) = (nums[i], nums[minIndex]);
        }
    }

    public static void InsertionSort(int[] nums)
    {
        int n = nums.Length;
        for (int i = 1; i < n; i++)
        {
            int key = nums[i];
            int j = i - 1;
            while (j >= 0 && nums[j] > key)
            {
                nums[j + 1] = nums[j--];
            }
            nums[j + 1] = key;
        }
    }

    public static void CountingSort(int[] nums)
    {
        int min = nums.Min();
        int max = nums.Max();
        int n = nums.Length;
        int[] count = new int[max - min + 1];
        for (int i = 0; i < count.Length; i++)
        {
            count[nums[i] - min]++;
        }
        for (int i = 1; i < count.Length; i++)
        {
            count[i] += count[i - 1];
        }
        int[] result = new int[max - min + 1];
        for (int i = n - 1; i >= 0; i--)
        {
            int num = nums[i];
            int index = count[num - min] - 1;
            result[index] = num;
            count[num - min]--;
        }
    }

    public static void MergeSort(int[] nums, int l, int r)
    {
        if (l < r)
        {
            int mid = l + (r - l) / 2;
            MergeSort(nums, l, mid);
            MergeSort(nums, mid + 1, r);
            Merge(nums, l, mid, r);
        }

    }
    public static void Merge(int[] nums, int l, int mid, int r)
    {
        List<int> list = new List<int>();
        int l1 = l;
        int l2 = mid + 1;
        while (l1 <= mid && l2 <= r)
        {
            if (nums[l1] <= nums[l2])
                list.Add(nums[l1++]);
            else
                list.Add(nums[l2++]);
        }
        while (l1 <= mid)
            list.Add(nums[l1++]);
        while (l2 <= r)
            list.Add(nums[l2++]);

        for (int i = 0; i < list.Count; i++)
        {
            nums[l + i] = list[i];
        }
    }

    public static void QuickSort(int[] nums, int l, int r)
    {
        if (l >= r) return;
        int median = Partition(nums, l, r);
        QuickSort(nums, l, median - 1);
        QuickSort(nums, median + 1, r);
    }

    private static int Partition(int[] nums, int l, int r)
    {
        int pivot = nums[l];
        int i = l + 1;
        int j = r;
        while (i <= j)
        {
            while (i <= j && nums[i] <= pivot)
                i++;
            while (i <= j && nums[j] > pivot)
                j--;
            if (i < j)
                (nums[i], nums[j]) = (nums[j], nums[i]);
        }
        (nums[l], nums[j]) = (nums[j], nums[l]);
        return j;
        
    }
}
static class Program
{
    static void Main(string[] args)
    {
        int[] array = GenerateRandomArray(10);
        Console.WriteLine("Before sorting");
        Console.WriteLine(string.Join(", ", array));
        Sort.QuickSort(array, 0, array.Length - 1);
        Console.WriteLine("After");
        Console.WriteLine(string.Join(", ", array));

    }
    public static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
            array[i] = random.Next(1, 15);
        return array;
    }
}