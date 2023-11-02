using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Position
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PSC
    {
        // FMT, 247, 59, PSC, Qffffffffffff, TimeUS,TPX,TPY,PX,PY,TVX,TVY,VX,VY,TAX,TAY,AX,AY
        // TPX = Desired position in X
        // TPY = Desired position in X
        // PX = Current position X relative to the home location in cm
        // PY = Current position Y relative to the home location in cm
        // TVX = Desired velocity in X
        // TVY = Desired velocity in Y
        // VX = Current velocity X in cm/s
        // VY = Current velocity Y in cm/s
        // TAX = Desired acceleration in X
        // TAY = Desired acceleration in Y
        // AX = Current acceleration X in cm/s/s
        // AY = Current acceleration Y in cm/s/s

        public ulong TimeUS { get; set; }
        public float TPX { get; set; }
        public float TPY { get; set; }
        public float PX { get; set; }
        public float PY { get; set; }
        public float TVX { get; set; }
        public float TVY { get; set; }
        public float VX { get; set; }
        public float VY { get; set; }
        public float TAX { get; set; }
        public float TAY { get; set; }
        public float AX { get; set; }
        public float AY { get; set; }
    }
}