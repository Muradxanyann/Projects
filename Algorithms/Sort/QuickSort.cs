partial class Sort
{
    public static void QuickSort(int[] arr, int l, int r)
    {
        if (l >= r) return;
        int median = Intersection(arr, l, r);
        QuickSort(arr, l, median - 1);
        QuickSort(arr, median + 1, r);

        /* when pivot first {10, 2 ,55, 66, 7 ,1}
        {10, 2 ,1, 7, 66 ,55}
        /* 
        1) i stop on 55, j stop in 1, swap {10, 2 ,1, 66, 7 ,55}
        2) i stop in 66, j stop in 7 swap {10, 2 ,1, 7, 66 ,55}
        3) i stop  in 66, j stop in 7 but i > j now, its mean swap {7, 2 ,1, 10, 66 ,55}, 
            10 is pivot and both sides are sorted, so return j which is 3
        -----
        left side { 7, 2, 1} from l to median(not included)
        1)pivot is 7, i = 2, j = 1 || i stop to 2 (because less than j which is 3), j stop to 1
            swap { 1, 2, 7}
        
        right side from median (not included to r)
        {66, 55}
        pivot = 66,  i = 55, j == 55 
        swap {55, 66}
        */
    }
    //private static readonly Random rand = new();
    public static int Intersection(int[] arr, int l, int r)
    {
       /*  int mid = (l + r) / 2;
        int pivotIndex = MedianOfThree(arr, l, mid, r); 
        Swap(arr, pivotIndex, l);*/

        int pivot = arr[r];
        int i = l ; int j = r - 1 ;
        while (i <= j)
        {
            while (i <= j && arr[i] <= pivot) i++;
            while (i <= j && arr[j] > pivot) j--;
            if (i < j)
                Swap(arr, i, j);
        }
        Swap(arr, r, i);
        return i;
    }

    private static int MedianOfThree(int[] arr, int l, int mid, int r)
    {
        int A = arr[l], B = arr[mid], C = arr[r];
        if ((A > B) != (A > C)) return l;
        if ((B > A) != (B > C)) return mid;
        return r;
    }

    private static void Swap(int[] arr, int v1, int v2)
    {
        int temp = arr[v1];
        arr[v1] = arr[v2];
        arr[v2] = temp;
    }
}
