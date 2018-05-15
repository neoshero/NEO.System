using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO.Common
{
    public class DateHelper
    {
        public static Int64 ConvertToInt(DateTime dt)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return Convert.ToInt64(Math.Floor(dt.Subtract(dtStart).TotalSeconds));
        }

        public static DateTime ConvertToDateTime(Int64 number)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return dtStart.AddSeconds(number);
        }
    }
}
