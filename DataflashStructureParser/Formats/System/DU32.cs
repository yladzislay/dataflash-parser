using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DU32
    {
        // FMT, 9, 16, DU32, QBI, TimeUS,Id,Value
        public ulong TimeUS { get; set; }
        public byte Id { get; set; }
        public uint Value { get; set; }
    }
}