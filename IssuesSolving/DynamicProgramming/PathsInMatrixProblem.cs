namespace IssuesSolving.DynamicProgramming
{
    public static class PathsInMatrixProblem
    {
        public static int FindShortestPathTabulation(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            var dpMap = new int[n, m];

            dpMap[0, 0] = 1;

            for (int i = 1; i < n; i++)
                dpMap[i, 0] = matrix[i, 0] == 1 ? 0 : dpMap[i - 1, 0];

            for (int j = 1; j < m; j++)
                dpMap[0, j] = matrix[0, j] == 1 ? 0 : dpMap[0, j - 1];

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] == 1)
                        dpMap[i, j] = 0;
                    else
                        dpMap[i, j] = dpMap[i - 1, j] + dpMap[i, j - 1];
                }
            }

            return dpMap[n - 1, m - 1];
        }

        public static int FindShortestPathMemoization(int[,] matrix)
            => findShortestPathTabulation(matrix, 0, 0, new Dictionary<string, int>());

        private static int findShortestPathTabulation(int[,] matrix, int i, int j, Dictionary<string, int> lookup)
        {
            string key = i + "-" + j;

            if (lookup.ContainsKey(key))
                return lookup[key];

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (i == n || j == m || matrix[i, j] == 1)
                return 0;
            else if (i == n - 1 || j == m - 1)
                return 1;
            else
            {
                lookup[key] = findShortestPathTabulation(matrix, i + 1, j, lookup) +
                    findShortestPathTabulation(matrix, i, j + 1, lookup);

                return lookup[key];
            }
        }
    }
}
