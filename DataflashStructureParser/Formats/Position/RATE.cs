using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Position
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RATE
    {
        // @LoggerMessage: RATE
        // FMT, 216, 59, RATE, Qffffffffffff, TimeUS,RDes,R,ROut,PDes,P,POut,YDes,Y,YOut,ADes,A,AOut
        // @Description: Desired and achieved vehicle attitude rates
        // @Field: TimeUS: microseconds since system startup
        // @Field: RDes: vehicle desired roll rate
        // @Field: R: achieved vehicle roll rate
        // @Field: ROut: normalized output for Roll
        // @Field: PDes: vehicle desired pitch rate
        // @Field: P: vehicle pitch rate
        // @Field: POut: normalized output for Pitch
        // @Field: YDes: vehicle desired yaw rate
        // @Field: Y: achieved vehicle yaw rate
        // @Field: YOut: normalized output for Yaw
        // @Field: YDes: vehicle desired yaw rate
        // @Field: Y: achieved vehicle yaw rate
        // @Field: ADes: desired vehicle vertical acceleration
        // @Field: A: achieved vehicle vertical acceleration
        // @Field: AOut: percentage of vertical thrust output current being used

        public ulong TimeUS { get; set; }
        public float RDes { get; set; }
        public float R { get; set; }
        public float ROut { get; set; }
        public float PDes { get; set; }
        public float P { get; set; }
        public float POut { get; set; }
        public float YDes { get; set; }
        public float Y { get; set; }
        public float YOut { get; set; }
        public float ADes { get; set; }
        public float A { get; set; }
        public float AOut { get; set; }
    }
}
