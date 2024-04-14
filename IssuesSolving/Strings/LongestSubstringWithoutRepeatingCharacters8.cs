namespace IssuesSolving.Strings
{
    public static class LongestSubstringWithoutRepeatingCharacters8
    {
        public static int Find(string str)
        {
            int max = int.MinValue;
            HashSet<char> hashset = new HashSet<char>(str.Length);

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i; j < str.Length; j++)
                {
                    if (hashset.Contains(str[j]))
                    {
                        max = Math.Max(hashset.Count, max);
                        hashset.Clear();
                        break;
                    }
                    else
                        hashset.Add(str[j]);
                }
            }

            return max;
        }
    }
}
