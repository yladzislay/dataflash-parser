using System.IO;
using System.Linq;

namespace DataflashParser.Helpers;

public class ValidationHelper
{
    public static bool IsDataflashMagic(Stream stream)
    {
        const byte headerByteFirst = 0xA3;
        const byte headerByteSecond = 0x95;
        byte[] headerBytes = { headerByteFirst, headerByteSecond };
        var buffer = new byte[2];
        stream.Position = 0;
        stream.Read(buffer, 0, 2);
        stream.Position = 0;
        return headerBytes.SequenceEqual(buffer);
    }
}