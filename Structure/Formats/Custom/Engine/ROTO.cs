using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Custom.Engine
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ROTO
    {
        // FMT, 235, 23, ROTO, QbffBH, TimeUS,OilTmp,OilPress,HydroPress,ShavOil,rpm

        public ulong TimeUS { get; set; }
        public sbyte OilTmp { get; set; }
        public float OilPress { get; set; }
        public float HydroPress { get; set; }
        public byte ShavOil { get; set; }
        public ushort rpm { get; set; }

    }
}
