using CommonStuff;
using System;
using System.Diagnostics;
using System.Linq;

namespace Algorithms
{
    public static class QuickSort
    {
        public static void Sort(int[] array, int left, int right)
        {
            if (left < right && left>= 0 && right >= 0)
            {
                int pivot = Partition(array, left, right);

                if (pivot != -1)
                {
                    Sort(array, left, pivot - 1);
                    Sort(array, pivot + 1, right);
                }
            }
        }

        static int Partition(int[] array, int left, int right)
        {
            if (left > right) return -1;

            //swap pivot with last element
            int valuePivot = array[right];    // choose last one to pivot, easy to code
            
            // move all elements less than pivot value before
            var end = left;
            for (int i = left; i < right; i++)
            {
                if (array[i] < valuePivot)
                {
                    // swap values greater with smaller than pivot
                    array.Swap(end, i);
                    end++;
                }
            }

            // swap first element greater than pivot 
            array.Swap(end, right);

            return end;           
        }       
        
    }
}
