using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SBRE
    {
        // FMT, 211, 23, SBRE, QHIiBB, TimeUS,GWk,GMS,ns_residual,level,quality

        public ulong TimeUS { get; set; }
        public ushort GWk { get; set; }
        public uint GMS { get; set; }
        public int ns_residual { get; set; }
        public byte level { get; set; }
        public byte quality { get; set; }
    }
}