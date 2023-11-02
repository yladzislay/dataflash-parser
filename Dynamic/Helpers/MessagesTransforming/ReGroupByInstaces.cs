using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UDIE.Adrupilot.Dataflash.Dynamic.Helpers.MessagesTransforming;

public partial class MessagesTransformingHelper
{
    public static void ReGroupByInstances(
        Dictionary<byte, dynamic> formatMessages, 
        Dictionary<string, List<dynamic>> messagesGroups)
    {
        var copy = messagesGroups.Where(group => group.Value.Count != 0).ToList();
        foreach (var messagesGroup in copy)
        {
            switch (messagesGroup.Key)
            {
                case "HEAT":
                case "PIDA":
                case "PIDP":
                case "PIDR":
                case "PIDY":
                case "PIDE":
                case "PIDN":
                case var thisKey when new Regex(@"^PID[0-9]+$").IsMatch(thisKey):
                    break;

                case "RFND":
                {
                    const string instanceFieldName = "Instance";
                    var messageGroupElement = messagesGroup.Value.First();
                    if (!((IDictionary<string, object>) messageGroupElement).ContainsKey(instanceFieldName)) break;

                    var instances = messagesGroup.Value.Select(x => x.Instance).Distinct().ToList();
                    if (instances.Count == 0) break;

                    foreach (var instanceNumber in instances)
                    {
                        var newGroupKey = messagesGroup.Key + "[" + instanceNumber.ToString() + "]";
                        var newGroupValue = messagesGroup.Value.Where(b => b.Instance == instanceNumber)
                            .ToList();

                        var newFormatDictionaryValue =
                            formatMessages.Values
                                .Where(x => x.Name == messagesGroup.Key)
                                .Select(x => new {x.Type, Name = newGroupKey, x.Format, x.Columns})
                                .First();

                        formatMessages.Add(newGroupKey.ToString(), newFormatDictionaryValue);
                        messagesGroups.Add(newGroupKey, newGroupValue);
                    }

                    messagesGroups.Remove(messagesGroup.Key);
                    break;
                }

                case "VIBE":
                {
                    const string instanceFieldName = "IMU";
                    var messageGroupElement = messagesGroup.Value.First();
                    if (!((IDictionary<string, object>) messageGroupElement).ContainsKey(instanceFieldName)) break;

                    var instances = messagesGroup.Value.Select(x => x.IMU).Distinct().ToList();
                    var instancesCount = instances.Count;
                    if (instancesCount == 0) break;

                    foreach (var instanceNumber in instances)
                    {
                        var newGroupKey = messagesGroup.Key + "[" + instanceNumber.ToString() + "]";
                        var newGroupValue = messagesGroup.Value.Where(b => b.IMU == instanceNumber).ToList();

                        var newFormatDictionaryValue =
                            formatMessages.Values
                                .Where(x => x.Name == messagesGroup.Key)
                                .Select(x => new {x.Type, Name = newGroupKey, x.Format, x.Columns})
                                .First();

                        formatMessages.Add(newGroupKey.ToString(), newFormatDictionaryValue);
                        messagesGroups.Add(newGroupKey, newGroupValue);
                    }

                    messagesGroups.Remove(messagesGroup.Key);
                    break;
                }

                case var thisKey when new Regex(@"^XK\w+").IsMatch(thisKey):
                {
                    const string instanceFieldName = "C";
                    var messageGroupElement = messagesGroup.Value.First();
                    if (!((IDictionary<string, object>) messageGroupElement).ContainsKey(instanceFieldName)) break;

                    var instances = messagesGroup.Value.Select(x => x.C).Distinct().ToList();
                    if (instances.Count == 0) break;

                    foreach (var instanceNumber in instances)
                    {
                        var newGroupKey = messagesGroup.Key + "[" + instanceNumber.ToString() + "]";
                        var newGroupValue =
                            messagesGroup.Value
                                .Where(b => b.C == instanceNumber)
                                .ToList();

                        var newFormatDictionaryValue =
                            formatMessages.Values
                                .Where(x => x.Name == messagesGroup.Key)
                                .Select(x => new {x.Type, Name = newGroupKey, x.Format, x.Columns})
                                .First();

                        formatMessages.Add(newGroupKey, newFormatDictionaryValue);
                        messagesGroups.Add(newGroupKey, newGroupValue);
                    }

                    messagesGroups.Remove(messagesGroup.Key);
                    break;
                }

                default:
                {
                    const string instanceFieldName = "I";
                    var messageGroupElement = messagesGroup.Value.First();
                    if (!((IDictionary<string, object>) messageGroupElement).ContainsKey(instanceFieldName)) break;

                    var instances = messagesGroup.Value.Select(x => x.I).Distinct().ToList();
                    if (instances.Count == 0) break;

                    foreach (var instanceNumber in instances)
                    {
                        var newGroupKey = messagesGroup.Key + "[" + instanceNumber.ToString() + "]";
                        var newGroupValue =
                            messagesGroup.Value
                                .Where(b => b.I == instanceNumber)
                                .ToList();

                        var newFormatDictionaryValue =
                            formatMessages.Values
                                .Where(x => x.Name == messagesGroup.Key)
                                .Select(x => new {x.Type, Name = newGroupKey, x.Format, x.Columns})
                                .First();

                        formatMessages.Add(newGroupKey, newFormatDictionaryValue);
                        messagesGroups.Add(newGroupKey, newGroupValue);
                    }

                    messagesGroups.Remove(messagesGroup.Key);
                    break;
                }
            }
        }
    }
}