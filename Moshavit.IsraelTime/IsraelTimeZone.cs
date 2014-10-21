using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Service
{
    /// <summary>
    /// Israel Time
    /// </summary>
    public class IsraelTimeZone
    {
        /// <summary>
        /// Israel time zone 
        /// </summary>
        /// <returns>Current time zone in Israel</returns>
        public static DateTime Now()
        {
            var myZoneTime = TimeZoneInfo.FindSystemTimeZoneById("Israel Standard Time");
            var serverTime = DateTime.UtcNow;

            return TimeZoneInfo.ConvertTimeFromUtc(serverTime, myZoneTime);
        }
    }
}
