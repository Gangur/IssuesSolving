using IssuesSolving.Matrices.Structure;

namespace IssuesSolving.Strings
{
    public static class LongestCommonSubsequence36
    {
        public static int Calculate(string str1, string str2, int i = 0, int j = 0) // O(2^(n+m))
        {
            if (i == str1.Length || j == str2.Length)
                return 0;
            else if (str1[i] == str2[j])
                return 1 + Calculate(str1, str2, i + 1, j + 1);
            else
                return Math.Max(Calculate(str1, str2, i + 1, j), Calculate(str1, str2, i, j + 1));
        }

        public static int CalculateWithMemoize(string str1, string str2) // O(nm)
            => calculateWithMemoize(str1, str2, new Dictionary<string, int>());

        public static int calculateWithMemoize(string str1, string str2, Dictionary<string, int> memoize, int i = 0, int j = 0)
        {
            string key = i + "-" + j;
            if (memoize.ContainsKey(key))
                return memoize[key];
            if (i == str1.Length || j == str2.Length)
                return 0;
            else if (str1[i] == str2[j])
                return 1 + calculateWithMemoize(str1, str2, memoize, i + 1, j + 1);
            else
            {
                var result = Math.Max(calculateWithMemoize(str1, str2, memoize, i + 1, j), 
                        calculateWithMemoize(str1, str2, memoize, i, j + 1));
                memoize[key] = result;
                return result;
            }
        }

        public static int CalculateWithDp(string str1, string str2) // O(n*m)
        {
            int n = str1.Length + 1,
                m = str2.Length + 1;

            var dpMap = new int[n, m];

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (str1[i - 1] == str2[j - 1])
                        dpMap[i, j] = dpMap[i - 1, j - 1] + 1;
                    else
                        dpMap[i, j] = Math.Max(dpMap[i - 1, j], dpMap[i, j - 1]);
                }
            }
            
            return dpMap[str1.Length, str2.Length];
        }
    }
}
