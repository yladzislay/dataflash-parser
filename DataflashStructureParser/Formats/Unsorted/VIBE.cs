using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct VIBE
    {
        // @LoggerMessage: VIBE
        // FMT, 189, 35, VIBE, QfffIII, TimeUS,VibeX,VibeY,VibeZ,Clip0,Clip1,Clip2
        // @Description: Processed (acceleration) vibration information
        // @Field: TimeUS: microseconds since system startup
        // @Field: VibeX: Primary accelerometer filtered vibration, x-axis
        // @Field: VibeY: Primary accelerometer filtered vibration, y-axis
        // @Field: VibeZ: Primary accelerometer filtered vibration, z-axis
        // @Field: Clip0: Number of clipping events on 1st accelerometer
        // @Field: Clip1: Number of clipping events on 2nd accelerometer
        // @Field: Clip2: Number of clipping events on 3rd accelerometer

        public ulong TimeUS { get; set; }
        public float VibeX { get; set; }
        public float VibeY { get; set; }
        public float VibeZ { get; set; }
        public uint Clip0 { get; set; }
        public uint Clip1 { get; set; }
        public uint Clip2 { get; set; }
    }
}