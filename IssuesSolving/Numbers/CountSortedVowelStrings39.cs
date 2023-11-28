using IssuesSolving.Matrices.Structure;

namespace IssuesSolving.Numbers
{
    public static class CountSortedVowelStrings39
    {
        private static int _vowels = 5; //"aeiou";
        public static int CountBruteforce(int n, int i = 0) // O(5 ^ n)
        {
            if (n == 0)
                return 1;
            else
            {
                int result = 0;
                for (int j = i; j < _vowels; j++) 
                    result += CountBruteforce(n - 1, j);
                return result;
            }
        }

        public static int CountDp(int n) // O(n)
        {
            int[,] dpMap = new int[n, _vowels];

            for (int i = 0; i < _vowels; i++)
                dpMap[0, i] = 1;

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < _vowels; j++)
                    dpMap[i, 0] += dpMap[i - 1, j];

                for (int j = 1; j < _vowels; j++)
                    dpMap[i, j] = dpMap[i, j - 1] - dpMap[i - 1, j - 1];
            }

            dpMap.Print();

            int result = 0;
            for (int i = 0; i < _vowels; i++)
                result += dpMap[n - 1 , i];

            return result;
        }

        public static int CountMath(int n) // O(1)
            => (n + 4) * (n + 3) * (n + 2) * (n + 1) / 24;
    }
}
