using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GRXS
    {
        // FMT, 174, 41, GRXS, QddfBBBHBBBBB, TimeUS,prMes,cpMes,doMes,gnss,sv,freq,lock,cno,prD,cpD,doD,trk

        public byte TimeUS { get; set; }
        public byte prMes { get; set; }
        public byte cpMes { get; set; }
        public byte doMes { get; set; }
        public byte gnss { get; set; }
        public byte sv { get; set; }
        public byte freq { get; set; }
        public byte _lock { get; set; }
        public byte cno { get; set; }
        public byte prD { get; set; }
        public byte cpD { get; set; }
        public byte doD { get; set; }
        public byte trk { get; set; }
    }
}