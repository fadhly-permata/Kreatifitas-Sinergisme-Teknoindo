// FILENAME    : ArrayExtensions.cs
// ==========================================================
//  
// AUTHOR      : FADHLY PERMATA
// CREATED AT  : 2018-10-18
// 
// ==========================================================

namespace Utilities.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        ///     Get the array slice between the two indexes.
        /// </summary>
        /// <param name="source">The array object that will be slicing.</param>
        /// <param name="start">Inclusive for start index.</param>
        /// <param name="end">exclusive for end index.</param>
        /// <returns>
        ///     Sliced array
        /// </returns>
        public static T[] Slice<T>(this T[] source, int start, int end)
        {
            // Handles negative ends.
            if (end < 0)
                end = source.Length + end;

            var len = end - start;

            // Return new array.
            var res = new T[len];
            for (var i = 0; i < len; i++) res[i] = source[i + start];
            return res;
        }
    }
}