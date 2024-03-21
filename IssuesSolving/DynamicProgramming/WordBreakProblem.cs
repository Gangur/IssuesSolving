namespace IssuesSolving.DynamicProgramming
{
    public static class WordBreakProblem
    {
        public static bool IsStringBreakTabulation(string s, string[] words) 
        {
            int n = s.Length + 1;
            Span<bool> dpMap = stackalloc bool[n + 1];
            var wordsMap = new ReadOnlySpan<string>(words);

            dpMap[0] = true; 

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < wordsMap.Length; j++)
                {
                    if (wordsMap[j].Length <= i)
                    {
                        var wordBeginning = i - wordsMap[j].Length;
                        var word = wordsMap[j];
                        var substring = s.Substring(wordBeginning, wordsMap[j].Length);
                        dpMap[i] = dpMap[i] || (substring == word && dpMap[wordBeginning]);
                    }
                }
            }

            return dpMap[s.Length - 1];
        }

        public static bool IsStringBreakMemoization(string s, string[] words)
            => isStringBreakMemoization(s, words.ToHashSet(), 0, new Dictionary<int, bool>());

        private static bool isStringBreakMemoization(string s, HashSet<string> words, int i, Dictionary<int ,bool> lookup)
        {
            if (lookup.ContainsKey(i))
                return lookup[i];

            if (i == s.Length)
                return true;
            else
            {
                for (int j = i; j < s.Length + 1; j++)
                {
                    string substr = s.Substring(i, j - i);
                    if (words.Contains(substr) && isStringBreakMemoization(s, words, j, lookup))
                    {
                        lookup[i] = true;
                        return true;
                    }
                }

                lookup[i] = false;
                return false;
            }
        }
    }
}
