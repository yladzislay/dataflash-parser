using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DMS
    {
        // FMT, 200, 33, DMS, IIIIIBBBBBBBBBB, TimeMS,N,Dp,RT,RS,Er,Fa,Fmn,Fmx,Pa,Pmn,Pmx,Sa,Smn,Smx

        public uint TimeMS { get; set; }
        public uint N { get; set; }
        public uint Dp { get; set; }
        public uint RT { get; set; }
        public uint RS { get; set; }
        public byte Er { get; set; }
        public byte Fa { get; set; }
        public byte Fmn { get; set; }
        public byte Fmx { get; set; }
        public byte Pa { get; set; }
        public byte Pmn { get; set; }
        public byte Pmx { get; set; }
        public byte Sa { get; set; }
        public byte Smn { get; set; }
        public byte Smx { get; set; }
    }
}