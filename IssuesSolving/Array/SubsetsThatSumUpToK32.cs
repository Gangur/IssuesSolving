namespace IssuesSolving.Array
{
    public static class SubsetsThatSumUpToK32
    {
        public static int Count(int[] arr, int k) // O(nk)
            => subsetsThatSumUpToK(arr, k, new Dictionary<string, int>());

        private static int subsetsThatSumUpToK(int[] arr, int k, Dictionary<string, int> memoiz, int i = 0, int sum = 0)
        {
            var key = i + "_" + sum;
            if (memoiz.TryGetValue(key, out var value))
                return value;
            else if (sum == k)
                return 1;
            else if (sum > k || i >= arr.Length)
                return 0;
            else
            {
                var result = subsetsThatSumUpToK(arr, k, memoiz, i + 1, sum + arr[i]) +
                        subsetsThatSumUpToK(arr, k, memoiz, i + 1, sum);
                memoiz[key] = result;
                return result;
            }
        }
    }
}
