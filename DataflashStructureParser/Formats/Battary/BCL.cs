using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Battary
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BCL
    {
        // FMT, 166, 35, BCL, QfHHHHHHHHHH, TimeUS,Volt,V1,V2,V3,V4,V5,V6,V7,V8,V9,V10

        public ulong TimeUS { get; set; }
        public float Volt { get; set; }
        public ushort V1 { get; set; }
        public ushort V2 { get; set; }
        public ushort V3 { get; set; }
        public ushort V4 { get; set; }
        public ushort V5 { get; set; }
        public ushort V6 { get; set; }
        public ushort V7 { get; set; }
        public ushort V8 { get; set; }
        public ushort V9 { get; set; }
        public ushort V10 { get; set; }
    }
}