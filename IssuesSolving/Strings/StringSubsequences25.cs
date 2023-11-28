namespace IssuesSolving.Strings
{
    public static class StringSubsequences25
    {
        public static List<string> GetSubsequences(string str, int i = 0, string subsequence = "") // O(n*2^n)
        {
            var subsequences = new List<string>();
            if (i == str.Length)
            {
                subsequences.Add(subsequence);
            }
            else
            {
                subsequences.AddRange(GetSubsequences(str, i + 1, subsequence + str[i]));
                subsequences.AddRange(GetSubsequences(str, i + 1, subsequence));
            }

            return subsequences;
        }
    }
}
