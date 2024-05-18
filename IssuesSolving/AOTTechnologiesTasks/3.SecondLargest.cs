namespace IssuesSolving.AOTTechnologiesTasks
{
    public static class SecondLargest
    {
        public static int Find(List<int> numbers) // better array
        {
            int n = numbers.Count;
            if (n <= 1)
                return -1;

            int firstLargest = int.MinValue;
            int secondLargest = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                if (firstLargest < numbers[i])
                {
                    secondLargest = firstLargest;
                    firstLargest = numbers[i];
                }

                if (numbers[i] < firstLargest && numbers[i] > secondLargest)
                    secondLargest = numbers[i];
            }

            return secondLargest;
        }
    }
}
