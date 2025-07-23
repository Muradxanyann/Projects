using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sort
{
    partial class Sort
    {
        public int[] StableCountingSort(int[] array)
        {
            int min = array.Min();
            int max = array.Max();
            int range = max - min + 1;

            int[] count = new int[range];

            foreach (int num in array)
                count[num - min]++;

            for (int i = 1; i < range; i++)
                count[i] += count[i - 1];

            int[] output = new int[array.Length];
            for (int i = array.Length - 1; i >= 0; i--)
            {
                int num = array[i];
                int idx = count[num - min] - 1;
                output[idx] = num;
                count[num - min]--;
            }

            return output;
        }
    }
}