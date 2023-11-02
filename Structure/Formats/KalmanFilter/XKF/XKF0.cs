using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.KalmanFilter.XKF
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct XKF0
    {
        // FMT, 85, 36, XKF0, QBccCCcccccccc, TimeUS,ID,rng,innov,SIV,TR,BPN,BPE,BPD,OFH,OFL,OFN,OFE,OFD

        public ulong TimeUS { get; set; }
        public byte ID { get; set; }

        private readonly short _rng;
        private readonly short _innov;
        private readonly ushort _SIV;
        private readonly ushort _TR;
        private readonly short _BPN;
        private readonly short _BPE;
        private readonly short _BPD;
        private readonly short _OFH;
        private readonly short _OFL;
        private readonly short _OFN;
        private readonly short _OFE;
        private readonly short _OFD;

        public double rng => _rng.Toc();
        public double innov => _innov.Toc();
        public double SIV => _SIV.ToC();
        public double TR => _TR.ToC();
        public double BPN => _BPN.Toc();
        public double BPE => _BPE.Toc();
        public double BPD => _BPD.Toc();
        public double OFH => _OFH.Toc();
        public double OFL => _OFL.Toc();
        public double OFN => _OFN.Toc();
        public double OFE => _OFE.Toc();
        public double OFD => _OFD.Toc();
    }
}