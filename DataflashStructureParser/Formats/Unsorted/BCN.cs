using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BCN
    {
        // FMT, 220, 41, BCN, QBBfffffff, TimeUS,Health,Cnt,D0,D1,D2,D3,PosX,PosY,PosZ

        public ulong TimeUS { get; set; }
        public byte Health { get; set; }
        public byte Cnt { get; set; }
        public float D0 { get; set; }
        public float D1 { get; set; }
        public float D2 { get; set; }
        public float D3 { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
    }
}