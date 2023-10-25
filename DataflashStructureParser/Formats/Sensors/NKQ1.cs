using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NKQ1
    {
        // FMT, 74, 27, NKQ1, Qffff, TimeUS,Q1,Q2,Q3,Q4

        public ulong TimeUS { get; set; }
        public float Q1 { get; set; }
        public float Q2 { get; set; }
        public float Q3 { get; set; }
        public float Q4 { get; set; }
    }
}