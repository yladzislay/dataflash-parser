﻿using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MAG2
    {
        // FMT, 169, 34, MAG2, QhhhhhhhhhBI, TimeUS,MagX,MagY,MagZ,OfsX,OfsY,OfsZ,MOfsX,MOfsY,MOfsZ,Health,S

        public ulong TimeUS { get; set; }
        public short MagX { get; set; }
        public short MagY { get; set; }
        public short MagZ { get; set; }
        public short OfsX { get; set; }
        public short OfsY { get; set; }
        public short OfsZ { get; set; }
        public short MOfsX { get; set; }
        public short MOfsY { get; set; }
        public short MOfsZ { get; set; }
        public byte Health { get; set; }
        public uint S { get; set; }
    }
}