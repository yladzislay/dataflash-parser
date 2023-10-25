using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PTUN
    {
        // FMT, 14, 22, PTUN, QBfHHH, TimeUS,Param,TunVal,CtrlIn,TunLo,TunHi

        public ulong TimeUS { get; set; }
        public byte Param { get; set; }
        public float TunVal { get; set; }
        public ushort CtrlIn { get; set; }
        public ushort TunLo { get; set; }
        public ushort TunHi { get; set; }
    }
}