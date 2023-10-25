using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct XKV1
    {
        // FMT, 89, 59, XKV1, Qffffffffffff, TimeUS,V00,V01,V02,V03,V04,V05,V06,V07,V08,V09,V10,V11

        public ulong TimeUS { get; set; }
        public float V00 { get; set; }
        public float V01 { get; set; }
        public float V02 { get; set; }
        public float V03 { get; set; }
        public float V04 { get; set; }
        public float V05 { get; set; }
        public float V06 { get; set; }
        public float V07 { get; set; }
        public float V08 { get; set; }
        public float V09 { get; set; }
        public float V10 { get; set; }
        public float V11 { get; set; }
    }
}