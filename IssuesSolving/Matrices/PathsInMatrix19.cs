namespace IssuesSolving.Matrices
{
    public static class PathsInMatrix19
    {
        public static int CountPathsInMatrixBruteForce(int[][] matrix, int i = 0, int j = 0) // O(2^(n+m))
        {
            int n = matrix.Length;
            int m = matrix[0].Length;

            if (i > n - 1 || j > m - 1 || matrix[i][j] == 1)
                return 0;
            else if (i == n - 1 && j == m - 1)
                return 1;
            else
                return  CountPathsInMatrixBruteForce(matrix, i + 1, j) +
                        CountPathsInMatrixBruteForce(matrix, i, j + 1);

        }

        public static int CountPathsInMatrixDp(int[][] matrix) // O(n*m)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;
            int[,] dp = new int[n, m];
            if (matrix[0][0] == 1) dp[0, 0] = 0;
            else dp[0, 0] = 1;

            for (int i = 1; i < m; i++)
                if (matrix[0][i] == 1) dp[0, i] = 0;
                else dp[0, i] = dp[0, i - 1];

            for (int i = 1; i < n; i++)
                if (matrix[i][0] == 1) dp[i, 0] = 0;
                else dp[i, 0] = dp[i - 1, 0];

            for (int i = 1; i < n; i++)
                for (int j = 1; j < m; j++)
                    if (matrix[i][j] == 1) dp[i, j] = 0;
                    else dp[i, j] = dp[i - 1, j] + dp[i, j - 1];

            return dp[n - 1, m - 1];
        }
    }
}
