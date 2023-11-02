using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DU16
    {
        // FMT, 7, 14, DU16, QBH, TimeUS,Id,Value

        public ulong TimeUS { get; set; }
        public byte Id { get; set; }
        public ushort Value { get; set; }
    }
}