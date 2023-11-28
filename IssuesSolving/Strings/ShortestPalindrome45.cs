using System.Text;

namespace IssuesSolving.Strings
{
    public static class ShortestPalindrome45
    {
        public static string Build(string str) // n
        {
            var concatenation = str + '#' + string.Join(string.Empty, str.Reverse());
            var lps = getLps(concatenation);

            int mirrorLength = lps[lps.Length - 1];
            string suffix = string.Join(string.Empty, str.Substring(mirrorLength, str.Length - mirrorLength).Reverse());
            return suffix + str;
        }

        private static int[] getLps(string concatenation)
        {
            int[] lps = new int[concatenation.Length];

            int j = 0;
            for (int i = 1; i < concatenation.Length; i++)
            {
                if (concatenation[i] == concatenation[j])
                {
                    j++;
                    lps[i] = j;
                }
                else
                    j = 0;
            }

            return lps;
        }
    }
}
