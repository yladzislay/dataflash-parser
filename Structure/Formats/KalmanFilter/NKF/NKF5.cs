using System.Runtime.InteropServices;
using UDIE.Adrupilot.Dataflash.Structure.Helpers;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.KalmanFilter.NKF
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NKF5
    {
        // FMT, 68, 40, NKF5, QBhhhcccCCfff, TimeUS, NI, FIX, FIY, AFI, HAGL, offset, RI, rng, Herr, eAng, eVel, ePos

        public ulong TimeUS { get; set; }
        public byte NI { get; set; }
        public short FIX { get; set; }
        public short FIY { get; set; }
        public short AFI { get; set; }

        private readonly short _HAGL;
        private readonly short _offset;
        private readonly short _RI;
        private readonly ushort _rng;
        private readonly ushort _Herr;

        public double HAGL => _HAGL.Toc();
        public double offset => _offset.Toc();
        public double RI => _RI.Toc();
        public double rgn => _rng.ToC();
        public double Herr => _Herr.ToC();

        public float eAng { get; set; }
        public float eVel { get; set; }
        public float ePos { get; set; }
    }
}