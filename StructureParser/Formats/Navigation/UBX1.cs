using System.Runtime.InteropServices;

namespace StructureParser.Formats.Navigation
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UBX1
    {
        // @LoggerMessage: UBX1
        // FMT, 149, 22, UBX1, QBHBBHI, TimeUS,Instance,noisePerMS,jamInd,aPower,agcCnt,config
        // @Description: uBlox-specific GPS information (part 1)
        // @Field: TimeUS: microseconds since system startup
        // @Field: Instance: GPS instance number
        // @Field: noisePerMS: noise level as measured by GPS
        // @Field: jamInd: jamming indicator; higher is more likely jammed
        // @Field: aPower: antenna power indicator; 2 is don't know
        // @Field: agcCnt: automatic gain control monitor
        // @Field: config: bitmask for messages which haven't been seen

        public ulong TimeUS { get; set; }
        public byte Instance { get; set; }
        public ushort noisePerMS { get; set; }
        public byte jamInd { get; set; }
        public byte aPower { get; set; }
        public ushort agcCnt { get; set; }
        public uint config { get; set; }
    }
}
