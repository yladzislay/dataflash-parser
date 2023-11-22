using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Battery
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BAT2
    {
        // @LoggerMessage: BAT2
        // FMT, 165, 37, BAT2, Qfffffcf, TimeUS,Volt,VoltR,Curr,CurrTot,EnrgTot,Temp,Res
        // @Description: Gathered battery data
        // @Field: TimeUS: microseconds since system startup
        // @Field: Instance: battery instance number
        // @Field: Volt: measured voltage
        // @Field: VoltR: estimated resting voltage
        // @Field: Curr: measured current
        // @Field: CurrTot: current * time
        // @Field: EnrgTot: energy this battery has produced
        // @Field: Temp: measured temperature
        // @Field: Res: estimated temperature resistance

        public ulong TimeUS { get; set; }
        public float Volt { get; set; }
        public float VoltR { get; set; }
        public float Curr { get; set; }
        public float CurrTot { get; set; }
        public float EnrgTot { get; set; }

        private readonly short _Temp;

        public double Temp => _Temp.Toc();

        public float Res { get; set; }
    }
}