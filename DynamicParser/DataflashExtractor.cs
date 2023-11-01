using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Parser.Helpers.Extracting;
using Parser.Helpers.MessagesTransforming;

namespace Parser
{
    public class DataflashExtractor
    {
        private Dictionary<byte, dynamic> FormatMessages { get; }
        private Dictionary<string, List<dynamic>> Messages { get; }

        public DataflashExtractor(Dictionary<string, List<dynamic>> messages, Dictionary<byte, dynamic> formatMessages)
        {
            Messages = messages;
            FormatMessages = formatMessages;

            MessagesTransformingHelper.ReGroupByInstances(FormatMessages, Messages);
        }

        public IEnumerable<dynamic> GetMessagesGroupsAndColumnsInfo()
        {
            var result = new List<dynamic>();

            foreach (var (key, value) in Messages)
                result.Add(new
                {
                    value.Count,
                    Name = key,
                    Items = ((IEnumerable<string>) FormatMessages.Values.First(x => x.Name == key)
                        .Columns).Select((x, i) => new
                    {
                        value.Count,
                        Name = x,
                        Index = i
                    }).Where(x => x.Index != 0)
                });

            return result.Where(x => x.Count != 0).OrderBy(x => x.Name);
        }

        public double GetMaxDropRate()
        {
            return (short) Messages["CTUN"].Select(x => x.CRt).Max() / 100.0; // convert from cm/s to m/s.
        }

        public double GetMaxClimbRate()
        {
            return (short) Messages["CTUN"].Select(x => x.CRt).Max() / 100.0; // convert from cm/s to m/s.
        }

        public float GetMaxGroundSpeed()
        {
            return (float) Messages["GPS"].Select(x => x.Spd).Max();
        }

        public double GetMinGpsAltitude()
        {
            return (double) Messages["GPS"].Select(x => x.Alt).Min();
        }

        public double GetMaxGpsAltitude()
        {
            return (double) Messages["GPS"].Select(x => x.Alt).Max();
        }

        public uint GetTotalVibrationClips()
        {
            return Messages["VIBE"].Select(x => x.Clip0).Cast<uint>().Last() +
                   Messages["VIBE"].Select(x => x.Clip1).Cast<uint>().Last() +
                   Messages["VIBE"].Select(x => x.Clip2).Cast<uint>().Last();
        }

        public double GetGpsFlightDistance()
        {
            if (!Messages.ContainsKey("GPS") && !Messages.ContainsKey("GPS[0]")) return 0;

            var key = Messages.ContainsKey("GPS") ? "GPS"
                : Messages.ContainsKey("GPS[0]") ? "GPS[0]" : string.Empty;

            var gpsLatitudePoints = Messages[key].Select(x => x.Lat).Cast<double>().ToArray();
            var gpsLongitudePoints = Messages[key].Select(x => x.Lng).Cast<double>().ToArray();

            return CalculationHelper.GetDistance(gpsLatitudePoints, gpsLongitudePoints);
        }

        public double GetMaxDistanceFromStartPoint()
        {
            if (!Messages.ContainsKey("GPS") && !Messages.ContainsKey("GPS[0]")) return 0;
            var key = Messages.ContainsKey("GPS") ? "GPS"
                : Messages.ContainsKey("GPS[0]") ? "GPS[0]" : string.Empty;

            var gpsLatitudePoints = Messages[key].Select(x => x.Lat).Cast<double>().ToArray();
            var gpsLongitudePoints = Messages[key].Select(x => x.Lng).Cast<double>().ToArray();

            return CalculationHelper.GetMaxDistanceFromStartPoint(gpsLatitudePoints, gpsLongitudePoints);
        }

        public dynamic GetGpsDataSetByTimeCode(ulong inputTimeUs)
        {
            if (!Messages.ContainsKey("GPS") && !Messages.ContainsKey("GPS[0]")) return null;
            var key = Messages.ContainsKey("GPS") ? "GPS"
                : Messages.ContainsKey("GPS[0]") ? "GPS[0]" : string.Empty;

            var result = Messages[key].First(x => (ulong) x.TimeUS == inputTimeUs);
            return result;
        }

        public double GetTotalClimb() => CalculationHelper.CalculateTotalClimb(Messages["NKF5"].Select(x => x.HAGL).Cast<double>());

        public string ExtractUuid()
        {
            var regex = new Regex(@" \w{8} \w{8} \w{8}$");
            var uuidMessage = (string) Messages["MSG"]
                .Select(x => x.Message)
                .FirstOrDefault(y => regex.IsMatch(y));

            return uuidMessage == null ? null : string.Concat(uuidMessage.Split(new[] {' '}).Skip(1).ToArray());
        }

        public string GetFirmware()
        {
            var regex = new Regex(@"^(ArduCopter|ArduPlane)");
            var firmware = (string) Messages["MSG"].Select(x => x.Message).FirstOrDefault(y => regex.IsMatch(y));
            return firmware;
        }

        public DateTime? GetFlightStartDate()
        {
            if (!Messages.ContainsKey("GPS") && !Messages.ContainsKey("GPS[0]")) return null;
            
            var key = Messages.ContainsKey("GPS") 
                ? "GPS"
                : Messages.ContainsKey("GPS[0]") 
                    ? "GPS[0]" 
                    : string.Empty;

            var firstGpsMessage = Messages[key].First();

            var gpsWeek = (ushort) firstGpsMessage.GWk;
            var gpsSec = (uint) firstGpsMessage.GMS;

            var firstGpsDateTime = ExtractingHelpers.ConvertGpsToUtcDateTime(gpsWeek, gpsSec);

            return firstGpsDateTime;
        }

        public TimeSpan? GetLoggingDuration()
        {
            if (!Messages.ContainsKey("GPS") && !Messages.ContainsKey("GPS[0]")) return null;
            var key = Messages.ContainsKey("GPS") ? "GPS"
                : Messages.ContainsKey("GPS[0]") ? "GPS[0]" : string.Empty;

            var firstGpsGwk = (ushort) Messages[key].Select(x => x.GWk).First();
            var firstGpsGms = (uint) Messages[key].Select(x => x.GMS).First();

            var lastGpsGwk = (ushort) Messages[key].Select(x => x.GWk).Last();
            var lastGpsGms = (uint) Messages[key].Select(x => x.GMS).Last();

            var startDate = ExtractingHelpers.ConvertGpsToUtcDateTime(firstGpsGwk, firstGpsGms);
            var lastDate = ExtractingHelpers.ConvertGpsToUtcDateTime(lastGpsGwk, lastGpsGms);

            var result = lastDate.Subtract(startDate);

            return new TimeSpan(result.Days, result.Hours, result.Minutes, result.Seconds);
        }

        public IEnumerable<DateTime> GetTimeLine(IEnumerable<ulong> timeline)
        {
            if (!Messages.ContainsKey("GPS") && !Messages.ContainsKey("GPS[0]")) return null;
            var key = Messages.ContainsKey("GPS") ? "GPS"
                : Messages.ContainsKey("GPS[0]") ? "GPS[0]" : string.Empty;

            var firstGpsMessage = Messages[key].First();
            var firstGpsTime = ExtractingHelpers.ConvertGpsToUtcDateTime(int.Parse(firstGpsMessage.GWk.ToString()),
                long.Parse(firstGpsMessage.GMS.ToString()) / 1000.0);

            return timeline
                .Select(time => ((long) time - (long) (ulong) firstGpsMessage.TimeUS) / 1000)
                .Select(diffTimeMs => firstGpsTime.AddMilliseconds(diffTimeMs))
                .Cast<DateTime>()
                .ToList();
        }
    }
}