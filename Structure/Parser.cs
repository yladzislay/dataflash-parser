using System.Collections.Generic;
using System.IO;
using System.Linq;
using UDIE.Adrupilot.Dataflash.Structure.Formats.System;
using UDIE.Adrupilot.Dataflash.Structure.Helpers;

namespace UDIE.Adrupilot.Dataflash.Structure
{
    public static class Parser
    {
        private const byte FormatMessageType = 0x80;
        private const byte EndOfMessageMarker = 0xFF;
        private const byte BeginningMarker = 0x00;

        public static Dataflash ParseDataflash(Stream stream)
        {
            var fmtMessages = new List<FMT>();
            var messages = new List<dynamic>();
            while (stream.Position < stream.Length)
            {
                var firstHeaderByte = stream.ReadByte();
                var secondHeaderByte = stream.ReadByte();
                if (firstHeaderByte != 163 || secondHeaderByte != 149)
                {
                    stream.Position -= 1;
                    continue;
                }
                
                var messageType = (byte)stream.ReadByte();
                
                switch (messageType)
                {
                    case FormatMessageType:
                        fmtMessages.Add(stream.ReadFmtMessage());
                        break;
                    case BeginningMarker:
                        break;
                    case EndOfMessageMarker:
                        break;
                    default:
                        messages.Add(stream.ReadDataMessage(messageType, fmtMessages));
                        break;
                }
            }

            return new Dataflash { FormatMessages = fmtMessages, Messages = messages };
        }

        private static FMT ReadFmtMessage(this Stream stream)
        {
            var fmtBody = new byte[86];
            stream.Read(fmtBody, 0, 86);
            return ParsingHelpers.ParseMessage<FMT>(fmtBody);
        }
        
        private static dynamic ReadDataMessage(this Stream reader, byte messageType, IEnumerable<FMT> formatMessages)
        {
            var formatMessage = formatMessages.First(fmt => fmt.Type == messageType);
            var dataMessageBytes = new byte[formatMessage.Length - 3];
            var read = reader.Read(dataMessageBytes, 0, formatMessage.Length - 3);
            var dataMessage = ParsingHelpers.ByteArrayToStructure(messageType, dataMessageBytes);
            return dataMessage;
        }
    }
}