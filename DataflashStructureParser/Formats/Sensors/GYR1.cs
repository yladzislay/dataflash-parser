using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GYR1
    {
        // FMT, 179, 31, GYR1, QQfff, TimeUS,SampleUS,GyrX,GyrY,GyrZ

        public ulong TimeUS { get; set; }
        public ulong SampleUS { get; set; }
        public float GyrX { get; set; }
        public float GyrY { get; set; }
        public float GyrZ { get; set; }
    }
}