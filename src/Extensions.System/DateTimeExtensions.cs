using Humanizer;
using System;

namespace Extensions.System
{
    /// <summary>
    /// Extensions to <see cref="DateTime"/>
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Represents a date as a human-friendly duration, e.g. "two days ago"
        /// </summary>
        /// <param name="dateTime">Date to format</param>
        /// <returns>Friendly string</returns>
        public static string ToFriendlyString(this DateTime dateTime)
        {
            return dateTime.Humanize();
        }
    }
}
