using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UBY1
    {
        // FMT, 151, 22, UBY1, QBHBBHI, TimeUS,Instance,noisePerMS,jamInd,aPower,agcCnt,config

        public ulong TimeUS { get; set; }
        public byte Instance { get; set; }
        public ushort noisePerMS { get; set; }
        public byte jamInd { get; set; }
        public byte aPower { get; set; }
        public ushort agcCnt { get; set; }
        public uint config { get; set; }
    }
}