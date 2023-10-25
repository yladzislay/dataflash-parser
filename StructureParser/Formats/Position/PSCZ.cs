using System.Runtime.InteropServices;

namespace StructureParser.Formats.Position
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PSCZ
    {
        // FMT, 246, 35, PSCZ, Qffffff, TimeUS,TPZ,PZ,TVZ,VZ,TAZ,AZ

        public float TimeUS { get; set; }
        public float TPZ { get; set; }
        public float PZ { get; set; }
        public float TVZ { get; set; }
        public float VZ { get; set; }
        public float TAZ { get; set; }
        public float AZ { get; set; }
    }
}