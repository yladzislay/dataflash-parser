using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.KalmanFilter.XKF
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct XKF7
    {
        // FMT, 82, 34, XKF7, QccccchhhhhhB, TimeUS,AX,AY,AZ,VWN,VWE,MN,ME,MD,MX,MY,MZ,MI

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