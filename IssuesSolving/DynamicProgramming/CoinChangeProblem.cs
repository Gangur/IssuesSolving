using IssuesSolving.Matrices.Structure;

namespace IssuesSolving.DynamicProgramming
{
    public static class CoinChangeProblem
    {
        public static int FindTheMinimumCoinsTabulation(int amount, int[] possibleCoins)
        {
            Span<int> dpMap = stackalloc int[amount + 1];
            dpMap[0] = 1;

            for (int i = 1; i < dpMap.Length; i++)
                dpMap[i] = int.MaxValue;

            for (int i = 1; i < dpMap.Length; i++)
            {
                for (int j = 0; j < possibleCoins.Length; j++)
                {
                    if (possibleCoins[j] <= i && dpMap[i - possibleCoins[j]] != int.MaxValue)
                    {
                        dpMap[i] = Math.Min(dpMap[i], dpMap[i - possibleCoins[j]] + 1);
                    }
                }
            }

            dpMap.Print();
            return dpMap[amount] == int.MaxValue ? -1 : dpMap[amount] - 1;
        }

        public static int FindTheMinimumCoinsMemoization(int amount, int[] possibleCoins)
        {
            int result = findTheMinimumCoinsMemoization(amount, possibleCoins, new Dictionary<int, int>());
            return result == int.MaxValue ? -1 : result;
        }

        public static int findTheMinimumCoinsMemoization(int amount, int[] possibleCoins, Dictionary<int, int> lookup)
        {
            if (lookup.ContainsKey(amount))
                return lookup[amount];

            if (amount == 0)
                return 0;
            else
            {
                int minCoins = int.MaxValue;
                for (int j = 0; j < possibleCoins.Length; j++)
                {
                    if (amount - possibleCoins[j] >= 0)
                    {
                        int minCoinsLocal = findTheMinimumCoinsMemoization(amount - possibleCoins[j], possibleCoins, lookup);

                        if (minCoinsLocal != int.MaxValue)
                            minCoins = Math.Min(minCoins, minCoinsLocal + 1);
                    }
                }

                lookup[amount] = minCoins;
                return lookup[amount];
            }
        }
    }
}
