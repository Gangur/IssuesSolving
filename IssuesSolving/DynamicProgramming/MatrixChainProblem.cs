using IssuesSolving.Matrices.Structure;
using System.Linq;

namespace IssuesSolving.DynamicProgramming
{
    public class MatrixChainProblem
    {
        public static int FindMinCostTabulation(int[,] matrices)
        {
            int n = matrices.GetLength(0);

            int[,] dpMap = new int[n, n];
            
            for (int d = 1; d < n; d++)
            {
                for (int i = 0; i < n - d; i++)
                {
                    int j = i + d;
                    int min = int.MaxValue;
                    for (int k = i; k < j; k++)
                    {
                        int left = dpMap[i, k];
                        int right = dpMap[k + 1, j];
                        int cost = matrices[i, 0] * matrices[k, 1] * matrices[j, 1];
                        min = Math.Min(min, left + right + cost);
                    }
                    dpMap[i, j] = min;
                }
            }

            dpMap.Print();
            return dpMap[0, n - 1];
        }

        public static int FindMinCostMemoization(int[,] matrices)
            => findMinCostMemoization(matrices, 0, matrices.GetLength(0) - 1, new Dictionary<string, int>());

        private static int findMinCostMemoization(int[,] matrices, int i, int j, Dictionary<string, int> lookup)
        {
            string key = i + "-" + j;

            if (lookup.ContainsKey(key))
                return lookup[key];

            if (i == j)
                return 0;
            else
            {
                int min_cost = int.MaxValue;
                for (int k = i; k < j; k++)
                {
                    int left = findMinCostMemoization(matrices, i, k, lookup);
                    int right = findMinCostMemoization(matrices, k + 1, j, lookup);
                    int cost = matrices[i, 0] * matrices[k, 1] * matrices[j, 1];
                    min_cost = Math.Min(min_cost, left + right + cost);
                }

                lookup[key] = min_cost;
                return lookup[key];
            }
        }
    }
}
