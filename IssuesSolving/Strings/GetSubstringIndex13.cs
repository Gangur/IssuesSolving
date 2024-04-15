namespace IssuesSolving.Strings
{
    public static class GetSubstringIndex13
    {
        public static int SubstrIndex(string str1, string str2)
        {
            int n = str1.Length;
            int m = str2.Length;

            if (n < m) return -1;
            else if (n == m)
            {
                if (str1 == str2)
                    return 0;
                else
                    return -1;
            }
            else if (str2 == string.Empty)
                return 0;

            for (int i = 0; i < n; i++)
            {
                if (str1[i] == str2[0] && 
                    n >= m + i)
                {
                    int j;
                    for (j = 1; j < m; j++)
                    {
                        if (str1[i + j] != str2[j])
                            break;
                    }

                    if (j == m)
                        return i;
                }
            }

            return -1;
        }

        public static int SubstrIndexLps(string str1, string str2)
        {
            int n = str1.Length;
            int m = str2.Length;

            if (n < m) return -1;
            else if (n == m)
            {
                if (str1 == str2)
                    return 0;
                else
                    return -1;
            }
            else if (str2 == string.Empty)
                return 0;

            Span<int> lps = stackalloc int[m];

            int i, j;

            for (i = 1, j = 0; i < m; i++)
            {
                if (str2[i] == str2[j])
                {
                    j++;
                    lps[i] = j;
                }
                else
                    j = 0;
            }

            i = 0;
            j = 0;

            while (i < n && j < m)
            {
                if (str1[i] == str2[j])
                {
                    i++;
                    j++;
                }
                else if (j != 0)
                    j = lps[j - 1];
                else
                    i++;
            }

            return j < m ? -1 : i - j;
        }
    }
}
