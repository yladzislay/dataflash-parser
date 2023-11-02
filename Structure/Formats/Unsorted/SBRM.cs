using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SBRM
    {
        // FMT, 210, 123, SBRM, QQQQQQQQQQQQQQQ, TimeUS,msg_flag,1,2,3,4,5,6,7,8,9,10,11,12,13

        public ulong TimeUS { get; set; }
        public ulong msg_flag { get; set; }
        public ulong _1 { get; set; }
        public ulong _2 { get; set; }
        public ulong _3 { get; set; }
        public ulong _4 { get; set; }
        public ulong _5 { get; set; }
        public ulong _6 { get; set; }
        public ulong _7 { get; set; }
        public ulong _8 { get; set; }
        public ulong _9 { get; set; }
        public ulong _10 { get; set; }
        public ulong _11 { get; set; }
        public ulong _12 { get; set; }
        public ulong _13 { get; set; }

    }
}