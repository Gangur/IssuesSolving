namespace IssuesSolving.Strings
{
    public static class FirstRepeatingCharacter2
    {
        public static char FindFirst(string str)
        {
            var hashset = new HashSet<char>();

            for (int i = 0; i < str.Length; i++)
            {
                if (hashset.Contains(str[i]))
                    return str[i];
                else
                    hashset.Add(str[i]);
            }

            return '\0';
        }
    }
}
