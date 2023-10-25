using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ACC3
    {
        // FMT, 178, 31, ACC3, QQfff, TimeUS,SampleUS,AccX,AccY,AccZ

        public ulong TimeUS { get; set; }
        public ulong SampleUS { get; set; }
        public float AccX { get; set; }
        public float AccY { get; set; }
        public float AccZ { get; set; }
    }
}