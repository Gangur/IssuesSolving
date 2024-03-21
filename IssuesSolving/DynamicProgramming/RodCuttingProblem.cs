using IssuesSolving.Matrices.Structure;

namespace IssuesSolving.DynamicProgramming
{
    public static class RodCuttingProblem
    {
        public static int FindMaxProfitTabulation(int n, int[] prices)
        {
            int[] dpMap = new int[n + 1];

            for (int i = 1; i < dpMap.Length; i++)
            {
                for (int j = 1; j < i + 1; j++)
                    dpMap[i] = Math.Max(dpMap[i],
                        prices[j] + dpMap[i - j]);
            }

            dpMap.Print();
            return dpMap[n];
        }

        public static int FindMaxProfitMemoization(int n, int[] prices)
            => findMaxProfit(n, prices, 1, new Dictionary<int, int>());

        private static int findMaxProfit(int n, int[] prices, int i, Dictionary<int, int> lookup)
        {
            if (lookup.ContainsKey(n))
                return lookup[n];

            if (n == 0 || i == prices.Length)
                return 0;
            else
            {
                if (i <= n)
                {
                    lookup[n] = new int[]
                    {
                        findMaxProfit(n - i, prices, i, lookup) + prices[i],
                        findMaxProfit(n - i, prices, i + 1, lookup) + prices[i],
                        findMaxProfit(n, prices, i + 1, lookup)
                    }.Max();
                    return lookup[n];
                }
                else
                    return 0;
            }
        }
    }
}
