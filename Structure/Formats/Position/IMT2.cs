﻿using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Position
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct IMT2
    {
        // FMT, 191, 47, IMT2, Qfffffffff, TimeUS,DelT,DelvT,DelaT,DelAX,DelAY,DelAZ,DelVX,DelVY,DelVZ

        public ulong TimeUS { get; set; }
        public float DelT { get; set; }
        public float DelvT { get; set; }
        public float DelaT { get; set; }
        public float DelAX { get; set; }
        public float DelAY { get; set; }
        public float DelAZ { get; set; }
        public float DelVX { get; set; }
        public float DelVY { get; set; }
        public float DelVZ { get; set; }
    }
}