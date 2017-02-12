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
        /// This scheme is attributed to Nico Lomuto and popularized by Bentley in his book 'Programming Pearls'
        ///  and Cormen et al. in their book 'Introduction to Algorithms'.
        /// This scheme chooses a pivot that is typically the last element in the array.
        /// The algorithm maintains the index to put the pivot in a variable
        ///  and each time it finds an element less than or equal to pivot,
        ///  this index is incremented and that element would be placed before the pivot.
        /// This scheme degrades to Θ(n²) when the array is already reverse sorted
        ///  as well as when the array has all equal elements.
        /// </summary>
        /// <returns></returns>
        public static void QuickSortLomuto(int[] array)
        {
            if (array == null)
                throw new NullReferenceException($"The passed in argument '{nameof(array)}' can't be null!");

            if (array.Length < 2)
                return;

            QuickSortLomutoHelper(array, 0, array.Length - 1);
        }

        private static void QuickSortLomutoHelper(int[] array, int left, int right)
        {
            // Check for base case: 'array' is of size 0 or 1.
            if (left >= right)
                return;

            int pivot = right;
            int wall = left;

            // main algoritm
            for (int index = left; index < pivot; index++)
            {
                if (array[index] <= array[pivot])
                {
                    if (index != wall)
                    {
                        if (array[index] != array[wall])
                        {
                            //Swap(array, index, wall);
                            array[index] ^= array[wall];
                            array[wall] ^= array[index];
                            array[index] ^= array[wall];
                        }
                    }              
                    ++wall;
                }
            }

            // Place the 'pivot' into its final sort spot (if different, ie. not already there!)..
            if (pivot != wall)
            {
                // Swap(array, pivot, wall);
                array[pivot] ^= array[wall];
                array[wall] ^= array[pivot];
                array[pivot] ^= array[wall];
            }

            // Divide & Conquer recursively: index at position 'pivot' is sorted.
            QuickSortLomutoHelper(array, left, wall - 1);
            QuickSortLomutoHelper(array, wall + 1, right);
        }


        public static void QuickSortLomutoExternalSwaps(int[] array)
        {
            if (array == null)
                throw new NullReferenceException($"The passed in argument '{nameof(array)}' can't be null!");

            if (array.Length < 2)
                return;

            QuickSortLomutoExternalSwapsHelper(array, 0, array.Length - 1);
        }
        private static void QuickSortLomutoExternalSwapsHelper(int[] array, int left, int right)
        {
            // Check for base case: 'array' is of size 0 or 1.
            if (left >= right)
                return;

            int pivot = right;
            int wall = left;

            // main algoritm
            for (int index = left; index < pivot; index++)
            {
                if (array[index] <= array[pivot])
                {
                    if (index != wall)
                    {
                        if (array[index] != array[wall])
                        {
                            Swap(array, index, wall);
                        }
                    }
                    ++wall;
                }
            }

            // Place the 'pivot' into its final sort spot (if different, ie. not already there!)..
            if (pivot != wall)
            {
                Swap(array, pivot, wall);
            }

            // Divide & Conquer recursively: index at position 'pivot' is sorted.
            QuickSortLomutoHelper(array, left, wall - 1);
            QuickSortLomutoHelper(array, wall + 1, right);
        }


        /// <summary>
        /// The original partition scheme described by Tony (C.A.R.) Hoare uses two indices
        ///  that start at the ends of the array being partitioned, then move toward each other,
        ///  until they detect an inversion: a pair of elements, one greater than or equal to the pivot,
        ///  one lesser than or equal, that are in the wrong order relative to each other.
        /// The inverted elements are then swapped. When the indices meet,
        ///  the algorithm stops and returns the final index.
        /// 
        /// Hoare's scheme is more efficient than Lomuto's partition scheme
        ///  because it does three times fewer swaps on average, 
        ///  and it creates efficient partitions even when all values are equal.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static void QuickSortHoare(int[] array)
        {
            if (array == null)
                throw new NullReferenceException($"The passed in argument '{nameof(array)}' can't be null!");

            if (array.Length < 2)
                return;

            QuickSortHoareHelper(array, 0, array.Length - 1);
        }

        public static void QuickSortHoareHelper(int[] array, int left, int right)
        {
            // Recursion base case..
            if (left >= right)
                return;
            
            int pivot = right;
            int first = left;
            int last = right;

            while (left < right)
            {
                // move from left to right until we find a value greater than the pivot..
                while (left < right)
                {
                    if (array[left] <= array[pivot])
                    {
                        left++;
                    }
                    else
                    {
                        break;
                    }
                }

                // move from right to left until we find a value less than the pivot..
                while (right > left)
                {
                    if (array[right] >= array[pivot])
                    {
                        right--;
                    }
                    else
                    {
                        break;
                    }
                }

                if (left < right)
                {
                    // Swap(array, left, right);
                    array[left] ^= array[right];
                    array[right] ^= array[left];
                    array[left] ^= array[right];
                }
            }

            if (array[left] != array[pivot])
            {
                // Swap(array, left, pivot);
                array[left] ^= array[pivot];
                array[pivot] ^= array[left];
                array[left] ^= array[pivot];
            }

            // For readability sakes below..
            pivot = left;

            QuickSortHoareHelper(array, first, pivot - 1);
            QuickSortHoareHelper(array, pivot + 1, last);
        }

        private static void Swap(int[] array, int first, int second)
        {
            // It's better to do this check in the calling code in order to avoid
            // unnecessary method calls.
            /* XOR'ing a value with itself returns a value of zero
               which would be an error for all values other than zero.
               
                      if (first == second)
                          return;
            */

            // swap values w/o using extra storage..
            array[first]  ^= array[second];
            array[second] ^= array[first];
            array[first]  ^= array[second];
        }


    }
} // namespace
