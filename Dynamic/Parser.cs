using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UDIE.Adrupilot.Dataflash.Dynamic.Helpers.Parsing;

namespace UDIE.Adrupilot.Dataflash.Dynamic
{
    public static class Parser
    {
        private const byte FormatMessageType = 0x80;
        private const byte EndOfMessageMarker = 0xFF;

        public static Dataflash ParseDataflash(Stream stream)
        {
            var formatMessages = new Dictionary<byte, dynamic>();
            var messages = new Dictionary<string, List<dynamic>>();
            using var reader = new BinaryReader(stream);
            while (stream.Position < stream.Length)
            {
                var firstHeaderByte = reader.ReadByte();
                var secondHeaderByte = reader.ReadByte();
                var messageType = reader.ReadByte();

                switch (messageType)
                {
                    case FormatMessageType:
                        reader.ReadFormatMessage(formatMessages, messages);
                        break;
                    case EndOfMessageMarker:
                        break;
                    default:
                        reader.ReadDataMessage(messageType, formatMessages, messages);
                        break;
                }
            }

            return new Dataflash(formatMessages, messages);
        }

        private static void ReadFormatMessage(
            this BinaryReader reader,
            Dictionary<byte, dynamic> formatMessages, 
            Dictionary<string, List<dynamic>> messages
            )
        {
            var fmtMessage = reader.ReadBytes(86);
            var formatMessage = new
            {
                Type = fmtMessage[0],
                Length = fmtMessage[1],
                Name = Encoding.ASCII.GetString(fmtMessage, 2, 4).TrimEnd('\0'),
                Format = Encoding.ASCII.GetString(fmtMessage, 6, 16).TrimEnd('\0'),
                Columns = Encoding.ASCII.GetString(fmtMessage, 22, 64).TrimEnd('\0')
                    .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
            };

            formatMessages[formatMessage.Type] = formatMessage;
            if (!messages.ContainsKey(formatMessage.Name)) messages.Add(formatMessage.Name, new List<dynamic>());
        }

        private static void ReadDataMessage(
            this BinaryReader reader,
            byte messageType, 
            Dictionary<byte, dynamic> formatMessages, 
            Dictionary<string, List<dynamic>> messages
            )
        {
            const byte messageHeaderSize = 3;
            var formatMessage = formatMessages[messageType];
            var messageLength = formatMessage.Length - messageHeaderSize;
            var messageData = reader.ReadBytes(messageLength);
            var formattedMessageData = ParsingHelpers
                .MarshallDataMessage(
                    message: messageData,
                    messageColumns: formatMessage.Columns,
                    messageFormats: formatMessage.Format,
                    messageName: formatMessage.Name);

            messages[formatMessage.Name].Add(formattedMessageData);
        }
    }
}