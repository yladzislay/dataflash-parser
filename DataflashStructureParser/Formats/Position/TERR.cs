using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Position
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TERR
    {
        // FMT, 148, 34, TERR, QBLLHffHH, TimeUS,Status,Lat,Lng,Spacing,TerrH,CHeight,Pending,Loaded

        public ulong TimeUS { get; set; }
        public byte Status { get; set; }
        public int Lat { get; set; }
        public int Lng { get; set; }
        public ushort Spacing { get; set; }
        public float TerrH { get; set; }
        public float CHeight { get; set; }
        public ushort Pending { get; set; }
        public ushort Loaded { get; set; }
    }
}
