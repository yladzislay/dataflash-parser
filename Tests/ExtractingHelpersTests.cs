using UDIE.Adrupilot.Dataflash.Dynamic.Helpers.Extracting;
using Xunit;

namespace UDIE.Adrupilot.Dataflash.Tests
{
    public class ExtractingHelpersTests
    {
        [Fact]
        public void ConvertGpsToUtcDateTime_Converts_Gps_Time_Correctly()
        {
            var gpsWeek = 2286;
            double gpsMillisecondsOfWeek = 259218000;
            var expected = new DateTime(2023, 11, 1, 0, 0, 0, DateTimeKind.Utc);
            
            var actual = ExtractingHelpers.ConvertGpsToUtcDateTime(gpsWeek, gpsMillisecondsOfWeek);
            
            Assert.Equal(expected, actual);
        }
    }
}