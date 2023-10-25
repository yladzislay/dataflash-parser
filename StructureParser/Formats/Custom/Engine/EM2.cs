using System.Runtime.InteropServices;

namespace StructureParser.Formats.Custom.Engine
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EM2
    {
        // FMT, 232, 26, EM2, QfbffH, TimeUS,Voltage,Temp,Current,Cons_WH,rpm

        public ulong TimeUS { get; set; }
        public float Voltage { get; set; }
        public sbyte Temp { get; set; }
        public float Current { get; set; }
        public float Cons_WH { get; set; }
        public ushort rpm { get; set; }
    }
}