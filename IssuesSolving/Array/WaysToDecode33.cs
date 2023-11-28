namespace IssuesSolving.Array
{
    public static class WaysToDecode33
    {
        public static int CountBruteForce(string str)
        {
            if (str.Length == 0)
                return 0;
            else
                return countBruteForce(str);
        }

        private static HashSet<char> numbers = new HashSet<char>()
        {
            '0',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
        };

        private static int countBruteForce(string str, int i = 0)
        {
            if (i >= str.Length - 1)
                return 1;
            else if (str[i] == '0')
                return 0;
            else if (str[i] == '1' || (str[i] == '2' && numbers.TryGetValue(str[i + 1], out var plug)))
                return  countBruteForce(str, i + 1) + 
                        countBruteForce(str, i + 2);
            else
                return countBruteForce(str, i + 1);
        }

        public static int CountDp(string str)
        {
            if (str.Length < 1 || str[0] == '0')
                return 0;

            int beforePrevious = 1,
                previous = 1,
                current = 0;

            for (int i = 1; i < str.Length; i++)
            {
                current = 0;
                if (str[i] != '0')
                    current += previous;

                if (str[i - 1] == '1' || (str[i - 1] == '2' && numbers.TryGetValue(str[i], out var plug)))
                    current += beforePrevious;

                beforePrevious = previous;
                previous = current;
            }

            return previous;
        }
    }
}
