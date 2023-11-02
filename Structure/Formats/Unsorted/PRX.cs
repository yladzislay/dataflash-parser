using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PRX
    {
        // FMT, 221, 56, PRX, QBfffffffffff, TimeUS,Health,D0,D45,D90,D135,D180,D225,D270,D315,DUp,CAn,CDis

        public ulong TimeUS { get; set; }
        public byte Health { get; set; }
        public float D0 { get; set; }
        public float D45 { get; set; }
        public float D90 { get; set; }
        public float D135 { get; set; }
        public float D180 { get; set; }
        public float D225 { get; set; }
        public float D270 { get; set; }
        public float D315 { get; set; }
        public float DUp { get; set; }
        public float CAn { get; set; }
        public float CDis { get; set; }
    }
}