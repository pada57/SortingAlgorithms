using System;
using System.Collections.Generic;
using System.Text;

namespace CommonStuff
{
    public static class ArrayStuff
    {
        public static void Swap(this int[] array, int i, int j)
        {
            int valI = array[i];
            array[i] = array[j];
            array[j] = valI;
        }

        public static int[] Sub(this int[] array, int start, int end)
        {
            var sub = new int[end - start + 1];
            Array.ConstrainedCopy(array, start, sub, 0, sub.Length);
            return sub;
        }
    }
}
