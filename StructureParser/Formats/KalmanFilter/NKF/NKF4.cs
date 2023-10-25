﻿using System.Runtime.InteropServices;

namespace StructureParser.Formats.KalmanFilter.NKF
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NKF4
    {
        // FMT, 67, 35, NKF4, QcccccfbbHBHHb, TimeUS,SV,SP,SH,SM,SVT,errRP,OFN,OFE,FS,TS,SS,GPS,PI

        public ulong TimeUS { get; set; }

        private readonly short _SV;
        private readonly short _SP;
        private readonly short _SH;
        private readonly short _SM;
        private readonly short _SVT;

        public double SV => _SV.Toc();
        public double SP => _SP.Toc();
        public double SH => _SH.Toc();
        public double SM => _SM.Toc();
        public double SVT => _SVT.Toc();

        public float errRP { get; set; }
        public sbyte OFN { get; set; }
        public sbyte OFE { get; set; }
        public ushort FS { get; set; }
        public byte TS { get; set; }
        public ushort SS { get; set; }
        public ushort GPS { get; set; }
        public sbyte PI { get; set; }
    }
}