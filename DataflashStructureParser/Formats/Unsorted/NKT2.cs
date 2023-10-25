using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NKT2
    {
        // FMT, 252, 47, NKT2, QIffffffff, TimeUS,Cnt,IMUMin,IMUMax,EKFMin,EKFMax,AngMin,AngMax,VMin,VMax

        public ulong TimeUS { get; set; }
        public uint Cnt { get; set; }
        public float IMUMin { get; set; }
        public float IMUMax { get; set; }
        public float EKFMin { get; set; }
        public float EKFMax { get; set; }
        public float AngMin { get; set; }
        public float AngMax { get; set; }
        public float VMin { get; set; }
        public float VMax { get; set; }
    }
}