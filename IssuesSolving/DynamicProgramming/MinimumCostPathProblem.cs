using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSolving.DynamicProgramming
{
    public static class MinimumCostPathProblem
    {
        public static int FindWithTabulation(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[,] dpMap = new int[n, 2];

            dpMap[0, 0] = matrix[0, 0];

            for (int i = 1; i < n; i++)
                dpMap[i, 0] = dpMap[i - 1, 0] + matrix[i, 0];

            for (int j = 1; j < m; j++)
            {
                dpMap[0, 1] = dpMap[0, 0] + matrix[0, j];
                
                for(int i = 1; i < n; i++)
                {
                    dpMap[i, 1] = matrix[i, j] + Math.Min(dpMap[i - 1, 1], dpMap[i, 0]);
                    dpMap[i, 0] = dpMap[i, 1];
                }
            }

            return dpMap[n - 1, 1];
        }


        public static int FindWithMemoization(int[,] matrix, int i = 0, int j= 0, Dictionary<string, int>? memoz = default)
        {
            if (memoz == null)
                memoz = new Dictionary<string, int>();

            return findWithMemoization(matrix, i, j, memoz);
        }

        private static int findWithMemoization(int[,] matrix, int i, int j, Dictionary<string, int> memoz)
        {
            int n = matrix.GetLength(0),
                m = matrix.GetLength(1);

            string key = i + "-" + j;

            if (memoz.ContainsKey(key))
                return memoz[key];
            else if (i == n - 1 && j == m - 1)
                return matrix[n - 1, m - 1];
            else if (i == n - 1)
            {
                memoz[key] = matrix[i, j] + findWithMemoization(matrix, i, j + 1, memoz);
                return memoz[key];
            }
            else if (j == m - 1)
            {
                memoz[key] = matrix[i, j] + findWithMemoization(matrix, i + 1, j, memoz);
                return memoz[key];
            }
            else
            {
                memoz[key] = matrix[i, j] + Math.Min(findWithMemoization(matrix, i, j + 1, memoz),
                    findWithMemoization(matrix, i + 1, j, memoz));
                return memoz[key];
            }
        }
    }
}
