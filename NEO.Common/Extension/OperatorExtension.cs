using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO.Common.Extension
{
    public static class OperatorExtension
    {

        public static decimal ToDecimal(this decimal? numberic)
        {
            return Convert.ToDecimal(numberic);
        }

        public static decimal ToFix(this decimal? numberic, int digits = 2)
        {
            return numberic.HasValue ? Math.Round(numberic.Value, digits, MidpointRounding.AwayFromZero) : 0;
        }

        public static decimal ToFix(this decimal numberic, int digits = 2)
        {
            return Math.Round(numberic, digits, MidpointRounding.AwayFromZero);
        }

        public static double ToFix(this double? numberic, int digits = 2)
        {
            return numberic.HasValue ? Math.Round(numberic.Value, digits, MidpointRounding.AwayFromZero) : 0;
        }

        public static double ToFix(this double numberic, int digits = 2)
        {
            return Math.Round(numberic,digits, MidpointRounding.AwayFromZero);
        }

        public static int ToInt(this int? numberic)
        {
            return Convert.ToInt32(numberic);
        }

        public static bool IsNull(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static string ToPercentage(this decimal source)
        {
            return (source * 100) + "%";
        }

        public static string ToDollarFormat(this decimal source)
        {
            return "$" + source;
        }

        public static string ToCnyFormat(this decimal source)
        {
            return "￥" + source;
        }
    }
}
