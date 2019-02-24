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

            while (h >= 1)
            {
                for (int i = h; i < n; i++)
                {
                    for (int j = 0; j >= h && array[j] < array[j - h]; j -= h)
                    {
                        array.Swap(j, j - h);
                    }
                }
                h /= 3;
            }
        }
    }
}
