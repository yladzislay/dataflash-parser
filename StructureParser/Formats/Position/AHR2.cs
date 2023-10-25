using System.Runtime.InteropServices;

namespace StructureParser.Formats.Position
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AHR2
    {
        // FMT, 141, 45, AHR2, QccCfLLffff, TimeUS,Roll,Pitch,Yaw,Alt,Lat,Lng,Q1,Q2,Q3,Q4

        public ulong TimeUS { get; set; }

        private readonly short _Roll;
        private readonly short _Pitch;
        private readonly ushort _Yaw;

        public double Roll => _Roll.Toc();
        public double Pitch => _Pitch.Toc();
        public double Yaw => _Yaw.ToC();

        public float Alt { get; set; }

        private readonly int _Lat;
        private readonly int _Lng;

        public double Lat => _Lat.ToL();
        public double Lng => _Lng.ToL();

        public float Q1 { get; set; }
        public float Q2 { get; set; }
        public float Q3 { get; set; }
        public float Q4 { get; set; }
    }
}
