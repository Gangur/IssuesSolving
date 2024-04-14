namespace IssuesSolving.Strings
{
    public static class LongestPossiblePalindrome12
    {
        public static int Calculate(string str)
        {
            var dictionary = new Dictionary<char, int>();

            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];
                if (dictionary.ContainsKey(c))
                    dictionary[c]++;
                else
                    dictionary.Add(c, 1);
            }

            int sum = 0;
            bool hasEven = false;
            foreach (var letter in dictionary)
            {
                if (!hasEven && letter.Value % 2 == 1)
                    hasEven = true;

                sum = sum + letter.Value / 2 * 2;
            }

            return hasEven ? sum + 1 : sum;
        }
    }
}
