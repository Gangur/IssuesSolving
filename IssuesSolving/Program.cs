using BenchmarkDotNet.Running;
using IssuesSolving;
using IssuesSolving.Array;
using IssuesSolving.DynamicProgramming;
using IssuesSolving.LinkedLists;
using IssuesSolving.LinkedLists.Structure;
using IssuesSolving.Matrices.Structure;
using IssuesSolving.Strings;
using IssuesSolving.Trees;
using IssuesSolving.Trees.Structure;
using System.Collections.Generic;
using static System.Collections.Specialized.BitVector32;

public static class Program
{
    //var summary = BenchmarkRunner.Run<Benchmark>();
    public static void Main(string[] args)
    {
        Console.WriteLine(LongestPossiblePalindrome12.Calculate("abdccdceeebebc"));
    }
} 