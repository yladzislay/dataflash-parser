using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using UDIE.Adrupilot.Dataflash.Dynamic;
using Xunit;

namespace UDIE.Adrupilot.Dataflash.Tests;

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
        var dataflash = Parser.ParseDataflash(file);
        var uuid = Extractor.ExtractUuid(dataflash.Messages["MSG"]);
        Assert.Equal("003100193138510E35363631", uuid);
    }
    
    [Fact]
    public void CalculationHelpersTests()
    {
        var directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        Assert.NotNull(directoryPath);
        var filePath = Path.Combine(directoryPath, "Logs", "dataflash-sample-5.bin");
        using var file = File.OpenRead(filePath);
        var dataflash = Parser.ParseDataflash(file);
            
        var passedFlightDistance = Extractor.ExtractGpsPassedFlightDistance(dataflash.Messages["GPS"]);
        var maxDistanceFromStartPoint = Extractor.ExtractMaxDistanceFromStartPoint(dataflash.Messages["GPS"]);
        var totalClimb = Extractor.ExtractTotalClimb(Extractor.ExtractAltitudesFromGps(dataflash.Messages["GPS"]));
            
        Assert.NotEqual(0, passedFlightDistance);
        Assert.NotEqual(0, maxDistanceFromStartPoint);
        Assert.NotEqual(0, totalClimb);

    }
}