using System.Runtime.InteropServices;

namespace StructureParser.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SRV1
    {
        // FMT, 250, 59, SRV1, Qffffffffffff, TimeUS,S1,S2,S3,S4,S5,S6,S7,S8,S9,S10,S11,S12
        public ulong TimeUS { get; set; }
        public float S1 { get; set; }
        public float S2 { get; set; }
        public float S3 { get; set; }
        public float S4 { get; set; }
        public float S5 { get; set; }
        public float S6 { get; set; }
        public float S7 { get; set; }
        public float S8 { get; set; }
        public float S9 { get; set; }
        public float S10 { get; set; }
        public float S11 { get; set; }
        public float S12 { get; set; }
    }
}