using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Position
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ARSP
    {
        // FMT, 162, 32, ARSP, QffcffBBB, TimeUS,Airspeed,DiffPress,Temp,RawPress,Offset,U,Health,Primary

        public ulong TimeUS { get; set; }
        public float Airspeed { get; set; }
        public float DiffPress { get; set; }

        private readonly short _Temp;
        public double Temp => _Temp.Toc();

        public float RawPress { get; set; }
        public float Offset { get; set; }
        public byte U { get; set; }
        public byte Health { get; set; }
        public byte Primary { get; set; }
    }
}