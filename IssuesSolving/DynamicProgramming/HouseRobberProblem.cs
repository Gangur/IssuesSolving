using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSolving.DynamicProgramming
{
    public static class HouseRobberProblem
    {
        public static int RobTabulation(int[] houses)
        {
            int n = houses.Length;
            if (n < 2)
                return houses[0];
            else if (n < 3)
                return Math.Max(houses[0], houses[1]);

            Span<int> dpMap = stackalloc int[n];

            dpMap[0] = houses[0];
            dpMap[1] = Math.Max(houses[0], houses[1]);

            for (int i = 2; i < n; i++)
                dpMap[i] = Math.Max(dpMap[i - 1], houses[i] + dpMap[i - 2]);

            return dpMap[n - 1];
        }

        public static int RobMemoization(int[] houses)
            => robMemoizition(houses, 0, new Dictionary<int, int>());

        private static int robMemoizition(int[] houses, int i, Dictionary<int, int> lookup)
        {
            if (lookup.ContainsKey(i))
                return lookup[i];

            int n = houses.Length;

            if (i >= n)
                return 0;
            else
                lookup[i] = Math.Max(
                    robMemoizition(houses, i + 1, lookup), 
                    robMemoizition(houses, i + 2, lookup) + houses[i]);
                return lookup[i];
        }
    }
}
