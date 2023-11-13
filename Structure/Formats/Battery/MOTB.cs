using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Battery
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MOTB
    {
        // FMT, 13, 27, MOTB, Qffff, TimeUS,LiftMax,BatVolt,BatRes,ThLimit

        public ulong TimeUS { get; set; }
        public float LiftMax { get; set; }
        public float BatVolt { get; set; }
        public float BatRes { get; set; }
        public float ThLimit { get; set; }
    }
}
