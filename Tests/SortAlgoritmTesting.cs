using System;
using System.Diagnostics;
using static System.Console;
using static MonsterLlama.Algorithms.Sorting.QuickSort;

namespace TestsMonsterLlama
{
    class SortAlgoritmTesting
    {
        static void Main(string[] args)
        {
            #region Test variables setup
            const int size = 1024 * 1024 * 16;
            int[] array1 = new int[size];
            int[] array2 = new int[size];
            int[] array3 = new int[size];
            int[] array4 = new int[size];

            var seed = (int)DateTime.Now.Ticks % Int32.MaxValue;
            var random = new Random(seed);

            for (int index = 0; index < array1.Length; index++)
            {
                array1[index] = array2[index] = array3[index] = array4[index] = random.Next(1024 * 1024);
            }
            #endregion

            WriteLine($"For input of size {size}.");
            WriteLine("--------------------------");

            NETSorting(array1);
            QuickSort_Hoare(array2);
            QuickSort_Lomuto(array3);
            //QuickSort_LomutoExt(array4);

            // Reverse the sorted arrays..
            Array.Reverse(array1);
            //Array.Reverse(array2);
            //Array.Reverse(array3);
            //Array.Reverse(array4);

            WriteLine("--------------------------");
            WriteLine("Reversing the sorted array");
            WriteLine("--------------------------");
            NETSorting(array1);
            //QuickSort_Hoare(array2);
            //QuickSort_Lomuto(array3);
            //QuickSort_LomutoExt(array4);

            ReadLine();
        }

        private static void NETSorting(int[] array)
        {
            // Measure the runtime of .NET's built in Array.Sort over our input..
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            Array.Sort(array);
            stopwatch.Stop();
            WriteLine($".NET's Array.Sort(array): {stopwatch.Elapsed.ToString()}");
            if (!array.IsSorted())
            {
                Debugger.Break();
            }
        }

        private static void QuickSort_Hoare(int[] array)
        {
            // Measure the runtime of Nico Lomuto's quicksort technique over our input..
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            QuickSortLomuto(array);
            stopwatch.Stop();
            WriteLine($"Nico Lomuto's Quicksort:  {stopwatch.Elapsed.ToString()}");
            if (!array.IsSorted())
            {
                Debugger.Break();
            }
        }

        private static void QuickSort_Lomuto(int[] array)
        {
            // Measure the runtime of Tony Hoare's quicksort technique over our input..
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            QuickSortHoare(array);
            stopwatch.Stop();
            WriteLine($"Tony Hoare's Quicksort:   {stopwatch.Elapsed.ToString()}");
            if (!array.IsSorted())
            {
                Debugger.Break();
            }
        }

        private static void QuickSort_LomutoExt(int[] array)
        {
            // Measure the runtime of Nico Lomuto's quicksort technique using external swaps over our input..
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            QuickSortLomutoExternalSwaps(array);
            stopwatch.Stop();
            WriteLine($"Nico Lomuto's xQuicksort: {stopwatch.Elapsed.ToString()}");
            if (!array.IsSorted())
            {
                Debugger.Break();
            }
        }
    }
}
