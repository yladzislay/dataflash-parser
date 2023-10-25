using System.Runtime.InteropServices;

namespace StructureParser.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CUV
    {
        // FMT, 248, 31, CUV, Qfffff, TimeUS,CUV1,CUV2,CUV3,CUV4,CUV5

        public ulong TimeUS { get; set; }
        public float CUV1 { get; set; }
        public float CUV2 { get; set; }
        public float CUV3 { get; set; }
        public float CUV4 { get; set; }
        public float CUV5 { get; set; }
    }
}