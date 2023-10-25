using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ERR
    {
        // FMT, 5, 13, ERR, QBB, TimeUS,Subsys,ECode

        public ulong TimeUS { get; set; }
        public byte Subsys { get; set; }
        public byte ECode { get; set; }
    }
}