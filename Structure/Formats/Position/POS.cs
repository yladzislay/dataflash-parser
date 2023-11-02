using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Position
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct POS
    {
        // FMT, 182, 31, POS, QLLfff, TimeUS,Lat,Lng,Alt,RelHomeAlt,RelOriginAlt

        public ulong TimeUS { get; set; }

        private readonly int _Lat;
        private readonly int _Lng;

        public double Lat => _Lat.ToL();
        public double Lng => _Lng.ToL();

        public float Alt { get; set; }
        public float RelHomeAlt { get; set; }
        public float RelOriginAlt { get; set; }
    }
}
