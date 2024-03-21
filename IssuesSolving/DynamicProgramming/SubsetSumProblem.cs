using IssuesSolving.Matrices.Structure;

namespace IssuesSolving.DynamicProgramming
{
    public static class SubsetSumProblem
    {
        public static int FindMaxSumSubsetsTabulation(int[] arr, int k)
        {
            int n = arr.Length;
            int[,] dpMap = new int[n, k + 1];
            if (k > arr.Sum() || n == 0)
                return 0;

            dpMap[0, 0] = 1;
            if (arr[0] <= k)
                dpMap[0, arr[0]] = 1;

            for (int i = 1; i < n; i++)
                for (int j = 0; j < k + 1; j++)
                {
                    dpMap[i, j] = dpMap[i - 1, j] +
                        (j - arr[i] >= 0 ? dpMap[i - 1, j - arr[i]] : 0);
                }

            dpMap.Print();

            return dpMap[n - 1, k];
        }

        public static int FindMaxSumSubsetsMemoization(int[] arr, int k)
            => findMaxSumSubsetsMemoization(arr, k, 0, new Dictionary<string, int>());

        private static int findMaxSumSubsetsMemoization(int[] arr, int k, int i, Dictionary<string, int> lookup)
        {
            var key = i + "-" + k;
            if (lookup.ContainsKey(key))
                return lookup[key];

            if (k == 0)
                return 1;
            else if (i == arr.Length)
                return 0;
            else
            {
                lookup[key] = findMaxSumSubsetsMemoization(arr, k, i + 1, lookup) +
                              findMaxSumSubsetsMemoization(arr, k - arr[i], i + 1, lookup);
                return lookup[key];
            }
        }
    }
}
