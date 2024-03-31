using BenchmarkDotNet.Attributes;
using IssuesSolving.DynamicProgramming;

namespace IssuesSolving
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        private readonly int _n = 5000;
        private readonly int[] _jumps = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        [Benchmark]
        public void FindMemoization()
        {
            WaysToClimbProblem.FindMemoization(_n, _jumps);
        }

        [Benchmark]
        public void FindTabulation() {
            WaysToClimbProblem.FindTabulation(_n, _jumps);
        }
    }
}
