using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Sensors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RCIN
    {
        // @LoggerMessage: RCIN
        // FMT, 135, 39, RCIN, QHHHHHHHHHHHHHH, TimeUS,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12,C13,C14
        // @Description: RC input channels to vehicle
        // @Field: TimeUS: microseconds since system startup
        // @Field: C1: channel 1 input
        // @Field: C2: channel 2 input
        // @Field: C3: channel 3 input
        // @Field: C4: channel 4 input
        // @Field: C5: channel 5 input
        // @Field: C6: channel 6 input
        // @Field: C7: channel 7 input
        // @Field: C8: channel 8 input
        // @Field: C9: channel 9 input
        // @Field: C10: channel 10 input
        // @Field: C11: channel 11 input
        // @Field: C12: channel 12 input
        // @Field: C13: channel 13 input
        // @Field: C14: channel 14 input

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