using BenchmarkDotNet.Running;
using IssuesSolving;
using IssuesSolving.DynamicProgramming;
using IssuesSolving.LinkedLists.Structure;
using System.Collections.Generic;

public static class Program
{

    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<Benchmark>();
        //Console.WriteLine(WaysToClimbProblem.FindMemoization(12000, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
    }
}