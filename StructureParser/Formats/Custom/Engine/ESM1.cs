using System.Runtime.InteropServices;

namespace StructureParser.Formats.Custom.Engine
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ESM1
    {
        // FMT, 233, 30, ESM1, QhffbBbHf, TimeUS,EngTmp,FuelPrs,OilPrs,OilTmp,ShavOil,CrbTmp,rpm,Boost

        public ulong TimeUS { get; set; }
        public short EngTmp { get; set; }
        public float FuelPrs { get; set; }
        public float OilPrs { get; set; }
        public sbyte OilTmp { get; set; }
        public byte ShavOil { get; set; }
        public sbyte CrbTmp { get; set; }
        public ushort rpm { get; set; }
        public float Boost { get; set; }
    }
}