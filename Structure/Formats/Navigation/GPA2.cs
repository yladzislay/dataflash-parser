using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Navigation
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GPA2
    {
        // FMT, 196, 26, GPA2, QCCCCBIH, TimeUS,VDop,HAcc,VAcc,SAcc,VV,SMS,Delta

        public ulong TimeUS { get; set; }

        private readonly ushort _VDop;
        private readonly ushort _HAcc;
        private readonly ushort _VAcc;
        private readonly ushort _SAcc;

        public double VDop => _VDop.ToC();
        public double HAcc => _HAcc.ToC();
        public double VAcc => _VAcc.ToC();
        public double SAcc => _SAcc.ToC();

        public byte VV { get; set; }
        public uint SMS { get; set; }
        public ushort Delta { get; set; }
    }
}