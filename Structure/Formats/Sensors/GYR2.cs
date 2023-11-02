using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GYR2
    {
        // FMT, 180, 31, GYR2, QQfff, TimeUS, SampleUS, GyrX, GyrY, GyrZ

        public ulong TimeUS { get; set; }
        public ulong SampleUS { get; set; }
        public float GyrX { get; set; }
        public float GyrY { get; set; }
        public float GyrZ { get; set; }
    }
}