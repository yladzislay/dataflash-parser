using System.Runtime.InteropServices;

namespace StructureParser.Formats.Navigation
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SRTL
    {
        // @LoggerMessage: SRTL
        // FMT, 223, 29, SRTL, QBHHBfff, TimeUS,Active,NumPts,MaxPts,Action,N,E,D
        // @Description: SmartRTL statistics
        // @Field: TimeUS: microseconds since system startup
        // @Field: Active: true if SmartRTL could be used right now
        // @Field: NumPts: number of points currently in use
        // @Field: MaxPts: maximum number of points that could be used
        // @Field: Action: most recent internal action taken by SRTL library
        // @Field: N: point associated with most recent action (North component)
        // @Field: E: point associated with most recent action (East component)
        // @Field: D: point associated with most recent action (Down component)

        public ulong TimeUS { get; set; }
        public byte Active { get; set; }
        public ushort NumPts { get; set; }
        public ushort MaxPts { get; set; }
        public byte Action { get; set; }
        public float N { get; set; }
        public float E { get; set; }
        public float D { get; set; }
    }
}
