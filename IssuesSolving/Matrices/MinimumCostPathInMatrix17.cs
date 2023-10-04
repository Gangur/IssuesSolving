namespace IssuesSolving.Matrices
{
    public static class MinimumCostPathInMatrix17
    {
        public static int MinimumCostPathBruteForce(int[][] matrix, int i = 0, int j = 0) // O(2^(n+m))
        {
            int n = matrix.Length;
            int m = matrix[0].Length;

            if (i == n - 1 && j == m - 1)
                return matrix[i][j];
            else if (i == n - 1)
                return matrix[i][j] + MinimumCostPathBruteForce(matrix, i, j + 1);
            else if (j == m - 1)
                return matrix[i][j] + MinimumCostPathBruteForce(matrix, i + 1, j);
            else
                return matrix[i][j] + Math.Min(
                    MinimumCostPathBruteForce(matrix, i, j + 1),
                    MinimumCostPathBruteForce(matrix, i + 1, j));
        }

        public static int MinimumCostPathCostMatrix(int[][] matrix) // O(n*m)
        {
            var n = matrix.Length;
            var m = matrix[0].Length;
            var costs = new int[n, m];

            costs[0,0] = matrix[0][0];

            for (var i = 1; i < m; i++)
                costs[0,i] = costs[0, i - 1] + matrix[0][i];

            for (var i = 1; i < n; i++)
                costs[i, 0] = costs[i - 1, 0] + matrix[i][0];

            for (var i = 1; i < n; i++)
                for (var j = 1; j < m; j++)
                    costs[i, j] = Math.Min(costs[i - 1, j], costs[i, j - 1]) + matrix[i][j];

            return costs[n - 1, m - 1];
        }
    }
}
