using System.Runtime.InteropServices;

namespace StructureParser.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SBPH
    {
        // FMT, 204, 23, SBPH, QIII, TimeUS,CrcError,LastInject,IARhyp

        public ulong TimeUS { get; set; }
        public uint CrcError { get; set; }
        public uint LastInject { get; set; }
        public uint IARhyp { get; set; }
    }
}