using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ISBH
    {
        // FMT, 224, 31, ISBH, QHBBHHQf, TimeUS,N,type,instance,mul,smp_cnt,SampleUS,smp_rate

        public ulong TimeUS { get; set; }
        public ushort N { get; set; }
        public byte type { get; set; }
        public byte instance { get; set; }
        public ushort mul { get; set; }
        public ushort smp_cnt { get; set; }
        public ulong SampleUS { get; set; }
        public float smp_rate { get; set; }
    }
}