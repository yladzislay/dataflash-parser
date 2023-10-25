using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UBY2
    {
        // FMT, 152, 16, UBY2, QBbBbB, TimeUS,Instance,ofsI,magI,ofsQ,magQ

        public ulong TimeUS { get; set; }
        public byte Instance { get; set; }
        public sbyte ofsI { get; set; }
        public byte magI { get; set; }
        public sbyte ofsQ { get; set; }
        public byte magQ { get; set; }
    }
}