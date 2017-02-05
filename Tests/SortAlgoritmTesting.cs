using System;
using static System.Console;
using static MonsterLlama.Algorithms.Sorting.QuickSort;

namespace MonsterLlama
{
    class SortAlgoritmTesting
    {
        static void Main(string[] args)
        {
            int[] array = new int[4096];

            var seed = (int) DateTime.Now.Ticks % Int32.MaxValue;
            var random = new Random(seed);
            for (int index=0; index<array.Length; index++)
            {
                array[index] = random.Next(255);
            }

            var swaps = QuickSortLomuto(array);
            WriteLine($"Lomuto's Quicksort's # of comparisons for an array of size '{array.Length}' was '{swaps}'.");

            Array.Reverse(array);
            swaps = QuickSortLomuto(array);
            WriteLine($"Lomuto's Quicksort's # of comparisons for a reverse sorted array of size '{array.Length}' was '{swaps}'.");

        }

    }
}
