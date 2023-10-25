using System.Runtime.InteropServices;

namespace StructureParser.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ATDE
    {
        // FMT, 12, 19, ATDE, Qff, TimeUS,Angle,Rate

        public ulong TimeUS { get; set; }
        public float Angle { get; set; }
        public float Rate { get; set; }
    }
}