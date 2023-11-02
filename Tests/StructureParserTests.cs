using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using UDIE.Adrupilot.Dataflash.Structure;
using Xunit;

namespace UDIE.Adrupilot.Dataflash.Tests;

public class StructureParserTests
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
    public void DataflashStructureParserTest()
    {
        var directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        Assert.NotNull(directoryPath);
        var filePath = Path.Combine(directoryPath, "Logs", "dataflash-sample-5.bin");
        using var file = File.OpenRead(filePath);
        var dataflash = Parser.ParseDataflash(file);
        
        Assert.NotNull(dataflash);
        Assert.NotEmpty(dataflash.FormatMessages);
        Assert.NotEmpty(dataflash.Messages);
    }
}