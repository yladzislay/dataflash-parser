using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SRV2
    {
        // FMT, 249, 59, SRV2, Qffffffffffff, TimeUS,S13,S14,S15,S16,S17,S18,S19,S20,S21,S22,S23,S24

        public ulong TimeUS { get; set; }
        public float S13 { get; set; }
        public float S14 { get; set; }
        public float S15 { get; set; }
        public float S16 { get; set; }
        public float S17 { get; set; }
        public float S18 { get; set; }
        public float S19 { get; set; }
        public float S20 { get; set; }
        public float S21 { get; set; }
        public float S22 { get; set; }
        public float S23 { get; set; }
        public float S24 { get; set; }
    }
}