using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DataflashParser.Helpers;
using DataflashParser.Helpers.Parsing;

namespace DataflashParser
{
    public class DataflashExtractor
    {
        public Dictionary<string, List<dynamic>> _messages;
        public Dictionary<string, dynamic> _messageFormatDictionary;
        public Dictionary<string, Dictionary<string, IEnumerable<object>>> AllMessages2;

        public DataflashExtractor(Dictionary<string, List<dynamic>> messages, Dictionary<string, dynamic> messageFormatDictionary)
        {
            _messages = messages;
            _messageFormatDictionary = messageFormatDictionary;
            
            ReGroupByInstances();
            
            AllMessages2 = new Dictionary<string, Dictionary<string, IEnumerable<object>>>();
            CalculateAllMessages2();
        }

        private void ReGroupByInstances()
        {
            // How do you define groups with Instances ?
            // How it's define in JavaScript ? 
            // Instances always has byte type. 
            // if "Group" has "Instance" field. (C# Reflection).

            // 	var instancesCount =   Instance.Distinct.Count(); // [0,1,2]
            // 	Create new groups with Name "Group + InstanceId"
            // 	Fill Each group from Main.
            // 	Remove Main group.

            var copy = _messages.Where(@group => @group.Value.Count != 0).ToList();
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
                                _messageFormatDictionary.Values
                                    .Where(x => x.Name == messagesGroup.Key)
                                    .Select(x => new {x.Type, Name = newGroupKey, x.Format, x.Columns})
                                    .First();
                            
                            _messageFormatDictionary.Add(newGroupKey.ToString(), newFormatDictionaryValue);
                            _messages.Add(newGroupKey, newGroupValue);
                        }

                        _messages.Remove(messagesGroup.Key);
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
                                _messageFormatDictionary.Values
                                    .Where(x => x.Name == messagesGroup.Key)
                                    .Select(x => new {x.Type, Name = newGroupKey, x.Format, x.Columns})
                                    .First();
                            
                            _messageFormatDictionary.Add(newGroupKey.ToString(), newFormatDictionaryValue);
                            _messages.Add(newGroupKey, newGroupValue);
                        }
                            
                        _messages.Remove(messagesGroup.Key);
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
                                _messageFormatDictionary.Values
                                    .Where(x => x.Name == messagesGroup.Key)
                                    .Select(x => new {x.Type, Name = newGroupKey, x.Format, x.Columns})
                                    .First();
                            
                            _messageFormatDictionary.Add(newGroupKey, newFormatDictionaryValue);
                            _messages.Add(newGroupKey, newGroupValue);
                        }

                        _messages.Remove(messagesGroup.Key);
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
                                _messageFormatDictionary.Values
                                    .Where(x => x.Name == messagesGroup.Key)
                                    .Select(x => new {x.Type, Name = newGroupKey, x.Format, x.Columns})
                                    .First();
                            
                            _messageFormatDictionary.Add(newGroupKey, newFormatDictionaryValue);
                            _messages.Add(newGroupKey, newGroupValue);
                        }

                        _messages.Remove(messagesGroup.Key);
                        break;
                    }
                }
            }
        }

        private void CalculateAllMessages2()
        {
            foreach (var (key, value) in _messages)
            {
                AllMessages2.Add(key, new Dictionary<string, IEnumerable<object>>());

                var messageTypeColumns = 
                    ((IEnumerable<string>) _messageFormatDictionary.Values
                        .FirstOrDefault(x => x.Name == key)
                        ?.Columns ?? Array.Empty<string>())
                    .Select((x, i) => new { Name = x, Count = 0, Index = i });

                foreach (var item in messageTypeColumns)
                {
                    if (!value.Any() || value.Count < 2) continue;
                    AllMessages2[key].Add(item.Name, value.Select(x => x[item.Index]));
                }
            }
        }

        public IEnumerable<object> QueryMessage(string messageGroupName, string messageGroupColumnName)
        {
            return AllMessages2[messageGroupName][messageGroupColumnName];
        }

        public IEnumerable<dynamic> GetMessagesGroupsAndColumnsInfo()
        {
            var result = new List<dynamic>();

            foreach (var (key, value) in _messages)
                result.Add(new
                {
                    value.Count,
                    Name = key,
                    Items = ((IEnumerable<string>) _messageFormatDictionary.Values.FirstOrDefault(x => x.Name == key)
                        .Columns).Select((x, i) => new
                    {
                        value.Count,
                        Name = x,
                        Index = i
                    }).Where(x => x.Index != 0)
                });

            return result.Where(x => x.Count != 0).OrderBy(x => x.Name);
        }

        public double GetMaxDropRate()
        {
            return (short) _messages["CTUN"].Select(x => x.CRt).Max() / 100.0; // convert from cm/s to m/s.
        }

        public double GetMaxClimbRate()
        {
            return (short) _messages["CTUN"].Select(x => x.CRt).Max() / 100.0; // convert from cm/s to m/s.
        }

        public float GetMaxGroundSpeed()
        {
            return (float) _messages["GPS"].Select(x => x.Spd).Max();
        }

        public double GetMinGpsAltitude()
        {
            return (double) _messages["GPS"].Select(x => x.Alt).Min();
        }

        public double GetMaxGpsAltitude()
        {
            return (double) _messages["GPS"].Select(x => x.Alt).Max();
        }

        public uint GetTotalVibrationClips()
        {
            return _messages["VIBE"].Select(x => x.Clip0).Cast<uint>().Last() +
                   _messages["VIBE"].Select(x => x.Clip1).Cast<uint>().Last() +
                   _messages["VIBE"].Select(x => x.Clip2).Cast<uint>().Last();
        }

        public double GetGpsFlightDistance()
        {
            if(!_messages.ContainsKey("GPS") && !_messages.ContainsKey("GPS[0]")) return 0;
           
            var key = _messages.ContainsKey("GPS") ? "GPS" 
                : _messages.ContainsKey("GPS[0]") ? "GPS[0]" : string.Empty;
            
            var gpsLatitudePoints = _messages[key].Select(x => x.Lat).Cast<double>().ToArray();
            var gpsLongitudePoints = _messages[key].Select(x => x.Lng).Cast<double>().ToArray();

            return CalculationHelper.GetDistance(gpsLatitudePoints, gpsLongitudePoints);
        }

        public double GetMaxDistanceFromStartPoint()
        {
            if(!_messages.ContainsKey("GPS") && !_messages.ContainsKey("GPS[0]")) return 0;
            var key = _messages.ContainsKey("GPS") ? "GPS" 
                : _messages.ContainsKey("GPS[0]") ? "GPS[0]" : string.Empty;
            
            var gpsLatitudePoints = _messages[key].Select(x => x.Lat).Cast<double>().ToArray();
            var gpsLongitudePoints = _messages[key].Select(x => x.Lng).Cast<double>().ToArray();

            return CalculationHelper.GetMaxDistanceFromStartPoint(gpsLatitudePoints, gpsLongitudePoints);
        }

        public dynamic GetGpsDataSetByTimeCode(ulong inputTimeUs)
        {
            if(!_messages.ContainsKey("GPS") && !_messages.ContainsKey("GPS[0]")) return null;
            var key = _messages.ContainsKey("GPS") ? "GPS" 
                : _messages.ContainsKey("GPS[0]") ? "GPS[0]" : string.Empty;
            
            var result = _messages[key].First(x => (ulong) x.TimeUS == inputTimeUs);
            return result;
        }

        public double GetTotalClimb() => CalculationHelper.CalculateTotalClimb(_messages["NKF5"].Select(x => x.HAGL).Cast<double>());

        public string GetUuid()
        {
            var regex = new Regex(@" \w{8} \w{8} \w{8}$");
            var uuid = (string)_messages["MSG"].Select(x => x.Message).FirstOrDefault(y => regex.IsMatch(y));
            return string.Concat(uuid.Split(new[] {' '}).Skip(1).ToArray());
        }

        public string GetFirmware()
        {
            var regex = new Regex(@"^(ArduCopter|ArduPlane)");
            var firmware = (string)_messages["MSG"].Select(x => x.Message).FirstOrDefault(y => regex.IsMatch(y));
            return firmware;
        }

        public DateTime? GetFlightStartDate()
        {
            if(!_messages.ContainsKey("GPS") && !_messages.ContainsKey("GPS[0]")) return null;
            var key = _messages.ContainsKey("GPS") ? "GPS" 
                : _messages.ContainsKey("GPS[0]") ? "GPS[0]" : string.Empty;
            
            var firstGpsMessage = _messages[key].FirstOrDefault();
            
            var gpsWeek = (ushort) firstGpsMessage.GWk;
            var gpsSec = (uint) firstGpsMessage.GMS;

            var firstGpsDateTime = GpsTimeParser.GpsTimeToDateTime(gpsWeek, gpsSec);
            // var firstGpsMessageTimeUs = new TimeSpan(0, 0, 0, 0, (int) ((ulong) firstGpsMessage.TimeUS / 1000));
            // var flightStartDate = gpsDateTime.Subtract(firstGpsMessageTimeUs);

            return firstGpsDateTime;
        }

        public TimeSpan? GetLoggingDuration()
        {
            if(!_messages.ContainsKey("GPS") && !_messages.ContainsKey("GPS[0]")) return null;
            var key = _messages.ContainsKey("GPS") ? "GPS" 
                    : _messages.ContainsKey("GPS[0]") ? "GPS[0]" : string.Empty;
            
            var firstGpsGwk = (ushort) _messages[key].Select(x => x.GWk).First();
            var firstGpsGms = (uint) _messages[key].Select(x => x.GMS).First();

            var lastGpsGwk = (ushort) _messages[key].Select(x => x.GWk).Last();
            var lastGpsGms = (uint) _messages[key].Select(x => x.GMS).Last();

            var startDate = GpsTimeParser.GpsTimeToDateTime(firstGpsGwk, firstGpsGms);
            var lastDate = GpsTimeParser.GpsTimeToDateTime(lastGpsGwk, lastGpsGms);

            var result = lastDate.Subtract(startDate);

            return new TimeSpan(result.Days, result.Hours, result.Minutes, result.Seconds);
        }

        public IEnumerable<DateTime> GetTimeLine(IEnumerable<ulong> timeline)
        {
            if(!_messages.ContainsKey("GPS") && !_messages.ContainsKey("GPS[0]")) return null;
            var key = _messages.ContainsKey("GPS") ? "GPS" 
                : _messages.ContainsKey("GPS[0]") ? "GPS[0]" : string.Empty;
            
            var result = new List<DateTime>();
            var firstGpsMessage = _messages[key].First();
            var firstGpsTime = GpsTimeParser.GpsTimeToDateTime(int.Parse(firstGpsMessage.GWk.ToString()),
                long.Parse(firstGpsMessage.GMS.ToString()) / 1000.0);

            foreach (var time in timeline)
            {
                var difftimems = ((long) time - (long) (ulong) firstGpsMessage.TimeUS) / 1000;
                var difftime = firstGpsTime.AddMilliseconds(difftimems);
                result.Add(difftime);
            }

            return result;
        }
    }
}