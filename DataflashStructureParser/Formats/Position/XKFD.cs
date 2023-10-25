using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Position
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct XKFD
    {
        // FMT, 88, 35, XKFD, Qffffff, TimeUS,IX,IY,IZ,IVX,IVY,IVZ

        public ulong TimeUS { get; set; }
        public float IX { get; set; }
        public float IY { get; set; }
        public float IZ { get; set; }
        public float IVX { get; set; }
        public float IVY { get; set; }
        public float IVZ { get; set; }
    }
}