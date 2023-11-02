using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Unsorted
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