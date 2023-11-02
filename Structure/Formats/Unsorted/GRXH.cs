using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GRXH
    {
        // FMT, 173, 24, GRXH, QdHbBB, TimeUS,rcvTime,week,leapS,numMeas,recStat

        public ulong TimeUS { get; set; }
        public double rcvTime { get; set; }
        public ushort week { get; set; }
        public sbyte leapS { get; set; }
        public byte numMeas { get; set; }
        public byte recStat { get; set; }
    }
}