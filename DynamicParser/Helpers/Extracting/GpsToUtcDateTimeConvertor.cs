using System;

namespace Parser.Helpers.Extracting
{
    public static partial class ExtractingHelpers
    {
        public static DateTime ConvertGpsToUtcDateTime(int gpsWeek, double gpsMillisecondsOfWeek) => 
            new DateTime(1980, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                .AddDays(gpsWeek * 7)
                .AddMilliseconds(gpsMillisecondsOfWeek)
                .SubtractGpsLeapSeconds();

        private static DateTime SubtractGpsLeapSeconds(this DateTime dateTime) => 
            dateTime.AddSeconds(-GetGpsUtcLeapSeconds(dateTime.Year, dateTime.Month));

        private static int GetGpsUtcLeapSeconds(int year, int month) => GetTaiUtcLeapSeconds(year, month) - 19;
        
        private static int GetTaiUtcLeapSeconds(int year, int month)
        {
            var yyyymm = year * 100 + month;

            if (yyyymm >= 201701) return 37; // [2017 JAN] TAI-UTC = 37
            if (yyyymm >= 201507) return 36; // [2015 JUL] TAI-UTC = 36
            if (yyyymm >= 201207) return 35; // [2012 JUL] TAI-UTC = 35
            if (yyyymm >= 200901) return 34; // [2009 JAN] TAI-UTC = 34
            if (yyyymm >= 200601) return 33; // [2006 JAN] TAI-UTC = 33
            if (yyyymm >= 199901) return 32; // [1999 JAN] TAI-UTC = 32
            if (yyyymm >= 199707) return 31; // [1997 JUL] TAI-UTC = 31
            if (yyyymm >= 199601) return 30; // [1996 JAN] TAI-UTC = 30
            if (yyyymm >= 199407) return 29; // [1994 JUL] TAI-UTC = 29
            if (yyyymm >= 199306) return 28; // [1993 JUL] TAI-UTC = 28
            if (yyyymm >= 199207) return 27; // [1992 JUL] TAI-UTC = 27
            if (yyyymm >= 199101) return 26; // [1991 JAN] TAI-UTC = 26
            if (yyyymm >= 199001) return 25; // [1990 JAN] TAI-UTC = 25
            if (yyyymm >= 198801) return 24; // [1988 JAN] TAI-UTC = 24
            if (yyyymm >= 198507) return 23; // [1985 JUL] TAI-UTC = 23
            if (yyyymm >= 198307) return 22; // [1983 JUL] TAI-UTC = 22
            if (yyyymm >= 198207) return 21; // [1982 JUL] TAI-UTC = 21
            if (yyyymm >= 198107) return 20; // [1981 JUL] TAI-UTC = 20
            if (yyyymm >= 198001) return 19; // [1980 JAN] TAI-UTC = 19
            return 19;
        }
    }
}