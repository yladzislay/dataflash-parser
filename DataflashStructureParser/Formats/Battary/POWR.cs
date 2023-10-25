using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Battary
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct POWR
    {
        // FMT, 140, 22, POWR, QffHB, TimeUS,Vcc,VServo,Flags,Safety

        public ulong TimeUS { get; set; }
        public float Vcc { get; set; }
        public float VServo { get; set; }
        public ushort Flags { get; set; }
        public byte Safety { get; set; }
    }
}