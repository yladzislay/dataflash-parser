using System.Runtime.InteropServices;
using UDIE.Adrupilot.Dataflash.Structure.Helpers;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.KalmanFilter.NKF
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NKF2
    {
        // FMT, 65, 35, NKF2, QbccccchhhhhhB, TimeUS,AZbias,GSX,GSY,GSZ,VWN,VWE,MN,ME,MD,MX,MY,MZ,MI

        public ulong TimeUS { get; set; }
        public sbyte AZbias { get; set; }

        private readonly short _GSX;
        private readonly short _GSY;
        private readonly short _GSZ;
        private readonly short _VWN;
        private readonly short _VWE;

        public double GSX => _GSX.Toc();
        public double GSY => _GSY.Toc();
        public double GSZ => _GSZ.Toc();
        public double VWN => _VWN.Toc();
        public double VWE => _VWE.Toc();

        public short MN { get; set; }
        public short ME { get; set; }
        public short MD { get; set; }
        public short MX { get; set; }
        public short MY { get; set; }
        public short MZ { get; set; }
        public byte MI { get; set; }
    }
}