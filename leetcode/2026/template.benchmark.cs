#!/usr/bin/env dotnet run

#:package BenchmarkDotNet@0.15.8
#:property Optimize=true
#:property Configuration=Release
#:property PublishAot=false
#:include utils.cs

using System;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;

class Program
{
    static void Main(string[] args)
    {
        var config = ManualConfig.CreateEmpty()
            .AddJob(Job.Default.WithToolchain(InProcessNoEmitToolchain.Instance))
            .AddColumnProvider(DefaultConfig.Instance.GetColumnProviders().ToArray())
            .AddExporter(BenchmarkDotNet.Exporters.MarkdownExporter.Default)
            .AddLogger(BenchmarkDotNet.Loggers.ConsoleLogger.Default);

        BenchmarkRunner.Run<MyBenchmark>(config);
    }
}

public class MyBenchmark
{
    private const int Iterations = 1000;

    [Benchmark]
    public string StringConcatenation()
    {
        string result = string.Empty;
        for (int i = 0; i < Iterations; i++)
        {
            result += "a";
        }
        return result;
    }

    [Benchmark]
    public string StringBuilderUsage()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < Iterations; i++)
        {
            sb.Append("a");
        }
        return sb.ToString();
    }
}
