using IssuesSolving.Matrices.Structure;
using System.Security.AccessControl;

namespace IssuesSolving.DynamicProgramming
{
    public static class EditDistanceProblem
    {
        public static int FindMinDistanceTabulation(string str1, string str2)
        {
            int n = str1.Length;
            int m = str2.Length;

            var dpMap = new int[n + 1, m + 1];

            for (int i = 1; i < n + 1; i++)
                dpMap[i, 0] = i;

            for (int j = 1  ; j < m + 1; j++)
                dpMap[0, j] = j;

            for (int i = 1; i < n + 1; i++)
                for (int j = 1; j < m + 1; j++)
                    if (str1[i - 1] == str2[j - 1])
                        dpMap[i, j] = dpMap[i - 1, j - 1];
                    else
                        dpMap[i, j] = 1 + new int[] 
                        { 
                            dpMap[i - 1, j],        // delete
                            dpMap[i - 1, j - 1],    // insert
                            dpMap[i, j - 1]         // substitute
                        }.Min();

            dpMap.Print();
            return dpMap[n, m];
        }

        public static int FindMinDistanceMemoization(string str1, string str2)
            => findMinDistanceMemoization(str1, str2, 0, 0, new Dictionary<string, int>());

        private static int findMinDistanceMemoization(string str1, string str2, int i, int j, Dictionary<string, int> lookup)
        {
            string key = i + "-" + j;
            if (lookup.ContainsKey(key))
                return lookup[key];

            if (i == str1.Length)
                return str2.Length - j;
            else if (j == str2.Length) 
                return str1.Length - i;
            if (str1[i] == str2[j])
            {
                lookup[key] = findMinDistanceMemoization(str1, str2, i + 1, j + 1, lookup);
                return lookup[key];
            }
            else
            {
                lookup[key] = 1 + new int[]
                {
                    findMinDistanceMemoization(str1, str2, i + 1, j, lookup),     // delete
                    findMinDistanceMemoization(str1, str2, i + 1, j + 1, lookup), // insert
                    findMinDistanceMemoization(str1, str2, i, j + 1, lookup),     // substitute
                }.Min();
                return lookup[key];
            }
        }
    }
}
