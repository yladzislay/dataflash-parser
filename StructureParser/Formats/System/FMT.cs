using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace StructureParser.Formats.System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FMT
    {
        // @LoggerMessage: FMT
        // FMT, 128, 89, FMT, BBnNZ, Type,Length,Name,Format,Columns
        // @Description: Message defining the format of messages in this file
        // @URL: https://ardupilot.org/dev/docs/code-overview-adding-a-new-log-message.html
        // @Field: Type: unique-to-this-log identifier for message being defined
        // @Field: Length: the number of bytes taken up by this message (including all headers)
        // @Field: Name: name of the message being defined
        // @Field: Format: character string defining the C-storage-type of the fields in this message
        // @Field: Columns: the labels of the message being defined

        public byte Type { get; set; }
        public byte Length {get; set; }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] 
        private readonly byte[] _Name;

        public string Name => Encoding.ASCII.GetString(_Name).Trim('\0');

        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)] 
        public string Format { get; set; }
     
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)] 
        private readonly string _Columns;

        public IEnumerable<string> Columns => _Columns.Split(",");
    }
}