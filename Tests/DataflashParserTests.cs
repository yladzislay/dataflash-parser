using System.Reflection;
using Parser;
using Xunit;

namespace Tests;

public class DataflashParserTests
{
    [Fact]
    public void GetUuid()
    {
        var directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        Assert.NotNull(directoryPath);
        string filePath = Path.Combine(directoryPath, "Logs", "dataflash-sample-1.bin");
        using var file = File.OpenRead(filePath);
        var parsedLog = new DataflashParser(file);
        var logExtractor = new DataflashExtractor(parsedLog.Messages, parsedLog.MessageFormatDictionary);
        var uuid = logExtractor.GetUuid();
        Assert.Equal("003100193138510E35363631", uuid);
    }
}