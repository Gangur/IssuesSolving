using BenchmarkDotNet.Attributes;
using IssuesSolving.DynamicProgramming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSolving
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        [Benchmark]
        public void Run() {
            WordBreakProblem.IsStringBreakTabulation("catsandogsareanimalscatsandogsareanimalscatsandogsareanimalscatsandogsareanimalscatsandogsareanimalscatsandogsareanimals",
                new string[] { "cats", "dog", "sand", "and", "cat", "mals", "san", "dogs", "are", "animal", "ani", "og", "sar" });
        }
    }
}
