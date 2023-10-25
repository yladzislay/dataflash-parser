using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ATUN
    {
        // FMT, 11, 41, ATUN, QBBfffffff, TimeUS,Axis,TuneStep,Targ,Min,Max,RP,RD,SP,ddt

        public ulong TimeUS { get; set; }
        public byte Axis { get; set; }
        public byte TuneStep { get; set; }
        public float Targ { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }
        public float RP { get; set; }
        public float RD { get; set; }
        public float SP { get; set; }
        public float ddt { get; set; }
    }
}