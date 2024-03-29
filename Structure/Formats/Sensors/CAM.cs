﻿using System.Runtime.InteropServices;
using UDIE.Adrupilot.Dataflash.Structure.Helpers;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CAM
    {
        // FMT, 146, 43, CAM, QIHLLeeeccC, TimeUS,GPSTime,GPSWeek,Lat,Lng,Alt,RelAlt,GPSAlt,Roll,Pitch,Yaw

        public ulong TimeUS { get; set; }
        public uint GPSTime { get; set; }
        public ushort GPSWeek { get; set; }
        
        private readonly int _Lat;
        private readonly int _Lng;
        private readonly int _Alt;
        private readonly int _RelAlt;
        private readonly int _GPSAlt;
        private readonly short _Roll;
        private readonly short _Pitch;
        private readonly ushort _Yaw;

        public double Lat => _Lat.ToL();
        public double Lng => _Lng.ToL();
        public double Alt => _Alt.Toe();
        public double RelAlt => _RelAlt.Toe();
        public double GPSAlt => _GPSAlt.Toe();
        public double Roll => _Roll.Toc();
        public double Pitch => _Pitch.Toc();
        public double Yaw => _Yaw.ToC();
    }
}