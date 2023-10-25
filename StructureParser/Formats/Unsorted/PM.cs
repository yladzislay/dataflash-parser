using System.Runtime.InteropServices;

namespace StructureParser.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PM
    {
        // FMT, 227, 25, PM, QHHIIH, TimeUS,NLon,NLoop,MaxT,Mem,Load

        public ulong TimeUS { get; set; }
        public ushort NLon { get; set; }
        public ushort NLoop { get; set; }
        public uint MaxT { get; set; }
        public uint Mem { get; set; }
        public ushort Load { get; set; }
    }
}