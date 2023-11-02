using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Position
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CTRL
    {
        // FMT, 251, 31, CTRL, Qfffff, TimeUS,RMSRollP,RMSRollD,RMSPitchP,RMSPitchD,RMSYaw

        public ulong TimeUS { get; set; }
        public float RMSRollP { get; set; }
        public float RMSRollD { get; set; }
        public float RMSPitchP { get; set; }
        public float RMSPitchD { get; set; }
        public float RMSYaw { get; set; }
    }
}