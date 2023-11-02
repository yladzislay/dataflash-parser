using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Custom.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GMB2
    {
        // FMT, 214, 44, GMB2, IBfffffffff, TimeMS,es,ex,ey,ez,rx,ry,rz,tx,ty,tz

        public uint TimeMS { get; set; }
        public byte es { get; set; }
        public float ex { get; set; }
        public float ey { get; set; }
        public float ez { get; set; }
        public float rx { get; set; }
        public float ry { get; set; }
        public float rz { get; set; }
        public float tx { get; set; }
        public float ty { get; set; }
        public float tz { get; set; }
    }
}