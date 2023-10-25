using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Position
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct VISO
    {
        // FMT, 218, 43, VISO, Qffffffff, TimeUS,dt,AngDX,AngDY,AngDZ,PosDX,PosDY,PosDZ,conf

        public ulong TimeUS { get; set; }
        public float dt { get; set; }
        public float AngDX { get; set; }
        public float AngDY { get; set; }
        public float AngDZ { get; set; }
        public float PosDX { get; set; }
        public float PosDY { get; set; }
        public float PosDZ { get; set; }
        public float conf { get; set; }
    }
}