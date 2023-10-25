using System.Runtime.InteropServices;

namespace StructureParser.Formats.Position
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OF
    {
        // FMT, 3, 28, OF, QBffff, TimeUS,Qual,flowX,flowY,bodyX,bodyY

        public ulong TimeUS { get; set; }
        public byte Qual { get; set; }
        public float flowX { get; set; }
        public float flowY { get; set; }
        public float bodyX { get; set; }
        public float bodyY { get; set; }
    }
}