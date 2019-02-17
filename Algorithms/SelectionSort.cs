using CommonStuff;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public static class SelectionSort
    {
        public static void Sort(int[] array)
        {
            for (int i =0; i < array.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    array.Swap(min, i);
                }
            }
        }
    }
}
