using BenchmarkDotNet.Running;
using IssuesSolving;
using IssuesSolving.Array;
using IssuesSolving.DynamicProgramming;
using IssuesSolving.Graphs;
using IssuesSolving.Graphs.Structure;
using IssuesSolving.LinkedLists;
using IssuesSolving.LinkedLists.Structure;
using IssuesSolving.Matrices;
using IssuesSolving.Matrices.Structure;
using IssuesSolving.Numbers;
using IssuesSolving.Strings;
using IssuesSolving.Trees;
using IssuesSolving.Trees.Structure;
using System.Linq;

public static class Program { 
    public static void Main(string[] args)
    {
        Console.WriteLine(MatrixChainProblem.FindMinCostTabulation(new int[,]
        {
            { 40, 20 }, { 20, 30 }, { 30, 10 }, { 10, 30 }, { 30, 50 }
        }));

        //var summary = BenchmarkRunner.Run<Benchmark>();
    }
}