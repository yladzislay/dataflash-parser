using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FMTU
    {
        // @LoggerMessage: FMTU
        // FMT, 201, 44, FMTU, QBNN, TimeUS,FmtType,UnitIds,MultIds
        // @Description: Message defining units and multipliers used for fields of other messages
        // @Field: TimeUS: microseconds since system startup
        // @Field: FmtType: numeric reference to associated FMT message
        // @Field: UnitIds: each character refers to a UNIT message.  The unit at an offset corresponds to the field at the same offset in FMT.Format
        // @Field: MultIds: each character refers to a MULT message.  The multiplier at an offset corresponds to the field at the same offset in FMT.Format

        public ulong TimeUS { get; set; }
        public byte FmtType { get; set; }

        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UnitIds { get; set; }

        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)] 
        public string MultIds { get; set; }
    }
}