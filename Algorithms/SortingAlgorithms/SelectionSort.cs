partial class Sort
{
    
    public static void SelectionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int min = arr[i];
            int index = 0;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < min)
                {
                    min = arr[j];
                    index = j;
                }
            }
            if (arr[i] != min)
            {
                int temp = arr[i];
                arr[i] = arr[index];
                arr[index] = temp;
            }
        }
    }
}


