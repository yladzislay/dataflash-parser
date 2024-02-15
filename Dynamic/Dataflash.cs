using System;
using System.Collections.Generic;
using System.Linq;
using UDIE.Adrupilot.Dataflash.Dynamic.Helpers.Extracting;
using UDIE.Adrupilot.Dataflash.Dynamic.Helpers.MessagesTransforming;

namespace UDIE.Adrupilot.Dataflash.Dynamic
{
    public class Dataflash
    {
        public Dictionary<byte, dynamic> FormatMessages { get; }
        public Dictionary<string, List<dynamic>> Messages { get; }

        public Dataflash(Dictionary<byte, dynamic> formatMessages, Dictionary<string, List<dynamic>> messages)
        {
            FormatMessages = formatMessages;
            Messages = messages;
            MessagesTransformingHelper.ReGroupByInstances(FormatMessages, Messages);
            CheckGpsMessagesForBadRecords();
        }

        private void CheckGpsMessagesForBadRecords()
        {
            if (Messages.TryGetValue("GPS", out var gpsMessages)) 
                gpsMessages.RemoveAll(message => message.Lat == 0 && message.Lng == 0);
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
                .Select(time => ((long)time - (long)(ulong)firstGpsMessage.TimeUS) / 1000)
                .Select(diffTimeMs => firstGpsTime.AddMilliseconds(diffTimeMs))
                .Cast<DateTime>()
                .ToList();
        }
    }
}