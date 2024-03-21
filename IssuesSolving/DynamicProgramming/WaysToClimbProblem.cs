using static System.Net.Mime.MediaTypeNames;

namespace IssuesSolving.DynamicProgramming
{
    public static class WaysToClimbProblem
    {
        public static int FindTabulation(int n, int[] jumps)
        {
            Span<int> dpMap = stackalloc int[n + 1];
            dpMap[0] = 1;

            for (int i = 0; i < dpMap.Length; i++)
            {
                for (int j = 0; j < jumps.Length; j++)
                {
                    if (jumps[j] <= i)
                    {
                        dpMap[i] = dpMap[i] + dpMap[i - jumps[j]];
                    }
                }
            }

            return dpMap[n];
        }

        public static int FindMemoization(int n, int[] jumps)
            => findMemoization(n, jumps, new Dictionary<int, int>());

        private static int findMemoization(int n, int[] jumps, Dictionary<int, int> lookup)
        {
            if (lookup.ContainsKey(n))
                return lookup[n];

            if (n == 0)
                return 1;
            else
            {
                int sum = 0;
                for (int i = 0; i < jumps.Length; i++)
                {
                    if (n - jumps[i] >= 0)
                        sum += findMemoization(n - jumps[i], jumps, lookup);
                }
                lookup[n] = sum;

                return sum;
            }
        }
    }
}
