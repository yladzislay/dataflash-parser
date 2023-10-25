using System.Runtime.InteropServices;

namespace StructureParser.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PIDS
    {
        // FMT, 187, 35, PIDS, Qffffff, TimeUS,Des,P,I,D,FF,AFF

        public ulong TimeUS { get; set; }
        public float Des { get; set; }
        public float P { get; set; }
        public float I { get; set; }
        public float D { get; set; }
        public float FF { get; set; }
        public float AFF { get; set; }
    }
}