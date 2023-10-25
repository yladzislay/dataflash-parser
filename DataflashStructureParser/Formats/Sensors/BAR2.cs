﻿using System.Runtime.InteropServices;
using DronesCloud.Logs.Extensions;

namespace DataflashStructureParser.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BAR2
    {
        // @LoggerMessage: BAR2
        // FMT, 161, 37, BAR2, QffcfIff, TimeUS,Alt,Press,Temp,CRt,SMS,Offset,GndTemp
        // @Description: Gathered Barometer data
        // @Field: TimeUS: microseconds since system startup
        // @Field: Alt: calculated altitude
        // @Field: Press: measured atmospheric pressure
        // @Field: Temp: measured atmospheric temperature
        // @Field: CRt: derived climb rate from primary barometer
        // @Field: SMS: time last sample was taken
        // @Field: Offset: raw adjustment of barometer altitude, zeroed on calibration, possibly set by GCS
        // @Field: GndTemp: temperature on ground, specified by parameter or measured while on ground
        // @Field: Health: true if barometer is considered healthy

        public ulong TimeUS { get; set; }
        public float Alt { get; set; }
        public float Press { get; set; }
        private readonly short _Temp;
        public double Temp => _Temp.Toc();
        public float CRt { get; set; }
        public uint SMS { get; set; }
        public float Offset { get; set; }
        public float GndTemp { get; set; }
    }
}