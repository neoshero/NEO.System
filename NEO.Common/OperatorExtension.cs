using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO.Common
{
    public static class OperatorExtension
    {
        public static string ToDateTime(this DateTime dateTime, string format)
        {
            return dateTime.ToString(format);
        }

        public static string ToDateTime(this DateTime? dateTime, string format)
        {
            return dateTime.HasValue ? dateTime.Value.ToString(format) : "";
        }

        public static DateTime ToDateTime(this DateTime? dateTime)
        {
            return dateTime ?? DateTime.MinValue;
        }

        public static decimal ToDecimal(this decimal? numberic)
        {
            return Convert.ToDecimal(numberic);
        }

        public static decimal ToDecimal(this decimal? numberic, int decimals)
        {
            return numberic.HasValue ? Math.Round(numberic.Value, decimals, MidpointRounding.AwayFromZero) : 0;
        }

        public static decimal ToDecimal(this decimal numberic, int decimals)
        {
            return Math.Round(numberic, decimals, MidpointRounding.AwayFromZero);
        }

        public static int ToInt(this int? numberic)
        {
            return Convert.ToInt32(numberic);
        }

        public static bool IsNull(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}
