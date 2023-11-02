using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Position
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GUID
    {
        // FMT, 17, 36, GUID, QBffffff, TimeUS,Type,pX,pY,pZ,vX,vY,vZ

        public ulong TimeUS { get; set; }
        public byte Type { get; set; }
        public float pX { get; set; }
        public float pY { get; set; }
        public float pZ { get; set; }
        public float vX { get; set; }
        public float vY { get; set; }
        public float vZ { get; set; }
    }
}