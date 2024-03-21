using IssuesSolving.Matrices.Structure;

namespace IssuesSolving.DynamicProgramming
{
    public static class LongestCommonSubsequenceProblem
    {
        public static int FindMemoization(string str1, string str2)
            => findMemoization(str1, str2, 0, 0, new Dictionary<string, int>());

        private static int findMemoization(string str1, string str2, int i = 0, int j = 0, Dictionary<string, int> lookup = default)
        {
            string key = i + "-" + j;
            if (lookup.ContainsKey(key))
                return lookup[key];

            if (i == str1.Length || j == str2.Length)
                return 0;
            else if (str1[i] == str2[j])
            {
                lookup[key] = 1 + findMemoization(str1, str2, i + 1, j + 1, lookup);
                return lookup[key];
            }
            else
            {
                lookup[key] = Math.Max(
                    findMemoization(str1, str2, i + 1, j, lookup),
                    findMemoization(str1, str2, i, j + 1, lookup));
                return lookup[key];
            }
        }

        public static int FindTabulation(string str1, string str2)
        {
            int n = str1.Length + 1,
                m = str2.Length + 1;
            
            var dpMap = new int[n + 1, m + 1];

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (str1[i - 1] == str2[j - 1])
                        dpMap[i, j] = 1 + dpMap[i - 1, j - 1];
                    else
                        dpMap[i, j] = Math.Max(dpMap[i - 1, j], dpMap[i, j - 1]);
                }
            }
            dpMap.Print();
            return dpMap[str1.Length, str2.Length];
        }
    }
}
