using System.Runtime.InteropServices;

namespace StructureParser.Formats.System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct D32
    {
        // FMT, 8, 16, D32, QBi, TimeUS,Id,Value

        public ulong TimeUS { get; set; }
        public byte Id { get; set; }
        public int Value { get; set; }
    }
}