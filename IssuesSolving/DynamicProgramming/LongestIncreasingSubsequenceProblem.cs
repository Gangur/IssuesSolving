namespace IssuesSolving.DynamicProgramming
{
    public static class LongestIncreasingSubsequenceProblem
    {
        // 7, 5, 2, 4, 7, 2, 3, 6, 4, 5, 12, 1, 7
        public static int FindTabulation(int[] arr)
        {
            int n = arr.Length;
            int[] dpMap = new int[n];
            dpMap[0] = 1;

            for (int i = 1; i < n; i++)
            {
                int maxlen = 0;

                for (int j = 0; j < i; j++)
                    if (arr[j] < arr[i] && dpMap[j] > maxlen)
                        maxlen = dpMap[j];

                dpMap[i] = 1 + maxlen;
            }
           
            return dpMap.Max();
        }

        public static int FindMemoization(int[] arr)
        {
            if (arr.Length == 0)
                return 0;

            return findMemoization(arr, 0, int.MinValue, new Dictionary<string, int>());
        }

        private static int findMemoization(int[] arr, int i, int previous, Dictionary<string, int> lookup)
        {
            var key = i + "-" + previous;
            if (lookup.ContainsKey(key))
                return lookup[key];

            if (arr.Length == i)
                return 0;
            else if (previous >= arr[i])
            {
                lookup[key] = findMemoization(arr, i + 1, previous, lookup); ;
                return lookup[key];
            }
            else
            {
                lookup[key] = Math.Max(
                    1 + findMemoization(arr, i + 1, arr[i], lookup),
                    findMemoization(arr, i + 1, previous, lookup));

                return lookup[key];
            }
        }
    }
}
