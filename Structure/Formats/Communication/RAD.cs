using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Communication
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RAD
    {
        // FMT, 144, 20, RAD, QBBBBBHH, TimeUS,RSSI,RemRSSI,TxBuf,Noise,RemNoise,RxErrors,Fixed

        public ulong TimeUS { get; set; }
        public byte RSSI { get; set; }
        public byte RemRSSI { get; set; }
        public byte TxBuf { get; set; }
        public byte Noise { get; set; }
        public byte RemNoise { get; set; }
        public ushort RxErrors { get; set; }
        public ushort Fixed { get; set; }
    }
}