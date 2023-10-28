using System;

namespace Parser.Helpers.Extracting
{
    public static partial class ExtractingHelpers
    {
        public static DateTime ConvertGpsTimeToDateTime(int gpsWeek, double gpsMilliseconds)
        {
            var gpsSeconds = gpsMilliseconds / 1000;
            var leapSecondsGps = LeapSecondsGps(DateTime.Now.Year, DateTime.Now.Month);
            var basetime = new DateTime(1980, 1, 6, 0, 0, 0, DateTimeKind.Utc);

            basetime = basetime.AddDays(gpsWeek * 7);
            basetime = basetime.AddSeconds(gpsSeconds - leapSecondsGps);

            return basetime.ToLocalTime();
        }

        private static int LeapSecondsGps(int year, int month)
        {
            return LeapSecondsTai(year, month) - 19;
        }

        private static int LeapSecondsTai(int year, int month)
        {
            //http://maia.usno.navy.mil/ser7/tai-utc.dat

            var yyyymm = year * 100 + month;
            if (yyyymm >= 201701) return 37;
            if (yyyymm >= 201507) return 36;
            if (yyyymm >= 201207) return 35;
            if (yyyymm >= 200901) return 34;
            if (yyyymm >= 200601) return 33;
            if (yyyymm >= 199901) return 32;
            if (yyyymm >= 199707) return 31;
            if (yyyymm >= 199601) return 30;

            return 0;
        }
    }
}