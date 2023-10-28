using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Parser.Helpers.Parsing;

namespace Parser;

public class DataflashParser
{
    private const byte FormatMessageType = 0x80;
    private const byte EndOfMessageMarker = 0xFF;

    public Dictionary<byte, dynamic> FormatMessages { get; }
    public Dictionary<string, List<dynamic>> Messages { get; }
    
    public DataflashParser(Stream stream)
    {
        FormatMessages = new Dictionary<byte, dynamic>();
        Messages = new Dictionary<string, List<dynamic>>();
        StreamReader(stream);
        CheckGpsMessagesForBadRecords();
    }

    private void CheckGpsMessagesForBadRecords()
    {
        Messages["GPS"].RemoveAll(message => message.Lat == 0 && message.Lng == 0);
    }

    private void StreamReader(Stream stream)
    {
        using var reader = new BinaryReader(stream);
        while (stream.Position < stream.Length)
        {
            var firstHeaderByte = reader.ReadByte();
            var secondHeaderByte = reader.ReadByte();
            var messageType = reader.ReadByte();

            switch (messageType)
            {
                case FormatMessageType:
                    ReadFormatMessage(reader);
                    break;
                case EndOfMessageMarker:
                    break;
                default:
                    ReadDataMessage(reader, messageType);
                    break;
            }
        }
    }

    private void ReadFormatMessage(BinaryReader reader)
    {
        var fmtMessage = reader.ReadBytes(86);
        var formatMessage = new
        {
            Type = fmtMessage[0],
            Length = fmtMessage[1],
            Name = Encoding.ASCII.GetString(fmtMessage, 2, 4).TrimEnd('\0'),
            Format = Encoding.ASCII.GetString(fmtMessage, 6, 16).TrimEnd('\0'),
            Columns = Encoding.ASCII.GetString(fmtMessage, 22, 64).TrimEnd('\0')
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
        };

        FormatMessages[formatMessage.Type] = formatMessage;
        if (!Messages.ContainsKey(formatMessage.Name)) Messages.Add(formatMessage.Name, new List<dynamic>());
    }

    private void ReadDataMessage(BinaryReader reader, byte messageType)
    {
        const byte messageHeaderSize = 3;
        var formatMessage = FormatMessages[messageType];
        var messageLength = formatMessage.Length - messageHeaderSize;
        var messageData = reader.ReadBytes(messageLength);
        var formattedMessageData = ParsingHelpers
            .MarshallDataMessage(
                message:messageData,
                messageColumns:formatMessage.Columns, 
                messageFormats:formatMessage.Format, 
                messageName:formatMessage.Name);
        Messages[formatMessage.Name].Add(formattedMessageData);
    }
}