using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct D16
    {
        // FMT, 6, 14, D16, QBh, TimeUS,Id,Value

        public ulong TimeUS { get; set; }
        public byte Id { get; set; }
        public short Value { get; set; }
    }
}