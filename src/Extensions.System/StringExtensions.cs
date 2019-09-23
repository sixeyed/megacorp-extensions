using Humanizer;

namespace Extensions.System
{
    /// <summary>
    /// Extensions to <see cref="string"></see>
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Formats a string as title case, capitalizing major words
        /// </summary>
        /// <param name="string">Input string</param>
        /// <returns>Title-case formatted string</returns>
        public static string ToTitleCase(this string @string)
        {
            return @string.Titleize();
        }
    }
}
