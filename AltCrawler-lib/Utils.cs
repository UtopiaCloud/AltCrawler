using System;

namespace AltCrawler_lib
{
    public static class Utils
    {
        public static long ConvertDatetimeToUnixTimeStamp(this DateTime date)
        {
            DateTime originDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - originDate;
            return (long)Math.Floor(diff.TotalSeconds);
        }
    }
}