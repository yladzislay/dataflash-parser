﻿using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct IMU2
    {
        // FMT, 138, 53, IMU2, QffffffIIfBBHH, TimeUS,GyrX,GyrY,GyrZ,AccX,AccY,AccZ,EG,EA,T,GH,AH,GHz,AHz

        public ulong TimeUS { get; set; }
        public float GyrX { get; set; }
        public float GyrY { get; set; }
        public float GyrZ { get; set; }
        public float AccX { get; set; }
        public float AccY { get; set; }
        public float AccZ { get; set; }
        public uint EG { get; set; }
        public uint EA { get; set; }
        public float T { get; set; }
        public byte GH { get; set; }
        public byte AH { get; set; }
        public ushort GHz { get; set; }
        public ushort AHz { get; set; }
    }
}