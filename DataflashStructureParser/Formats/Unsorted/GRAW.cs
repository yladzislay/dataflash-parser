using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GRAW
    {
        // FMT, 172, 42, GRAW, QIHBBddfBbB, TimeUS,WkMS,Week,numSV,sv,cpMes,prMes,doMes,mesQI,cno,lli

        public ulong TimeUS { get; set; }
        public uint WkMS { get; set; }
        public ushort Week { get; set; }
        public byte numSV { get; set; }
        public byte sv { get; set; }
        public double cpMes { get; set; }
        public double prMes { get; set; }
        public float doMes { get; set; }
        public byte mesQI { get; set; }
        public sbyte cno { get; set; }
        public byte lli { get; set; }
    }
}