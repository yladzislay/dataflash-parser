using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DFLT
    {
        // FMT, 10, 16, DFLT, QBf, TimeUS,Id,Value

        public ulong TimeUS { get; set; }
        public byte Id { get; set; }
        public float Value { get; set; }
    }
}