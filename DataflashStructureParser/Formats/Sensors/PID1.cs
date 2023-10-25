using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PID1
    {
        // FMT, 228, 35, PID1, Qffffff, TimeUS,Des,P,I,D,FF,AFF

        public ulong TimeUS { get; set; }
        public float Des { get; set; }
        public float P { get; set; }
        public float I { get; set; }
        public float D { get; set; }
        public float FF { get; set; }
        public float AFF { get; set; }
    }
}