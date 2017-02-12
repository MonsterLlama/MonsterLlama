using System;


namespace TestsMonsterLlama
{
    internal static class ArrayExtensions
    {
        public static bool IsSorted(this int[] array)
        {
            // doubt this can happen..
            if (array == null)
            {
                throw new NullReferenceException();
            }

            if (array.Length < 2)
            {
                return true;
            }

            for (int index = 1; index < array.Length; index++)
            {
                // If the previous 'index' is greater than the current index
                // then the Array isn't sorted!
                if (array[index - 1] > array[index])
                    return false;
            }

            return true;
        }


    }
}
