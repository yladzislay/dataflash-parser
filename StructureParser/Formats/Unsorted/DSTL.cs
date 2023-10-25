using System.Runtime.InteropServices;

namespace StructureParser.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DSTL
    {
        // FMT, 188, 56, DSTL, QBfLLeccfeffff, TimeUS,Stg,THdg,Lat,Lng,Alt,XT,Travel,L1I,Loiter,Des,P,I,D

        public ulong TimeUS { get; set; }
        public byte Stg { get; set; }
        public float THdg { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int Alt { get; set; } // x = x / 100
        public short XT { get; set; } // x = x / 100
        public short Travel { get; set; } // x = x / 100
        public float L1I { get; set; }
        public int Loiter { get; set; } // x = x / 100
        public float Des { get; set; }
        public float P { get; set; }
        public float I { get; set; }
        public float D { get; set; }
    }
}