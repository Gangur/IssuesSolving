namespace IssuesSolving.Array
{
    public static class LongestConsecutiveSequence37
    {
        public static int CalculateWithHashSet(int[] arr) // O(n)
        {
            if (arr.Length == 0)
                return 0;
            else if (arr.Length == 1)
                return 1;

            var set = arr.ToHashSet();

            int longestLength = 1,
                longestLengthLocal = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (!set.Contains(arr[i] - 1))
                {
                    var value = arr[i] + 1;
                    while (set.Contains(value))
                    {
                        value++;
                        longestLengthLocal++;
                    }
                    longestLength = Math.Max(longestLength, longestLengthLocal);
                    longestLengthLocal = 1;
                }
            }

            return longestLength;
        }

        public static int Calculate(int[] arr) // O(nlogn)
        {
            if (arr.Length == 0)
                return 0;
            else if (arr.Length == 1)
                return 1;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        arr[i] = arr[i] + arr[j];
                        arr[j] = arr[i] - arr[j];
                        arr[i] = arr[i] - arr[j];
                    }
                }
            }

            int maxLengthLocal = 1,
                maxLength = 1,
                lastValue = arr[0];

            for (int i = 1; i < arr.Length; i++) 
            {
                if (lastValue == arr[i] - 1)
                    maxLengthLocal++;
                else if (lastValue == arr[i])
                    continue;
                else
                {
                    maxLength = Math.Max(maxLengthLocal, maxLength);
                    maxLengthLocal = 1;
                }
                lastValue = arr[i];
            }

            return maxLength;
        }
    }
}
