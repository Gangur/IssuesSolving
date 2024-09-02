namespace IssuesSolving.AOTTechnologiesTasks
{
    public static class FindFirstTheSmallestNumberWithoutRepetitionsInResult
    {
        public static long Next(int n)
        {
            var set = new HashSet<int>();
            int length = 0,
                firstNumber = 0;

            while (n > 0)
            {
                firstNumber = n % 10;
                set.Add(firstNumber);
                n /= 10;
                length++;
            }

            if (set.Count == 10)
            {
                return -1;
            }

            int minFiller = int.MaxValue;

            for (int i = 0; i < 10; i++)
            {
                if (!set.Contains(i))
                {
                    minFiller = i;
                    break;
                }
            }

            int minForFirstNumber = -1;
            for (int i = firstNumber; i < 10; i++)
            {
                if (!set.Contains(i))
                {
                    minForFirstNumber = i;
                    break;
                }
            }

            int result;
            if (minForFirstNumber < 0)
            {
                result = minFiller;
                while (length > 0)
                    result = result * 10;
            }
            else
            {
                result = minForFirstNumber;
                for (int i = 0; i < length - 1; i++)
                {
                    result = result * 10 + minFiller;
                }
            }

            return result;
        }
    }
}
