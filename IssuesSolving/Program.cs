using BenchmarkDotNet.Running;
using IssuesSolving.Benchmarks;

public static class Program
{
    //var summary = BenchmarkRunner.Run<Benchmark>();

    static async Task Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<BenchmarkSelectVsConvertAll>();
    }
}