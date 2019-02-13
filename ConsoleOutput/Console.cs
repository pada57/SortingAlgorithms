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
            Console.WriteLine("######################");
            Console.WriteLine("##### Quick Sort #####");
            Console.WriteLine("######################");

            Console.WriteLine("Array to sort : ");
            var array = Generator.NewRandomArray(1000000);

            Console.WriteLine(string.Join(' ', array));

            var w = new Stopwatch();
            w.Start();

            // Sort
            QuickSort.Sort(array, 0, array.Length - 1);

            w.Stop();

            Console.WriteLine("Sorted array : ");

            Console.WriteLine(string.Join(' ', array));

            Console.WriteLine($"Sorted {array.Length} items in {w.ElapsedMilliseconds} ms / {w.ElapsedTicks} ticks");

            Console.ReadKey();
        }
    }
}
