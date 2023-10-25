using System.Runtime.InteropServices;

namespace StructureParser.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SBFE
    {
        // FMT, 175, 63, SBFE, QIHBBdddfffff, TimeUS,TOW,WN,Mode,Err,Lat,Lng,Height,Undul,Vn,Ve,Vu,COG

        public ulong TimeUS { get; set; }
        public uint TOW { get; set; }
        public ushort WN { get; set; }
        public byte Mode { get; set; }
        public byte Err { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public double Height { get; set; }
        public float Undul { get; set; }
        public float Vn { get; set; }
        public float Ve { get; set; }
        public float Vu { get; set; }
        public float COG { get; set; }
    }
}