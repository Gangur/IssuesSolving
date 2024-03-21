using IssuesSolving.Matrices.Structure;
using System.Runtime.Intrinsics.Arm;

namespace IssuesSolving.DynamicProgramming
{
    public static class SquareMatrixOfOnesProblem
    {
        public static int FindGreatestSquareAreaTabulation(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
        
            var dpMap = new int[n, m];

            dpMap[0, 0] = matrix[0, 0];

            for (int i = 1; i < n; i++)
                dpMap[i, 0] = matrix[i, 0];

            for (int j = 1; j < m; j++)
                dpMap[0, j] = matrix[0, j];

            int max = int.MinValue;
            for (int i = 1; i < n; i++)
                for (int j = 1; j < m; j++)
                {
                    dpMap[i, j] = matrix[i, j] == 0 ? 0 :
                        1 + new int[]
                        {
                            dpMap[i - 1, j],
                            dpMap[i, j - 1],
                            dpMap[i - 1, j - 1],
                        }.Min();

                    max = Math.Max(max, dpMap[i, j]);
                }

            dpMap.Print();
            return max * max;
        }

        public static int FindGreatestSquareAreaMemoization(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int max = int.MinValue;

            var lookup = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    max = Math.Max(max, findGreatestSquareAreaMemoization(matrix, i, j, lookup));
                }
            }

            return max * max;
        }

        // Find the max square in the bottom right corner
        private static int findGreatestSquareAreaMemoization(int[,] matrix, int i, int j, Dictionary<string, int> lookup)
        {
            string key = i + "-" + j;

            if (lookup.ContainsKey(key))
                return lookup[key];

            if (i < 0 || j < 0 || matrix[i, j] == 0)
                return 0;
            else
            {
                lookup[key] = 1 + new int[]
                {
                    findGreatestSquareAreaMemoization(matrix, i - 1, j, lookup),
                    findGreatestSquareAreaMemoization(matrix, i, j - 1, lookup),
                    findGreatestSquareAreaMemoization(matrix, i - 1, j - 1, lookup),
                }.Min();

                return lookup[key];
            }
        }
    }
}
