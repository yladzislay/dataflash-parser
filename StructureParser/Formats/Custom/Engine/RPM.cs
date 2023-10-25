using System.Runtime.InteropServices;

namespace StructureParser.Formats.Custom.Engine
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RPM
    {
        // FMT, 194, 23, RPM, Qfff, TimeUS,rpm1,rpm2,rpm3

        public ulong TimeUS { get; set; }
        public float rpm1 { get; set; }
        public float rpm2 { get; set; }
        public float rpm3 { get; set; }
    }
}