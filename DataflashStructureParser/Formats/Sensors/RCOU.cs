using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RCOU
    {
        // @LoggerMessage: RCOU
        // FMT, 136, 39, RCOU, QHHHHHHHHHHHHHH, TimeUS,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12,C13,C14
        // @Description: Servo channel output values
        // @Field: TimeUS: microseconds since system startup
        // @Field: C1: channel 1 output
        // @Field: C2: channel 2 output
        // @Field: C3: channel 3 output
        // @Field: C4: channel 4 output
        // @Field: C5: channel 5 output
        // @Field: C6: channel 6 output
        // @Field: C7: channel 7 output
        // @Field: C8: channel 8 output
        // @Field: C9: channel 9 output
        // @Field: C10: channel 10 output
        // @Field: C11: channel 11 output
        // @Field: C12: channel 12 output
        // @Field: C13: channel 13 output
        // @Field: C14: channel 14 output

        public ulong TimeUS { get; set; }
        public ushort C1 { get; set; }
        public ushort C2 { get; set; }
        public ushort C3 { get; set; }
        public ushort C4 { get; set; }
        public ushort C5 { get; set; }
        public ushort C6 { get; set; }
        public ushort C7 { get; set; }
        public ushort C8 { get; set; }
        public ushort C9 { get; set; }
        public ushort C10 { get; set; }
        public ushort C11 { get; set; }
        public ushort C12 { get; set; }
        public ushort C13 { get; set; }
        public ushort C14 { get; set; }
    }
}