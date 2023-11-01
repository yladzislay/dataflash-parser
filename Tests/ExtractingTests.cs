using Parser.Helpers.Extracting;
using Xunit;

namespace Tests
{
    public class ExtractingHelpersTests
    {
        [Fact]
        public void ConvertGpsToUtcDateTime_Converts_Gps_Time_Correctly()
        {
            int gpsWeek = 2286;
            double gpsMillisecondsOfWeek = 259218000;
            DateTime expected = new DateTime(2023, 11, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime actual = ExtractingHelpers.ConvertGpsToUtcDateTime(gpsWeek, gpsMillisecondsOfWeek);
            Assert.Equal(expected, actual);
        }
    }
}