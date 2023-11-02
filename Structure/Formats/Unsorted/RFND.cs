using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RFND
    {
        // FMT, 198, 17, RFND, QCBCB, TimeUS,Dist1,Orient1,Dist2,Orient2

        public ulong TimeUS { get; set; }

        private readonly ushort _Dist1;

        public double Dist1 => _Dist1.ToC();

        public byte Orient1 { get; set; }

        private readonly ushort _Dist2;

        public double Dist2 => _Dist2.ToC();


        public byte Orient2 { get; set; }
    }
}