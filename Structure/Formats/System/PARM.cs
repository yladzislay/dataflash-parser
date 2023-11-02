using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PARM
    {
        // FMT, 129, 31, PARM, Nf, Name,Value

        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)] 
        public string Name { get; set; }

        public float Value { get; set; }
    }
}