using System;
using System.Collections.Generic;
using System.Linq;

namespace Parser.Helpers.Extracting
{
    public static class MessageTransformer
    {
        public static Dictionary<string, Dictionary<string, IEnumerable<object>>> TransformMessagesToDoubleDictionaryOld(
            Dictionary<string, List<dynamic>> messages,
            Dictionary<string, dynamic> formatMessages)
        {
            var doubleDictionaryMessages = new Dictionary<string, Dictionary<string, IEnumerable<object>>>();

            foreach (var (key, value) in messages)
            {
                doubleDictionaryMessages.Add(key, new Dictionary<string, IEnumerable<object>>());

                var messageTypeColumns =
                    ((IEnumerable<string>) formatMessages.Values
                        .FirstOrDefault(x => x.Name == key)
                        ?.Columns ?? Array.Empty<string>())
                    .Select((x, i) => new {Name = x, Index = i});

                foreach (var item in messageTypeColumns)
                {
                    if (!value.Any() || value.Count < 2) continue;
                    doubleDictionaryMessages[key].Add(item.Name, value.Select(x => x[item.Index]));
                }
            }

            return doubleDictionaryMessages;
        }
        
        public static dynamic TransformMessagesToDoubleDictionaryNew(
            Dictionary<string, List<dynamic>> messages,
            Dictionary<string, dynamic> formatMessages)
        {
            var transformedMessages = messages
                .ToDictionary(
                    kv => kv.Key,
                    kv => formatMessages[kv.Key].Columns
                        .Select(new Func<dynamic, dynamic>(columnName => new
                        {
                            Name = columnName,
                            Values = kv.Value.Select(value => value[formatMessages[kv.Key].Columns.IndexOf(columnName)])
                        }))
                        .ToDictionary(
                            new Func<dynamic, dynamic>(column => (string)column.Name),
                            new Func<dynamic, dynamic>(column => (IEnumerable<object>)column.Values)));

            return transformedMessages;
        } 
        
        private static Dictionary<string, Dictionary<string, List<object>>> GenerateDoubleKeyMessagesGroups(
            Dictionary<string, List<dynamic>> messages,
            Dictionary<string, dynamic> formatMessages)
        {
            var doubleKeyMessagesGroups = new Dictionary<string, Dictionary<string, List<object>>>();

            foreach (var (messagesGroupName, messagesGroupValues) in messages)
            {
                doubleKeyMessagesGroups.Add(messagesGroupName, new Dictionary<string, List<object>>());
                if (!messagesGroupValues.Any()) continue;

                var formatMessage = formatMessages.Values
                    .First(x => x.Name == messagesGroupName);

                var messageTypeColumns =
                    ((IEnumerable<string>)formatMessage.Columns)
                    .Select((x, i) => new { Name = x, Index = i });

                var typeColumns = messageTypeColumns.ToList();
                foreach (var messageTypeColumn in typeColumns)
                {
                    doubleKeyMessagesGroups[messagesGroupName].Add(messagesGroupName, new List<object>());
                    var columnValue = messagesGroupValues.Select(dict => dict.ElementAtOrDefault(messageTypeColumn.Index));
                    doubleKeyMessagesGroups[messagesGroupName][messageTypeColumn.Name].Add(columnValue);
                }
            }

            return doubleKeyMessagesGroups;
        }
    }
}