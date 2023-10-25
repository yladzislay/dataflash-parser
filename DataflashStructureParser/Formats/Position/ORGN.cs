using System.Runtime.InteropServices;
using DronesCloud.Logs.Extensions;

namespace DataflashStructureParser.Formats.Position
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ORGN
    {
        // FMT, 193, 24, ORGN, QBLLe, TimeUS,Type,Lat,Lng,Alt

        public ulong TimeUS { get; set; }
        public byte Type { get; set; }

        private readonly int _Lat;
        private readonly int _Lng;
        private readonly int _Alt;

        public double Lat => _Lat.ToL();
        public double Lng => _Lng.ToL();
        public double Alt => _Alt.Toe();
    }
}