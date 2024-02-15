using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UDIE.Adrupilot.Dataflash.Dynamic.Helpers.Extracting;

namespace UDIE.Adrupilot.Dataflash.Dynamic;

public static class Extractor
{
    public static ExtractedData ExtractAll(Dataflash dataflash)
    {
        var result = new ExtractedData();

        var hasCtunMessages = dataflash.Messages.TryGetValue("CTUN", out var ctunMessages);
        var hasGpsMessages = dataflash.Messages.TryGetValue("GPS", out var gpsMessages) || dataflash.Messages.TryGetValue("GPS[0]", out gpsMessages);
        var hasVibeMessages = dataflash.Messages.TryGetValue("VIBE", out var vibeMessages);
        var hasNkf5Messages = dataflash.Messages.TryGetValue("NKF5", out var nkf5Messages);
        var hasMsgMessages = dataflash.Messages.TryGetValue("MSG", out var msgMessages);

        if (hasCtunMessages)
        {
            result.MaxDropRate = ExtractMaxDropRate(ctunMessages);
            result.MaxClimbRate = ExtractMaxClimbRate(ctunMessages);
        }

        if (hasGpsMessages)
        {
            result.MaxGroundSpeed = ExtractMaxGroundSpeed(gpsMessages);
            result.MinGpsAltitude = ExtractMinGpsAltitude(gpsMessages);
            result.MaxGpsAltitude = ExtractMaxGpsAltitude(gpsMessages);
            result.GpsPassedFlightDistance = ExtractGpsPassedFlightDistance(gpsMessages);
            result.MaxDistanceFromStartPoint = ExtractMaxDistanceFromStartPoint(gpsMessages);
        }

        if (hasVibeMessages)
        {
            result.TotalVibrationClips = ExtractTotalVibrationClips(vibeMessages);
        }

        if (hasNkf5Messages)
        {
            result.TotalClimb = ExtractTotalClimb(ExtractAltitudesFromNkf5(nkf5Messages));
        }

        if (hasMsgMessages)
        {
            result.Uuid = ExtractUuid(msgMessages);
            result.Firmware = ExtractFirmware(msgMessages);
            result.FlightStartDate = ExtractFlightStartDate(gpsMessages);
            result.LoggingDuration = ExtractLoggingDuration(gpsMessages);
        }

        return result;
    }

    private static double ExtractMaxDropRate(IEnumerable<dynamic> ctunMessages)
    {
        return (short)ctunMessages.Select(x => x.CRt).Max() / 100.0; // convert from cm/s to m/s.
    }

    private static double ExtractMaxClimbRate(IEnumerable<dynamic> ctunMessages)
    {
        return (short)ctunMessages.Select(x => x.CRt).Max() / 100.0; // convert from cm/s to m/s.
    }

    private static float ExtractMaxGroundSpeed(IEnumerable<dynamic> gpsMessages)
    {
        return (float)gpsMessages.Select(x => x.Spd).Max();
    }

    private static double ExtractMinGpsAltitude(IEnumerable<dynamic> gpsMessages)
    {
        return (double)gpsMessages.Select(x => x.Alt).Min();
    }

    private static double ExtractMaxGpsAltitude(IEnumerable<dynamic> gpsMessages)
    {
        return (double)gpsMessages.Select(x => x.Alt).Max();
    }

    public static double ExtractGpsPassedFlightDistance(IReadOnlyCollection<dynamic> gpsMessages)
    {
        var gpsLatitudePoints = gpsMessages.Select(x => x.Lat).Cast<double>().ToArray();
        var gpsLongitudePoints = gpsMessages.Select(x => x.Lng).Cast<double>().ToArray();
        return CalculationHelper.CalculateGpsTotalPassedDistance(gpsLatitudePoints, gpsLongitudePoints);
    }

    public static double ExtractMaxDistanceFromStartPoint(IReadOnlyCollection<dynamic> gpsMessages)
    {
        var gpsLatitudePoints = gpsMessages.Select(x => x.Lat).Cast<double>().ToArray();
        var gpsLongitudePoints = gpsMessages.Select(x => x.Lng).Cast<double>().ToArray();
        return CalculationHelper.CalculateMaxDistanceFromStartPoint(gpsLatitudePoints, gpsLongitudePoints);
    }

    private static uint ExtractTotalVibrationClips(IReadOnlyCollection<dynamic> vibeMessages)
    {
        return vibeMessages.Select(x => x.Clip0).Cast<uint>().Last() +
               vibeMessages.Select(x => x.Clip1).Cast<uint>().Last() +
               vibeMessages.Select(x => x.Clip2).Cast<uint>().Last();
    }

    public static IEnumerable<double> ExtractAltitudesFromGps(IEnumerable<dynamic> gpsMessages)
    {
        return gpsMessages.Select(x => (double)x.Alt);
    }

    private static IEnumerable<double> ExtractAltitudesFromNkf5(IEnumerable<dynamic> nkf5Messages)
    {
        return nkf5Messages.Select(x => (double)x.HAGL);
    }

    public static double ExtractTotalClimb(IEnumerable<double> altitudes)
    {
        return CalculationHelper.CalculateTotalClimb(altitudes);
    }

    public static string ExtractUuid(IEnumerable<dynamic> msgMessages)
    {
        var regex = new Regex(@" \w{8} \w{8} \w{8}$");
        var uuidMessage = (string)msgMessages.Select(x => x.Message).FirstOrDefault(y => regex.IsMatch(y));
        return uuidMessage == null ? null : string.Concat(uuidMessage.Split(new[] { ' ' }).Skip(1).ToArray());
    }

    private static string ExtractFirmware(IEnumerable<dynamic> msgMessages)
    {
        var regex = new Regex(@"^(ArduCopter|ArduPlane)");
        var firmware = (string)msgMessages.Select(x => x.Message).FirstOrDefault(y => regex.IsMatch(y));
        return firmware;
    }

    private static DateTime? ExtractFlightStartDate(IEnumerable<dynamic> gpsMessages)
    {
        var firstGpsMessage = gpsMessages.FirstOrDefault();
        if (firstGpsMessage == null) return null;
        
        var gpsWeek = (ushort)firstGpsMessage.GWk;
        var gpsSec = (uint)firstGpsMessage.GMS;

        return ExtractingHelpers.ConvertGpsToUtcDateTime(gpsWeek, gpsSec);
    }

    private static TimeSpan? ExtractLoggingDuration(IReadOnlyCollection<dynamic> gpsMessages)
    {
        var firstGpsGwk = (ushort)gpsMessages.Select(x => x.GWk).First();
        var firstGpsGms = (uint)gpsMessages.Select(x => x.GMS).First();

        var lastGpsGwk = (ushort)gpsMessages.Select(x => x.GWk).Last();
        var lastGpsGms = (uint)gpsMessages.Select(x => x.GMS).Last();

        var startDate = ExtractingHelpers.ConvertGpsToUtcDateTime(firstGpsGwk, firstGpsGms);
        var lastDate = ExtractingHelpers.ConvertGpsToUtcDateTime(lastGpsGwk, lastGpsGms);

        return lastDate - startDate;
    }
}