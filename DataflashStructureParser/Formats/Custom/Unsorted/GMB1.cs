using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Custom.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GMB1
    {
        // FMT, 213, 47, GMB1, Iffffffffff, TimeMS,dt,dax,day,daz,dvx,dvy,dvz,jx,jy,jz

        public uint TimeMS { get; set; }
        public float dt { get; set; }
        public float dax { get; set; }
        public float day { get; set; }
        public float daz { get; set; }
        public float dvx { get; set; }
        public float dvy { get; set; }
        public float dvz { get; set; }
        public float jx { get; set; }
        public float jy { get; set; }
        public float jz { get; set; }
    }
}