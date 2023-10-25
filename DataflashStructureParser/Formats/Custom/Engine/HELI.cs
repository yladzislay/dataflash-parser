using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Custom.Engine
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct HELI
    {
        // FMT, 15, 19, HELI, Qff, TimeUS,DRRPM,ERRPM

        public ulong TimeUS { get; set; }
        public float DRRPM { get; set; }
        public float ERRPM { get; set; }
    }
}