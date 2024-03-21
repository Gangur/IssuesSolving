using IssuesSolving.Matrices.Structure;

namespace IssuesSolving.DynamicProgramming
{

    public static class InterleavingStringProblem
    {
        public static bool CheckIterleavingTabulation(string str1, string str2, string str3)
        {
            int n = str1.Length + 1,
                m = str2.Length + 1;

            if (n + m < str3.Length) 
                return false;

            var dpMap = new bool[n, m];
            dpMap[0, 0] = true;


            for (int i = 1; i < n; i++)
                dpMap[i, 0] = dpMap[i - 1, 0] && str1[i - 1] == str3[i - 1];

            for (int j = 1; j < m; j++)
                dpMap[0, j] = dpMap[0, j - 1] && str2[j - 1] == str3[j - 1];

            for (int i = 1; i < n; i++)
                for (int j = 1; j < m; j++)
                {
                    bool check_s1 = str1[i - 1] == str3[i + j - 1] && dpMap[i - 1, j];
                    bool check_s2 = str2[j - 1] == str3[i + j - 1] && dpMap[i, j - 1];
                    dpMap[i, j] = check_s1 || check_s2;
                }

            dpMap.Print();

            return dpMap[n - 1, m - 1];
        }

        public static bool CheckInterleavingMemoization(string str1, string str2, string str3)
        {
            if (str1.Length + str2.Length != str3.Length)
                return false;

            return checkInterleavingMemoization(str1, str2, str3, 0, 0, new Dictionary<string, bool>());
        }

        private static bool checkInterleavingMemoization(
            string str1, string str2, string str3,
            int i, int j, Dictionary<string, bool> lookup)
        {
            string key = i + "-" + j;
            if (lookup.ContainsKey(key))
                return lookup[key];

            int k = i + j;
            if (i == str1.Length &&
                j == str2.Length)
                return true;
            else
            {
                bool check_s1 = str1.Length > i && str1[i] == str3[k] && checkInterleavingMemoization(str1, str2, str3, i + 1, j, lookup);
                bool check_s2 = str2.Length > j && str2[j] == str3[k] && checkInterleavingMemoization(str1, str2, str3, i, j + 1, lookup);
                lookup[key] = check_s1 || check_s2;
                return lookup[key];
            }
        }
    }
}
