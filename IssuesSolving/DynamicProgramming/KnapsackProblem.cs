using IssuesSolving.Matrices.Structure;

namespace IssuesSolving.DynamicProgramming
{
    public static class KnapsackProblem
    {
        public static int FindMaxCapacityTabulation(int[] values, int[] weights, int k)
        {
            if (k == 0)
                return 0;
            else if (k >= weights.Sum())
                return values.Sum();

            values.Print();
            weights.Print();
            int n = values.Length;
            var dpMap = new int[n, k];

            for (int j = 0; j < k; j++)
                if (j >= weights[0])
                    dpMap[0, j] = values[0];

            for (int i = 1; i < n; i++)
                for (int j = 0; j < k; j++)
                {
                    if (weights[i] > j)
                        dpMap[i, j] = dpMap[i - 1, j];
                    else
                        dpMap[i, j] = Math.Max(values[i] + dpMap[i - 1, j - weights[i]], dpMap[i - 1, j]);
                }

            dpMap.Print();

            return dpMap[n - 1, k - 1];
        }

        public static int FindMaxCapacityMemoizetion(int[] values, int[] weights, int k)
            => findMaxCapacityMemoizetion(values, weights, k, 0, new Dictionary<string, int>());

        private static int findMaxCapacityMemoizetion(int[] values, int[] weights, int k, int i, Dictionary<string, int> lookup)
        {
            string key = i + "-" + k;

            if (lookup.ContainsKey(key)) 
                return lookup[key];

            if (i == values.Length)
                return 0;
            if (k < weights[i])
            {
                lookup[key] = findMaxCapacityMemoizetion(values, weights, k, i + 1, lookup);
                return lookup[key];
            }
            else
            {
                lookup[key] = Math.Max(values[i] + findMaxCapacityMemoizetion(values, weights, k - weights[i], i + 1, lookup),
                    findMaxCapacityMemoizetion(values, weights, k, i + 1, lookup));
                return lookup[key];
            }
        }
    }
}
