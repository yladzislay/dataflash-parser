using System;

namespace UDIE.Adrupilot.Dataflash.Dynamic.Helpers.Extracting;

public class ExtractedData
{
    public double MaxDropRate { get; set; }
    public double MaxClimbRate { get; set; }
    public float MaxGroundSpeed { get; set; }
    public double MinGpsAltitude { get; set; }
    public double MaxGpsAltitude { get; set; }
    public double GpsPassedFlightDistance { get; set; }
    public double MaxDistanceFromStartPoint { get; set; }
    public uint TotalVibrationClips { get; set; }
    public double TotalClimb { get; set; }
    public string Uuid { get; set; }
    public string Firmware { get; set; }
    public DateTime? FlightStartDate { get; set; }
    public TimeSpan? LoggingDuration { get; set; }
}