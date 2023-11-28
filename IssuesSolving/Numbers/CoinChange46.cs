using System.Drawing;

namespace IssuesSolving.Numbers
{
    public static class CoinChange46
    {
        public static int FindMinSetMemoiz(int amount, int[] coins) // O(nm)
            => findMinSet(amount, coins, new Dictionary<string, int>());

        public static int findMinSet(int amount, int[] coins, Dictionary<string, int> memoiz, int i = 0)
        {
            amount -= coins[i];
            string key = amount + "-" + i;
            if (memoiz.ContainsKey(key))
                return memoiz[key];

            if (amount == 0)
                return 1;
            else if (amount < 0)
                return -1;
            else
            {
                int min = int.MaxValue;
                for (int j = 0; j < coins.Length; j++)
                {
                    int result = findMinSet(amount, coins, memoiz, j);
                    if (result > 0)
                        min = Math.Min(min, result);
                }

                min = min != int.MaxValue ? min + 1 : -1;
                memoiz.Add(key, min);
                return min;
            }
        }
        public static int FindMidDp(int amount, int[] coins) // O(nm)
        {
            int n = amount + 1;
            int[] dpMap = new int[n];
            int maxValue = int.MaxValue - amount;


            for (int i = 0; i < n; i++)
                dpMap[i] = maxValue;
            dpMap[0] = 0;

            for (int i = 1; i < n; i++)
            {
                int minCoins = maxValue;
                for (int j = 0; j < coins.Length;j++)
                {
                    if (i - coins[j] >= 0)
                        minCoins = Math.Min(minCoins, 1 + dpMap[i - coins[j]]);
                }
                dpMap[i] = minCoins;
            }

            return dpMap[amount] == maxValue ? -1 : dpMap[amount];
        }
    }
}
