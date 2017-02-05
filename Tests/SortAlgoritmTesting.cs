using System;
using static System.Console;
using static MonsterLlama.Algorithms.Sorting.QuickSort;

namespace MonsterLlama
{
    class SortAlgoritmTesting
    {
        static void Main(string[] args)
        {
            int[] array = new int[16];

            var seed = (int) DateTime.Now.Ticks % Int32.MaxValue;
            var random = new Random(seed);
            for (int index=0; index<array.Length; index++)
            {
                array[index] = random.Next(128);
            }

            var swaps = QuickSortLomuto(array);

            var array2 = new int[] { 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var swaps2 = QuickSortLomuto(array2);

        }

    }
}
