using System.Runtime.InteropServices;

namespace StructureParser.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ISBD
    {
        // FMT, 225, 207, ISBD, QHHaaa, TimeUS,N,seqno,x,y,z

        public ulong TimeUS { get; set; }
        public ushort N { get; set; }
        public ushort seqno { get; set; }
        public string x { get; set; }
        public string y { get; set; }
        public string z { get; set; }
    }
}