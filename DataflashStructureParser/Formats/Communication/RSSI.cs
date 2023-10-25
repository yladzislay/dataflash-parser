using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Communication
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RSSI
    {
        // FMT, 137, 15, RSSI, Qf, TimeUS,RXRSSI

        public ulong TimeUS { get; set; }
        public float RXRSSI { get; set; }
    }
}