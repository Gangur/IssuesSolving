using BenchmarkDotNet.Attributes;

namespace IssuesSolving.Benchmarks
{
    public class WhereBenchmark
    {
        string[] fruits = new string[] { "apple", "mango", "papaya", "banana", "guava", "pineapple" };
        private IList<string> longFruitList;

        [GlobalSetup]
        public void Setup()
        {
            Random rnd = new Random();
            int size = 1_000_000;
            longFruitList = new List<string>(size);
            for (int i = 1; i < size; i++)
                longFruitList.Add(GetRandomFruit());

            string GetRandomFruit()
            {
                return fruits[rnd.Next(0, fruits.Length)];
            }
        }


        [Benchmark]
        public void MultipleWhere()
        {
            int count = longFruitList
                .Where(f => f.EndsWith("le"))
                .Where(f => f.Contains("app"))
                .Where(f => f.StartsWith("pine"))
                .Count(); // counting pineapples
        }

        [Benchmark]
        public void MultipleAnd()
        {
            int count = longFruitList
                .Where(f => f.EndsWith("le") && f.Contains("app") && f.StartsWith("pine"))
                .Count(); // counting pineapples
        }
    }
}
