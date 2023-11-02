using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ST
    {
        // FMT, 145, 37, ST, QIhhhhhh, TimeMS,Loop,Armed,Acc,X,Y,Z,Baro
        
        public ulong TimeMS { get; set; }
        public byte Loop { get; set; }
        public sbyte Armed { get; set; }
        public short AccX { get; set; }
        public short AccY { get; set; }
        public short AccZ { get; set; }
        public short Baro { get; set; }
    }
}