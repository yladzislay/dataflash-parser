using System;
using System.Collections.Generic;
using System.Linq;
using UDIE.Adrupilot.Dataflash.Dynamic.Helpers.Extracting;

namespace UDIE.Adrupilot.Dataflash.Dynamic.Helpers.MessagesTransforming;

public static class Convertor
{
    public static IEnumerable<DateTime> ConvertTimelineToDateTime(IEnumerable<ulong> timeline, dynamic firstGpsMessage)
    {
        var firstGpsTime = ExtractingHelpers.ConvertGpsToUtcDateTime(int.Parse(firstGpsMessage.GWk.ToString()),
            long.Parse(firstGpsMessage.GMS.ToString()) / 1000.0);

        return timeline
            .Select(time => ((long)time - (long)(ulong)firstGpsMessage.TimeUS) / 1000)
            .Select(diffTimeMs => firstGpsTime.AddMilliseconds(diffTimeMs))
            .Cast<DateTime>()
            .ToList();
    }
}