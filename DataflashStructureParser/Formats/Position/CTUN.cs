using System.Runtime.InteropServices;
using DronesCloud.Logs.Extensions;

namespace DataflashStructureParser.Formats.Position
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CTUN
    {
        // FMT, 2, 53, CTUN, Qffffffefcfhh, TimeUS,ThI,ABst,ThO,ThH,DAlt,Alt,BAlt,DSAlt,SAlt,TAlt,DCRt,CRt

        public ulong TimeUS { get; set; }

        public float ThI { get; set; }
        public float ABst { get; set; }
        public float ThO { get; set; }
        public float ThH { get; set; }
        public float DAlt { get; set; }
        public float Alt { get; set; }

        private readonly int _BAlt;
        public double BAlt => _BAlt.Toe();

        public float DSAlt { get; set; }
        
        private readonly short _SAlt;
        public double SAlt => _SAlt.Toc();

        public float TAlt { get; set; }
        public short DCRt { get; set; }
        public short CRt { get; set; }
    }
}
