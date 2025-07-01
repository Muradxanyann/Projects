using System.Data;

partial class Sort
{
    public static void MergeSort(List<int> arr, int l, int r)
    {
        if (l < r)
        {
            int mid = (l + r) / 2;
            MergeSort(arr, l, mid);
            MergeSort(arr, mid + 1, r);
            Merge(arr, l, mid, r);
        }
    }

    public static void Merge(List<int> arr, int l, int mid, int r)
    {
        List<int> temp = new();
        int l1 = l; int r1 = mid;
        int l2 = mid + 1; int r2 = r;
        while (l1 <= r1 && l2 <= r2)
        {
            if (arr[l1] <= arr[l2])
                temp.Add(arr[l1++]);
            else
                temp.Add(arr[l2++]);
        }
        while (l1 <= r1)
            temp.Add(arr[l1++]);
        while (l2 <= r2)
            temp.Add(arr[l2++]);

        for (int i = 0; i < temp.Count; i++)
        {
            arr[l + i] = temp[i];
        }
    }
}

