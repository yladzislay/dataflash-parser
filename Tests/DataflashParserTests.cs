using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Parser;
using Xunit;

namespace Tests;

public class DataflashParserTests
{
    [Fact]
    public void Benchmark()
    {
        BenchmarkRunner.Run<DataflashParserTests>(
            ManualConfig.Create(DefaultConfig.Instance)
                .AddJob(Job.Default.WithGcServer(true).WithGcConcurrent(true))
                .AddDiagnoser(MemoryDiagnoser.Default));
    }
    
    [Fact]
    [Benchmark]
    public void GetUuid()
    {
        var directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        Assert.NotNull(directoryPath);
        var filePath = Path.Combine(directoryPath, "Logs", "dataflash-sample-1.bin");
        using var file = File.OpenRead(filePath);
        var dataflash = DataflashParser.ParseDataflash(file);
        var logExtractor = new DataflashExtractor(dataflash.Messages, dataflash.FormatMessages);
        var uuid = logExtractor.ExtractUuid();
        Assert.Equal("003100193138510E35363631", uuid);
    }
}