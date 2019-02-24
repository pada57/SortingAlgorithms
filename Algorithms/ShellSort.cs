using CommonStuff;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public static class ShellSort
    {
        public static void Sort(int[] array)
        {
            int n = array.Length;

            int h = 1;
            while (h < n / 3)
            {
                h = h * 3 + 1; // 1, 4, 13, 40, 121...
            }

            int j;
            for (int gap = h; gap > 0; gap /= 3)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    var tmp = array[i];
                    for (j = i; j >= gap && tmp.CompareTo(array[j - gap]) < 0; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = tmp;
                }
            }
        }
    }
}
