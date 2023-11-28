using IssuesSolving.Matrices.Structure;

namespace IssuesSolving.Strings
{
    public static class EditDistance38
    {
        public static int FindMin(string word1, string word2, int i = 0, int j = 0) // O(3^n+m)
        {
            if (i == word1.Length)
                return word1.Length - j;
            else if (j == word2.Length)
                return word2.Length - i;
            else if (word1[i] == word2[j])
                return FindMin(word1, word2, i + 1, j + 1);
            else
                return 1 + Math.Min(
                    Math.Min(
                        FindMin(word1, word2, i + 1, j), 
                        FindMin(word1, word2, i, j + 1)), 
                    FindMin(word1, word2, i + 1, j + 1));
        }

        public static int FindMinDp(string word1, string word2)
        {
            int n = word1.Length + 1;
            int m = word2.Length + 1;

            int[,] dpMap = new int[n, m];

            for (int i = 0; i < n; i++)
                dpMap[i, 0] = i;

            for (int j = 0; j < m; j++)
                dpMap[0, j] = j;

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                        dpMap[i, j] = dpMap[i - 1, j - 1];
                    else
                        dpMap[i, j] = Math.Min(Math.Min(dpMap[i - 1, j], dpMap[i, j - 1]), dpMap[i - 1, j - 1]) + 1;
                }
            }
            dpMap.Print();
            return dpMap[word1.Length, word2.Length];
        }
    }
}
