using IssuesSolving.Array;
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

Console.WriteLine("Coding problems solving");

var tree = Tree.CreateBinaryTree();
var result = CoinChange46.FindMidDp(15, new int[] { 2, 3, 7 });

Console.WriteLine(result);