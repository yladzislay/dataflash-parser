using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SBRH
    {
        // FMT, 209, 67, SBRH, QQQQQQQQ, TimeUS,msg_flag,1,2,3,4,5,6

        public ulong TimeUS { get; set; }
        public ulong msg_flag { get; set; }
        public ulong _1 { get; set; }
        public ulong _2 { get; set; }
        public ulong _3 { get; set; }
        public ulong _4 { get; set; }
        public ulong _5 { get; set; }
        public ulong _6 { get; set; }

    }
}