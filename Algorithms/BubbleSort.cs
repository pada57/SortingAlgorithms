using CommonStuff;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public static class BubbleSort
    {
        public static int[] Sort(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                var sorted = true;
                for (int j = 0; j < i; j++)
                {
                    if (array[j + 1] < array[j])
                    {
                        array.Swap(j, j + 1);
                        sorted = false;
                    }
                }
                if (sorted)
                {
                    break;
                }
            }
            return array;
        }

    }
}
