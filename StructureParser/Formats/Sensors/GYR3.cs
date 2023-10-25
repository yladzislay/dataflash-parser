using System.Runtime.InteropServices;

namespace StructureParser.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GYR3
    {
        // FMT, 181, 31, GYR3, QQfff, TimeUS,SampleUS,GyrX,GyrY,GyrZ

        public ulong TimeUS { get; set; }
        public ulong SampleUS { get; set; }
        public float GyrX { get; set; }
        public float GyrY { get; set; }
        public float GyrZ { get; set; }
    }
}