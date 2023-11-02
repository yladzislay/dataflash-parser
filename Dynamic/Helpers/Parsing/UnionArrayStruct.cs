using System.Linq;
using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Dynamic.Helpers.Parsing
{
    [StructLayout(LayoutKind.Explicit)]
    public struct UnionArrayStruct
    {
        public UnionArrayStruct(byte[] bytes)
        {
            Shorts = null;
            Bytes = bytes;
        }

        [FieldOffset(0)] public byte[] Bytes;

        [FieldOffset(0)] public short[] Shorts;

        public override string ToString()
        {
            return "[" + string.Join(" ", Shorts.Take(Bytes.Length / 2).ToList()) + "]";
        }
    }
}