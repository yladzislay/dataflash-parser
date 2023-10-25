using System.Runtime.InteropServices;
using DronesCloud.Logs.Extensions;

namespace DataflashStructureParser.Formats.Engine
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ESC1
    {
        // FMT, 153, 23, ESC1, QeCCcH, TimeUS,RPM,Volt,Curr,Temp,CTot

        public ulong TimeUS { get; set; }

        private readonly int _RPM;
        private readonly ushort _Volt;
        private readonly ushort _Curr;
        private readonly short _Temp;

        public double RPM => _RPM.Toe();
        public double Volt => _Volt.ToC();
        public double Curr => _Curr.ToC();
        public double Temp => _Temp.Toc();

        public ushort CTot { get; set; }

    }
}