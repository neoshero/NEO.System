using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO.Common.Date
{
    public static class DateExtension
    {
        public const string DefaultDateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// check date 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsDate(this object date)
        {
            DateTime newDate;
            return DateTime.TryParse(date.ToString(), out newDate);
        }

        /// <summary>
        /// date to string format
        /// </summary>
        /// <param name="date">datetime</param>
        /// <param name="format">convert to format</param>
        /// <returns></returns>
        public static string ToDate(this DateTime? date, string format = null)
        {
            if (!date.HasValue)
            {
                return string.Empty;
            }
            return date.Value.ToString(format ?? DefaultDateTimeFormat);
        }

        /// <summary>
        /// date to string format
        /// </summary>
        /// <param name="date">datetime</param>
        /// <param name="format">convert to format</param>
        /// <returns></returns>
        public static string ToDate(this DateTime date, string format = null)
        {
            return date.ToString(format ?? DefaultDateTimeFormat);
        }

        /// <summary>
        /// Local To Utc datetime format
        /// </summary>
        /// <param name="date">date string</param>
        /// <param name="format">date format</param>
        /// <returns></returns>
        public static DateTime ParseLocalToUtc(this string date,string format = null)
        {
            return DateTime.ParseExact(date, format ?? DefaultDateTimeFormat, DateTimeFormatInfo.CurrentInfo).ToUniversalTime();
        }

        /// <summary>
        /// Utc To Local datetime format
        /// </summary>
        /// <param name="date">date string</param>
        /// <param name="format">date format</param>
        /// <returns></returns>
        public static DateTime ParseUtcToLocal(this string date, string format = "")
        {
            return DateTime.ParseExact(date, format ?? DefaultDateTimeFormat, DateTimeFormatInfo.CurrentInfo);
        }
    }
}
