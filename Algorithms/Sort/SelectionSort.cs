/* partial class Sort
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

 */
public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> map = new();
        for (int i = 0; i < nums.Length; i++)
            map[nums[i]]++;
        PriorityQueue<int, int> pq = new();
        int index = 0;
        foreach (var entry in map)
        {
            if (index++ < k)
                pq.Enqueue(entry.Key, entry.Value);
            else
                break;
        }
        foreach (var entry in map)
        {
            if (entry.Value > pq.Peek())
            {
                pq.DequeueEnqueue(entry.Key, entry.Value);
            }
        }
        int[] res = new int[k];
        for (int i = 0; i < k; i++)
        {
            res[i] = pq.Dequeue();
        }

        return res;
    }
}