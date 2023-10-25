using System.Runtime.InteropServices;

namespace StructureParser.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PIDP
    {
        // FMT, 184, 35, PIDP, Qffffff, TimeUS,Des,P,I,D,FF,AFF

        public ulong TimeUS { get; set; }
        public float Des { get; set; }
        public float P { get; set; }
        public float I { get; set; }
        public float D { get; set; }
        public float FF { get; set; }
        public float AFF { get; set; }
    }
}