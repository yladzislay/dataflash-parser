using System.Collections.Generic;
using UDIE.Adrupilot.Dataflash.Dynamic.Helpers.MessagesTransforming;

namespace UDIE.Adrupilot.Dataflash.Dynamic;

public class Dataflash
{
    public Dictionary<byte, dynamic> FormatMessages { get; }
    public Dictionary<string, List<dynamic>> Messages { get; }

    public Dataflash(Dictionary<byte, dynamic> formatMessages, Dictionary<string, List<dynamic>> messages)
    {
        FormatMessages = formatMessages;
        Messages = messages;
        MessagesTransformingHelper.ReGroupByInstances(FormatMessages, Messages);
        CheckGpsMessagesForBadRecords();
    }

    private void CheckGpsMessagesForBadRecords()
    {
        if (Messages.TryGetValue("GPS", out var gpsMessages)) 
            gpsMessages.RemoveAll(message => message.Lat == 0 && message.Lng == 0);
    }
}