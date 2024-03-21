using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSolving.DynamicProgramming
{
    public static class GoldMineProblem
    {
        public static int MineAsMuchAsPossibleTabulation(int[,] mine)
        {
            int n = mine.GetLength(0),
                m = mine.GetLength(1);

            var dpMap = new int[n, m];

            for (int j = 0; j < m; j++)
                dpMap[0, j] = mine[0, j];

            for (int i = 1; i < n; i++)
            {
                dpMap[i, 0] = Math.Max(dpMap[i - 1, 0], dpMap[i - 1, 1]) + mine[i, 0];
                for (int j = 1; j < m - 1; j++)
                {
                    dpMap[i, j] = 
                        new[] { 
                            dpMap[i - 1, j - 1], 
                            dpMap[i - 1, j], 
                            dpMap[i - 1, j + 1] 
                        }.Max() + mine[i, j];
                }
                dpMap[i, m - 1] = Math.Max(dpMap[i - 1, m - 1], dpMap[i - 1, m - 2]) + mine[i, m - 1];
            }

            int result = 0;
            for (int j = 0; j < m; j++)
                result = Math.Max(result, dpMap[n - 1, j]);

            return result;
        }

        public static int MineAsMuchAsPossibleMemoization(int[,] mine)
        {
            int maxGold = 0;
            var lookup = new Dictionary<string, int>();

            for (int j = 0; j < mine.GetLength(1); j++)
                maxGold = Math.Max(maxGold, mineAsMuchAsPossibleMemoization(mine, 0, j, lookup));

            return maxGold;
        }

        public static int mineAsMuchAsPossibleMemoization(int[,] mine, int i, int j, Dictionary<string, int> lookup)
        {
            int n = mine.GetLength(0),
                m = mine.GetLength(1);

            string key = i + "-" + j;

            if (lookup.ContainsKey(key))
                return lookup[key];

            if (i == n || j < 0 || j == m)
                return 0;
            else
            {
                lookup[key] = mine[i, j] + new int[]
                {
                    mineAsMuchAsPossibleMemoization(mine, i + 1, j - 1, lookup),
                    mineAsMuchAsPossibleMemoization(mine, i + 1, j, lookup),
                    mineAsMuchAsPossibleMemoization(mine, i + 1, j + 1, lookup)
                }.Max();

                return lookup[key];
            }
        }
    }
}
