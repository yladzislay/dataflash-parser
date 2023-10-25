using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Position
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PL
    {
        // FMT, 16, 29, PL, QBBffff, TimeUS,Heal,TAcq,pX,pY,vX,vY

        public ulong TimeUS { get; set; }
        public byte Heal { get; set; }
        public byte TAcq { get; set; }
        public float pX { get; set; }
        public float pY { get; set; }
        public float vX { get; set; }
        public float vY { get; set; }
    }
}