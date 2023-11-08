using System.Collections.Generic;
using System.Linq;

namespace UDIE.Adrupilot.Dataflash.Dynamic.Helpers.Extracting
{
    public static class InterfaceComponentsDataQueries
    {

        public static IEnumerable<dynamic> GetMessagesGroupsAndColumnsInfo(this Dataflash dataflash)
        {
            return dataflash.Messages
                .Where(kv => kv.Value.Any())
                .OrderBy(kv => kv.Key)
                .Select(kv => new
                {
                    Name = kv.Key,
                    Count = kv.Value.Count,
                    Items = ((IEnumerable<string>)dataflash.FormatMessages.Values.First(fmt => fmt.Name == kv.Key).Columns)
                        .Select((column, index) => new
                        {
                            Name = column,
                            Index = index
                        })
                        .ToArray()
                });
        }
    }
}