using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct XKV2
    {
        // FMT, 90, 59, XKV2, Qffffffffffff, TimeUS,V12,V13,V14,V15,V16,V17,V18,V19,V20,V21,V22,V23

        public ulong TimeUS { get; set; }
        public float V12 { get; set; }
        public float V13 { get; set; }
        public float V14 { get; set; }
        public float V15 { get; set; }
        public float V16 { get; set; }
        public float V17 { get; set; }
        public float V18 { get; set; }
        public float V19 { get; set; }
        public float V20 { get; set; }
        public float V21 { get; set; }
        public float V22 { get; set; }
        public float V23 { get; set; }
    }
}