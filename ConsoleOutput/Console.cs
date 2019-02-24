using CommonStuff;
using Algorithms;
using System;
using System.Diagnostics;
using System.Linq;

namespace ConsoleOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("###############################");
            Console.WriteLine($"##### Sorting algorithms #####");
            Console.WriteLine("###############################");
                        
            var array = Generator.NewRandomArray(10000);

            Console.WriteLine("Array to sort : ");
            Console.WriteLine(string.Join(' ', array));
          
            Run(Algorithm.QuickSort, (int[])array.Clone());
            Run(Algorithm.BubbleSort, (int[])array.Clone());
            Run(Algorithm.InsertionSort, (int[])array.Clone());
            Run(Algorithm.SelectionSort, (int[])array.Clone());
            Run(Algorithm.ShellSort, (int[])array.Clone());
            //Run(Algorithm.MergeSort, (int[])array.Clone());

            Console.ReadKey();
        }

        private static void Run(Algorithm algorithm, int[] array, bool displaySortedArray = false)
        {
            Console.WriteLine("######################");
            Console.WriteLine($"##### {algorithm} #####");
            Console.WriteLine("######################");

            var w = new Stopwatch();
            w.Start();
            Sort(algorithm, array);

            w.Stop();

            if (displaySortedArray)
            {
                Console.WriteLine("Sorted array : ");

                Console.WriteLine(string.Join(' ', array));
            }

            Console.WriteLine($"Sorted {array.Length} items in {w.ElapsedMilliseconds} ms / {w.ElapsedTicks} ticks with {algorithm}");
        }

        private static void Sort(Algorithm algorithm, int[] array)
        {
            // Sort
            switch (algorithm)
            {
                case Algorithm.QuickSort:
                    QuickSort.Sort(array, 0, array.Length - 1);
                    break;
                case Algorithm.BubbleSort:
                    BubbleSort.Sort(array);
                    break;
                case Algorithm.InsertionSort:
                    InsertionSort.Sort(array);
                    break;
                case Algorithm.MergeSort:
                    MergeSort.Sort(array.ToList());
                    break;
                case Algorithm.SelectionSort:
                    SelectionSort.Sort(array);
                    break;
                case Algorithm.ShellSort:
                    ShellSort.Sort(array);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
