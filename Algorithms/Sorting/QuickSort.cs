using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Console;

namespace MonsterLlama.Algorithms.Sorting
{
    /*
     * History:
     * 
     * Quicksort (sometimes called partition-exchange sort) is an efficient sorting algorithm, 
     * serving as a systematic method for placing the elements of an array in order. 
     * Developed by Tony Hoare in 1959, with his work published in 1961, 
     * it is still a commonly used algorithm for sorting.
     * 
     * Analysis:
     * 
     * Mathematical analysis of quicksort shows that, on average, 
     * the algorithm takes Θ(n log n) comparisons to sort n items. 
     * In the worst case, it makes Θ(n²) comparisons, though this behavior is rare.
     * 
     * Quicksort is a divide and conquer algorithm. 
     * Quicksort first divides a large array into two smaller sub-arrays: 
     *  the low elements and the high elements. Quicksort can then recursively sort the sub-arrays.
     * 
     * The steps are:

        ¹ Pick an element, called a pivot, from the array.

        ² Partitioning: reorder the array so that all elements with values less than the pivot come before the pivot, 
          while all elements with values greater than the pivot come after it (equal values can go either way). 
          After this partitioning, the pivot is in its final position. This is called the partition operation.

        ³ Recursively apply the above steps to the sub-array of elements with smaller values 
          and separately to the sub-array of elements with greater values.
     * 
     * The base case of the recursion is arrays of size zero or one, which never need to be sorted.
     * 
     * The pivot selection and partitioning steps can be done in several different ways; 
     *  the choice of specific implementation schemes greatly affects the algorithm's performance.
     */
    public static class QuickSort
    {

        /// <summary>
        /// This scheme is attributed to Nico Lomuto and popularized by Bentley in his book Programming Pearls
        /// and Cormen et al. in their book Introduction to Algorithms.
        /// This scheme chooses a pivot that is typically the last element in the array. 
        /// The algorithm maintains the index to put the pivot in variable i 
        ///  and each time it finds an element less than or equal to pivot, 
        ///  this index is incremented and that element would be placed before the pivot. 
        /// This scheme degrades to Θ(n²) when the array is already reverse sorted 
        ///  as well as when the array has all equal elements.
        /// </summary>
        /// <returns></returns>
        public static long QuickSortLomuto(int[] array)
        {
            if (array == null)
                throw new NullReferenceException($"The passed in argument '{nameof(array)}' can't be null!");

            if (array.Length < 2)
                return 0;

            // members for tracking cost
            long comparisons = 0;


            if (Debugger.IsAttached)
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                comparisons = QuickSortLomutoHelper(array, 0, array.Length - 1);
                watch.Stop();
                WriteLine($"Lomuto's Quicksort's run time for input '{array.Length}' was '{watch.Elapsed.ToString()}'.");
            }
            else
            {
                comparisons = QuickSortLomutoHelper(array, 0, array.Length - 1);
            }

            return comparisons;
        }

        private static long QuickSortLomutoHelper(int[] array, int left, int right)
        {
            // Check if the sub-array is of size 0 or 1.
            if (left >= right)
                return 0;

            // member for tracking cost
            long comparisons = 0;

            int pivot = right;
            int wall = left;

            // main algoritm
            for (int index = left; index < pivot; index++)
            {
                ++comparisons;
                if (array[index] < array[pivot])
                {
                    Swap(array, index, wall);
                    ++wall;
                }
            }

            // Place the 'pivot' into its final, sort spot..
            Swap(array, pivot, wall);

            // Divide & Conquer recursively: index at position 'pivot' is sorted.
            comparisons += QuickSortLomutoHelper(array, left, wall - 1);
            comparisons += QuickSortLomutoHelper(array, wall + 1, right);

            return comparisons;
        }

        private static void Swap(int[] array, int first, int second)
        {
            // XOR'ing a value with itself returns a value of zero
            // which would be an error for all values other than zero.
            if (first == second)
                return;

            // swap values w/o using extra storage..
            array[first]  ^= array[second];
            array[second] ^= array[first];
            array[first]  ^= array[second];
        }


    }
} // namespace
