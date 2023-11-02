using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CMD
    {
        // FMT, 143, 46, CMD, QHHHfffffffB, TimeUS,CTot,CNum,CId,Prm1,Prm2,Prm3,Prm4,Lat,Lng,Alt,Frame

        public ulong TimeUS { get; set; }
        public ushort CTot { get; set; }
        public ushort CNum { get; set; }
        public ushort CId { get; set; }
        public float Prm1 { get; set; }
        public float Prm2 { get; set; }
        public float Prm3 { get; set; }
        public float Prm4 { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public float Alt { get; set; }
        public byte Frame { get; set; }
    }
}