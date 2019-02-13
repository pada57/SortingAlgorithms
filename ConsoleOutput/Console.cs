using CommonStuff;
using Algorithms;
using System;
using System.Diagnostics;

namespace ConsoleOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("###############################");
            Console.WriteLine($"##### Sorting algorithms #####");
            Console.WriteLine("###############################");

            Console.WriteLine("Array to sort : ");
            var array = Generator.NewRandomArray(10000);

            Console.WriteLine(string.Join(' ', array));
          
            SortRun(Algorithm.QuickSort, (int[])array.Clone());
            SortRun(Algorithm.BubbleSort, (int[])array.Clone());

            Console.ReadKey();
        }

        private static void SortRun(Algorithm algorithm, int[] array, bool displaySortedArray = false)
        {
            Console.WriteLine("######################");
            Console.WriteLine($"##### {algorithm} #####");
            Console.WriteLine("######################");

            var w = new Stopwatch();
            w.Start();

            // Sort
            switch (algorithm)
            {
                case Algorithm.QuickSort:
                    QuickSort.Sort(array, 0, array.Length - 1);
                    break;
                case Algorithm.BubbleSort:
                    BubbleSort.Sort(array);
                    break;
                default:
                    throw new NotSupportedException();
            }

            w.Stop();

            if (displaySortedArray)
            {
                Console.WriteLine("Sorted array : ");

                Console.WriteLine(string.Join(' ', array));
            }

            Console.WriteLine($"Sorted {array.Length} items in {w.ElapsedMilliseconds} ms / {w.ElapsedTicks} ticks with {algorithm}");
        }
    }
}
