using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.KalmanFilter.XKF
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct XKF1
    {
        // FMT, 76, 55, XKF1, QccCfffffffccce, TimeUS,Roll,Pitch,Yaw,VN,VE,VD,dPD,PN,PE,PD,GX,GY,GZ,OH

        public ulong TimeUS { get; set; }

        private readonly short _Roll;
        private readonly short _Pitch;
        private readonly ushort _Yaw;

        public double Roll => _Roll.Toc();
        public double Pitch => _Pitch.Toc();
        public double Yaw => _Yaw.ToC();

        public float VN { get; set; }
        public float VE { get; set; }
        public float VD { get; set; }
        public float dPD { get; set; }
        public float PN { get; set; }
        public float PE { get; set; }
        public float PD { get; set; }

        private readonly short _GX;
        private readonly short _GY;
        private readonly short _GZ;
        private readonly int _OH;

        public double GX => _GX.Toc();
        public double GY => _GY.Toc();
        public double GZ => _GZ.Toc();
        public double OH => _OH.Toe();
    }
}