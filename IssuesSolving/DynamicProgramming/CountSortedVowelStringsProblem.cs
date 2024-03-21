using BenchmarkDotNet.Attributes;
using IssuesSolving.Matrices.Structure;

namespace IssuesSolving.DynamicProgramming
{
    [MemoryDiagnoser]
    public static class CountSortedVowelStringsProblem
    {
        [Benchmark]
        public static int CountMath(int n)
        {
            int result = (n + 4) * (n + 3) * (n + 2) * (n + 1) / (1 * 2 * 3 * 4);

            return result;
        }

        [Benchmark]
        public static int CountMemoization(int n)
            => countMemoization(n, 0, new Dictionary<string, int>());

        private static int countMemoization(int n, int i, Dictionary<string, int> lookup)
        {
            string key = n + "-" + i;

            if (lookup.ContainsKey(key))
                return lookup[key];

            if (n == 0)
                return 1;
            else
            {
                int sum = 0;
                for (int j = i; j < 5; j++)
                    sum += countMemoization(n - 1, j, lookup);

                lookup[key] = sum;
                return sum;
            }
        }

        [Benchmark]
        public static int CountTabulation(int n)
        {
            int vowels = 5;
            var dpMap = new int[n, vowels];

            for (int j = 0; j < vowels; j++)
                dpMap[0, j] = 1;

            int sum = 0;
            for (int i = 1; i < n; i++)
            {
                sum = 0;
                for (int j = 0; j < vowels; j++)
                    sum += dpMap[i - 1, j];
                dpMap[i, 0] = sum;

                for (int j = 1; j < vowels; j++)
                    dpMap[i, j] = dpMap[i, j - 1] - dpMap[i - 1, j - 1];
            }

            dpMap.Print();

            sum = 0;
            for (int j = 0; j < vowels; j++)
                sum += dpMap[n - 1, j];

            return sum;
        }
    }
}
