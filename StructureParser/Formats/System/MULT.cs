using System.Runtime.InteropServices;

namespace StructureParser.Formats.System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MULT
    {
        // @LoggerMessage: MULT
        // FMT, 203, 20, MULT, Qbd, TimeUS,Id,Mult
        // @Description: Message mapping from single character to numeric multiplier
        // @Field: TimeUS: microseconds since system startup
        // @Field: Id: character referenced by FMTU
        // @Field: Mult: numeric multiplier

        public ulong TimeUS { get; set; }
        public sbyte Id { get; set; }
        public double Mult { get; set; }
    }
}