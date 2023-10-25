using System.Runtime.InteropServices;

namespace StructureParser.Formats.Navigation
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RALY
    {
        // FMT, 217, 23, RALY, QBBLLh, TimeUS,Tot,Seq,Lat,Lng,Alt

        public ulong TimeUS { get; set; }
        public byte Tot { get; set; }
        public byte Seq { get; set; }
        
        private readonly int _Lat;
        private readonly int _Lng;

        public double Lat => _Lat.ToL();
        public double Lng => _Lat.ToL();

        public short Alt { get; set; }
    }
}
