using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NKQ2
    {
        // FMT, 75, 27, NKQ2, Qffff, TimeUS,Q1,Q2,Q3,Q4

        public ulong TimeUS { get; set; }
        public float Q1 { get; set; }
        public float Q2 { get; set; }
        public float Q3 { get; set; }
        public float Q4 { get; set; }
    }
}