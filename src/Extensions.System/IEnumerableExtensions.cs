using System.Collections.Generic;
using MoreLinq;

namespace System.Linq
{
    /// <summary>
    /// Extensions to <see cref="IEnumerable{T}"/>
    /// </summary>
    public static class IEnumerableExtensions
    {
        private const string CsvDelimiter = ",";
        private const string CsvDelimiterWithNewLine = ",\r\n";

        /// <summary>
        /// Presents a collection as a comma-separated string
        /// </summary>
        /// <typeparam name="T">Type of collection item</typeparam>
        /// <param name="enumerable">Collection</param>
        /// <param name="withNewLine">Whether to write a newline after each item</param>
        /// <returns>Comma-separated string of collection items</returns>
        public static string ToCsv<T>(this IEnumerable<T> enumerable, bool withNewLine = false)
        {            
            return enumerable.ToDelimitedString(withNewLine ? CsvDelimiterWithNewLine : CsvDelimiter);
        }
    }
}
