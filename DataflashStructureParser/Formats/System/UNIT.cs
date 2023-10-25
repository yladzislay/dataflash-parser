using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UNIT
    {
        // @LoggerMessage: UNIT
        // FMT, 202, 76, UNIT, QbZ, TimeUS,Id,Label
        // @Description: Message mapping from single character to SI unit
        // @Field: TimeUS: microseconds since system startup
        // @Field: Id: character referenced by FMTU
        // @Field: Label: Unit - SI where available

        public ulong TimeUS { get; set; }
        public sbyte Id { get; set; }
        
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)] 
        public string Label { get; set; }
    }
}