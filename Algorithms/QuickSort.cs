using System;
using System.Diagnostics;
using System.Linq;

namespace Algorithms
{
    public static class QuickSort
    {
        public static void Sort(int[] array, int firstIndex, int lastIndex)
        {
            if (firstIndex < lastIndex)
            {
                var pivot = ChoosePivot(array, firstIndex, lastIndex);
                pivot = Partition(array, firstIndex, lastIndex, pivot);
                Sort(array, firstIndex, pivot - 1);
                Sort(array, pivot + 1, lastIndex);
            }
        }

        static int Partition(int[] array, int firstIndex, int lastIndex, int pivot)
        {
            //swap pivot with last element
            var valuePivot = array[pivot];
            array[pivot] = array[lastIndex];
            array[lastIndex] = valuePivot;

            // move all elements less than pivot value before
            var j = firstIndex;
            for (int i = firstIndex; i < lastIndex; i++)
            {
                if (array[i] <= valuePivot)
                {
                    // swap values greater with smaller than pivot
                    var greaterValueThanPivot = array[j];
                    array[j] = array[i];
                    array[i] = greaterValueThanPivot;
                    j++;
                }
            }

            // swap first element greater than pivot 
            array[pivot] = array[j];
            array[j] = valuePivot;

            return j;
        }

        static int ChoosePivot(int[] array, int firstIndex, int lastIndex)
        {
            return (lastIndex - firstIndex) / 2;
        }
        
        
    }
}
