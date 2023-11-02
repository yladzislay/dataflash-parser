using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Navigation
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UBX2
    {
        // @LoggerMessage: UBX2
        // FMT, 150, 16, UBX2, QBbBbB, TimeUS,Instance,ofsI,magI,ofsQ,magQ
        // @Description: uBlox-specific GPS information (part 2)
        // @Field: TimeUS: microseconds since system startup
        // @Field: Instance: GPS instance number
        // @Field: ofsI: imbalance of I part of complex signal
        // @Field: magI: magnitude of I part of complex signal
        // @Field: ofsQ: imbalance of Q part of complex signal
        // @Field: magQ: magnitude of Q part of complex signal

        public ulong TimeUS { get; set; }
        public byte Instance { get; set; }
        public sbyte ofsI { get; set; }
        public byte magI { get; set; }
        public sbyte ofsQ { get; set; }
        public byte magQ { get; set; }
    }
}