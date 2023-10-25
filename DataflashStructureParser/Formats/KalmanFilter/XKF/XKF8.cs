using System.Runtime.InteropServices;
using DronesCloud.Logs.Extensions;

namespace DataflashStructureParser.Formats.KalmanFilter.XKF
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct XKF8
    {
        // FMT, 83, 33, XKF8, Qcccccchhhcc, TimeUS,IVN,IVE,IVD,IPN,IPE,IPD,IMX,IMY,IMZ,IYAW,IVT

        public ulong TimeUS { get; set; }

        private readonly short _IVN;
        private readonly short _IVE;
        private readonly short _IVD;
        private readonly short _IPN;
        private readonly short _IPE;
        private readonly short _IPD;

        public double IVN => _IVN.Toc();
        public double IVE => _IVE.Toc();
        public double IVD => _IVD.Toc();
        public double IPN => _IPN.Toc();
        public double IPE => _IPE.Toc();
        public double IPD => _IPD.Toc();

        public short IMX { get; set; }
        public short IMY { get; set; }
        public short IMZ { get; set; }

        private readonly short _IYAW;
        private readonly short _IVT;

        public double IYAW => _IYAW.Toc();
        public double IVT => _IVT.Toc();
    }
}