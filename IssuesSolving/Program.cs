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

public static class Program
{
    //var summary = BenchmarkRunner.Run<Benchmark>();
    public static void Main(string[] args)
    {
        TreeBreadthFirstSearch14.Print(Tree.CreateBinaryTree());
    }
} 