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

    public Dictionary<string, dynamic> MessageFormatDictionary { get; }
    public Dictionary<string, List<dynamic>> Messages { get; }
    
    public DataflashParser(Stream stream)
    {
        MessageFormatDictionary = new Dictionary<string, dynamic>();
        Messages = new Dictionary<string, List<dynamic>>();
        ReadAllMessagesFromStream(stream);
        CheckGpsMessagesForBadRecords();
    }

    private void CheckGpsMessagesForBadRecords()
    {
        Messages["GPS"].RemoveAll(message => message.Lat == 0 && message.Lng == 0);
    }

    private void ReadAllMessagesFromStream(Stream stream)
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

        MessageFormatDictionary[formatMessage.Type.ToString()] = formatMessage;
        if (!Messages.ContainsKey(formatMessage.Name)) Messages.Add(formatMessage.Name, new List<dynamic>());
    }

    private void ReadDataMessage(BinaryReader reader, byte messageType)
    {
        var fmt = MessageFormatDictionary[messageType.ToString()];
        var messageLength = fmt.Length - 3;
        var messageData = reader.ReadBytes(messageLength);
        var formattedMessageData = FormatParser.FormatMessage(messageData, fmt.Columns, fmt.Format, fmt.Name);
        Messages[fmt.Name].Add(formattedMessageData);
    }
}