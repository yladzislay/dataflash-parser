using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Custom.Powerboard
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PBRD
    {
        // FMT, 230, 36, PBRD, QBffffff, TimeUS,DCinfo,TempMOSFET,ResVolt,Curr8V,Temp8V,ConsWh8V,Temp2

        public ulong TimeUS { get; set; }
        public byte DCinfo { get; set; }
        public float TempMOSFET { get; set; }
        public float ResVolt { get; set; }
        public float Curr8V { get; set; }
        public float Temp8V { get; set; }
        public float ConsWh8V { get; set; }
        public float Temp2 { get; set; }
    }
}