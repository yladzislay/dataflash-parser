using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Position
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SIM
    {
        // FMT, 142, 45, SIM, QccCfLLffff, TimeUS,Roll,Pitch,Yaw,Alt,Lat,Lng,Q1,Q2,Q3,Q4
        public ulong TimeUS { get; set; }

        public short Roll { get; set; }
        public short Pitch { get; set; }
        public ushort Yaw { get; set; }
        public float Alt { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        
        
        public float Q1 { get; set; }
        public float Q2 { get; set; }
        public float Q3 { get; set; }
        public float Q4 { get; set; }
    }
}