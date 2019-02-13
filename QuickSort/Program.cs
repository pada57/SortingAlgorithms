using System;
using System.Diagnostics;
using System.Linq;

namespace QuickSort
{
    class Program
    {
        static void QuickSort(int[] array, int firstIndex, int lastIndex)
        {
            if (firstIndex < lastIndex)
            {
                var pivot = ChoosePivot(array, firstIndex, lastIndex);
                pivot = Partition(array, firstIndex, lastIndex, pivot);
                QuickSort(array, firstIndex, pivot - 1);
                QuickSort(array, pivot + 1, lastIndex);
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

        static void Main(string[] args)
        {
            Console.WriteLine("######################");
            Console.WriteLine("##### Quick Sort #####");
            Console.WriteLine("######################");

            Console.WriteLine("Array to sort : ");
            var array = GenerateArray(1000000);

            Console.WriteLine(string.Join(' ', array));

            var w = new Stopwatch();
            w.Start();

            // Sort
            QuickSort(array, 0, array.Length - 1);

            w.Stop();

            Console.WriteLine("Sorted array : ");

            Console.WriteLine(string.Join(' ', array));

            Console.WriteLine($"Sorted {array.Length} items in {w.ElapsedMilliseconds} ms / {w.ElapsedTicks} ticks");

            Console.ReadKey();
        }
        

        private static int[] GenerateArray(int size)
        {
            Random r = new Random();
            return Enumerable.Range(0, size).Select(i => r.Next(size)).ToArray();
        }
    }
}
