using System.Runtime.InteropServices;

namespace StructureParser.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DSF
    {
        // FMT, 222, 34, DSF, QIBHIIII, TimeUS,Dp,IErr,Blk,Bytes,FMn,FMx,FAv

        public ulong TimeUS { get; set; }
        public uint Dp { get; set; }
        public byte IErr { get; set; }
        public ushort Blk { get; set; }
        public uint Bytes { get; set; }
        public uint FMn { get; set; }
        public uint FMx { get; set; }
        public uint FAv { get; set; }
    }
}