using System;
using System.Diagnostics;
using System.Linq;

namespace Algorithms
{
    public static class QuickSort
    {
        public static void Sort(int[] array, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                var pivot = ChoosePivot(array, startIndex, endIndex);
                pivot = Partition(array, startIndex, endIndex, pivot);
                Sort(array, startIndex, pivot - 1);
                Sort(array, pivot + 1, endIndex);
            }
        }

        static int Partition(int[] array, int startIndex, int endIndex, int pivot)
        {
            //swap pivot with last element
            var valuePivot = array[pivot];
            array[pivot] = array[endIndex];
            array[endIndex] = valuePivot;

            // move all elements less than pivot value before
            var j = startIndex;
            for (int i = startIndex; i < endIndex; i++)
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

        static int ChoosePivot(int[] array, int startIndex, int endIndex)
        {
            return (endIndex - startIndex) / 2;
        }
        
        
    }
}
