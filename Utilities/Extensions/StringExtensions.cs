// FILENAME    : StringExtensions.cs
// ==========================================================
//  
// AUTHOR      : FADHLY PERMATA
// CREATED AT  : 2018-10-18
// 
// ==========================================================

namespace Utilities.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        ///     Repeat text for n times
        /// </summary>
        /// <param name="text">The text that will be repeated.</param>
        /// <param name="count">Repead times</param>
        /// <returns>
        ///     Repeated text
        /// </returns>
        public static string Repeat(this string text, int count)
        {
            var result = text;
            for (var i = 0; i < count; i++) result += text;

            return result;
        }
    }
}