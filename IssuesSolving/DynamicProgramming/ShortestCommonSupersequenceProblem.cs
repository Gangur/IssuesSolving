using IssuesSolving.Matrices.Structure;
using System.Diagnostics;

namespace IssuesSolving.DynamicProgramming
{
    public static class ShortestCommonSupersequenceProblem
    {
        public static int FindTablulation(string s1, string s2)
        {
            int n = s1.Length;
            int m = s2.Length;
            var dpMap = new int[n, m];

            for (int i  = 0; i < n; i++)
                dpMap[i, 0] = i + 1;

            for (int j = 0; j < m; j++)
                dpMap[0, j] = j + 1;

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (s1[i] == s2[j])
                        dpMap[i, j] = dpMap[i - 1, j - 1] + 1;
                    else
                        dpMap[i, j] = Math.Min(dpMap[i - 1, j], dpMap[i, j - 1]) + 1;
                }
            }

            dpMap.Print();

            return dpMap[n -1, m -1];
        }

        public static int FindMemoization(string s1, string s2)
            => findMemoization(s1, s2, 0, 0, new Dictionary<string, int>());

        private static int findMemoization(string s1, string s2, int i, int j, Dictionary<string, int> lookup)
        {
            string key = i + "-" + j;

            if (lookup.ContainsKey(key))
                return lookup[key];

            if (i == s1.Length)
                return s2.Length - j;
            else if (j == s2.Length)
                return s1.Length - i;
            else if (s1[i] == s2[j])
            {
                lookup[key] = findMemoization(s1, s2, i + 1, j + 1, lookup) + 1;
                return lookup[key];
            }
            else
            {
                lookup[key] = Math.Max(findMemoization(s1, s2, i, j + 1, lookup), findMemoization(s1, s2, i + 1, j, lookup));
                return lookup[key];
            }
        }
    }
}
