using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MSG
    {
        // FMT, 134, 75, MSG, QZ, TimeUS,Message

        public ulong TimeUS { get; set; }

        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)] 
        public string Message { get; set; }
    }
}