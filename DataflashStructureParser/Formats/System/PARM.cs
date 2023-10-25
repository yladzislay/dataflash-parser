using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PARM
    {
        // FMT, 129, 31, PARM, QNf, TimeUS,Name,Value

        public long TimeUS { get; set; }

        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)] 
        public string Name { get; set; }

        public float Value { get; set; }
    }
}