using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Custom.Engine
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EM
    {
        // FMT, 231, 26, EM, QfbffH, TimeUS,Voltage,Temp,Current,Cons_WH,rpm

        public ulong TimeUS { get; set; }
        public float Voltage { get; set; }
        public sbyte Temp { get; set; }
        public float Current { get; set; }
        public float Cons_WH { get; set; }
        public ushort rpm { get; set; }
    }
}