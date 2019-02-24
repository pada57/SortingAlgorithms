using CommonStuff;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public static class CombSort
    {
        public static void Sort(int[] array)
        {
            /* 
            This function sorts a list in-place using CombSort11. 
            It works exactly like BubbleSort except that instead of
            looking at i and i+1 when iterating, it looks at i and i+gap.
            This helps reposition small values stuck at the end of the array.
            */
            int size = array.Length;
            int gap = size; // The distance between elements being compared
            bool swapped = true;
            int i; // Our index

            // keep looping until you make
            // a complete pass without swapping
            while (gap > 1 || swapped)
            {

                // 1.3 is the shrink factor.
                // I found it to be the fastest.
                // A gap can not be smaller than 1,
                // hence the "if (gap > 1)"
                if (gap > 1)
                {
                    gap = (int)(gap / 1.3);
                }

                // This is why it is CombSort11 
                // instead of CombSort. I find
                // doing this increases the speed
                // by a few milliseconds.
                if (gap == 9 || gap == 10)
                {
                    gap = 11;
                }

                i = 0;
                swapped = false;

                // Loop through comparing numbers a gap-length apart.
                // If the first number is bigger than the second, swap them.
                while (i + gap < size)
                {
                    if (array[i] > array[i + gap])
                    {
                        array.Swap(i, i + gap);
                        swapped = true;
                    }
                    i++;
                }
            }
        }

    }
}
