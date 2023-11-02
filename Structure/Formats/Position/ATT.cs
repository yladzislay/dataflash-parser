using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Position
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ATT
    {
        // @LoggerMessage: ATT
        // FMT, 163, 27, ATT, QccccCCCC, TimeUS,DesRoll,Roll,DesPitch,Pitch,DesYaw,Yaw,ErrRP,ErrYaw
        // @Description: Canonical vehicle attitude
        // @Field: TimeUS: microseconds since system startup
        // @Field: DesRoll: vehicle desired roll
        // @Field: Roll: achieved vehicle roll
        // @Field: DesPitch: vehicle desired pitch
        // @Field: Pitch: achieved vehicle pitch
        // @Field: DesYaw: vehicle desired yaw
        // @Field: Yaw: achieved vehicle yaw
        // @Field: ErrRP: lowest estimated gyro drift error
        // @Field: ErrYaw: difference between measured yaw and DCM yaw estimate

        public ulong TimeUS { get; set; }

        private readonly short _DesRoll;
        private readonly short _Roll;
        private readonly short _DesPitch;
        private readonly short _Pitch;
        private readonly ushort _DesYaw;
        private readonly ushort _Yaw;
        private readonly ushort _ErrRP;
        private readonly ushort _ErrYaw;

        public double DesRoll => _DesRoll.Toc();
        public double Roll => _Roll.Toc();
        public double DesPitch => _DesPitch.Toc();
        public double Pitch => _Pitch.Toc();
        public double DesYaw => _DesYaw.ToC();
        public double Yaw => _Yaw.ToC();
        public double ErrRP => _ErrRP.ToC();
        public double ErrYaw => _ErrYaw.ToC();
    }
}