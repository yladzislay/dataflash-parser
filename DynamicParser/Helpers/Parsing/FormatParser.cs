using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Parser.Helpers.Parsing
{
    public static class FormatParser
    {
        public static IDictionary<string, object> FormatMessage(byte[] message, string[] messageColumns, string messageFormats, string messageName)
        {
            var result = new ExpandoObject() as IDictionary<string, object>;
            
            var messageFormatsArray = messageFormats.ToCharArray();
            var offset = 0;

            try
            {
                for(var i = 0; i < messageFormatsArray.Length; i++)
                {
                    switch (messageFormatsArray[i])
                    {
                        case 'b':
                            result.Add(messageColumns[i],(sbyte) message[offset]);
                            offset++;
                            break;
                        case 'B':
                            result.Add(messageColumns[i], message[offset]);
                            offset++;
                            break;
                        case 'h':
                            result.Add(messageColumns[i], BitConverter.ToInt16(message, offset));
                            offset += 2;
                            break;
                        case 'H':
                            result.Add(messageColumns[i], BitConverter.ToUInt16(message, offset));
                            offset += 2;
                            break;
                        case 'i':
                            result.Add(messageColumns[i], BitConverter.ToInt32(message, offset));
                            offset += 4;
                            break;
                        case 'I':
                            result.Add(messageColumns[i], BitConverter.ToUInt32(message, offset));
                            offset += 4;
                            break;
                        case 'q':
                            result.Add(messageColumns[i], BitConverter.ToInt64(message, offset));
                            offset += 8;
                            break;
                        case 'Q':
                            result.Add(messageColumns[i], BitConverter.ToUInt64(message, offset));
                            offset += 8;
                            break;
                        case 'f':
                            result.Add(messageColumns[i], BitConverter.ToSingle(message, offset));
                            offset += 4;
                            break;
                        case 'd':
                            result.Add(messageColumns[i], BitConverter.ToDouble(message, offset));
                            offset += 8;
                            break;
                        case 'c':
                            result.Add(messageColumns[i], BitConverter.ToInt16(message, offset) / 100.0);
                            offset += 2;
                            break;
                        case 'C':
                            result.Add(messageColumns[i], BitConverter.ToUInt16(message, offset) / 100.0);
                            offset += 2;
                            break;
                        case 'e':
                            result.Add(messageColumns[i], BitConverter.ToInt32(message, offset) / 100.0);
                            offset += 4;
                            break;
                        case 'E':
                            result.Add(messageColumns[i], BitConverter.ToUInt32(message, offset) / 100.0);
                            offset += 4;
                            break;
                        case 'L':
                            result.Add(messageColumns[i], BitConverter.ToInt32(message, offset) / 10000000.0);
                            offset += 4;
                            break;
                        case 'n':
                            result.Add(messageColumns[i], Encoding.ASCII.GetString(message, offset, 4).Trim(new[] {'\0'}));
                            offset += 4;
                            break;
                        case 'N':
                            result.Add(messageColumns[i], Encoding.ASCII.GetString(message, offset, 16).Trim(new[] {'\0'}));
                            offset += 16;
                            break;
                        case 'M':
                            int modeno = message[offset];
                            var mode = modeno.ToString();
                            result.Add(messageColumns[i], mode);
                            offset++;
                            break;
                        case 'Z':
                            result.Add(messageColumns[i], Encoding.ASCII.GetString(message, offset, 64).Trim(new[] {'\0'}));
                            offset += 64;
                            break;
                        case 'a':
                            result.Add(messageColumns[i], new UnionArrayStruct(message.Skip(offset).Take(64).ToArray()));
                            offset += 2 * 32;
                            break;
                        default:
                            return null;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Log_Parsing_Exception: When Formatting [{messageName}] message group.");
                return result;
            }
            
            return result;
        }
    }
}
