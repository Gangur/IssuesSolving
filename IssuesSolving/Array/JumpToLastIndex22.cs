namespace IssuesSolving.Array
{
    public static class JumpToLastIndex22
    {
        public static bool CanJumpRecursion(int[] arr, int i = 0) // O(2^n)
        {
            if(i == arr.Length - 1)
                return true;

            for (int j = 1; j < arr[i] + 1; j++)
            {
                if (CanJumpRecursion(arr, i + j))
                    return true;
            }

            return false;
        }


        public static bool CanJumpDp(int[] arr) // O(n^2)
        {
            int n = arr.Length;
            var dp = new bool[n];
            dp[0] = true;

            for (int i = 0; i < n; i++)
            {
                if (!dp[i])
                    return false;
                else if (i + arr[i] >= n - 1)
                    return true;
                else
                    for (int j = 1; j < arr[i] + 1; j++)
                        dp[i + j] = true;
            }

            return dp[n - 1];
        }

        public static bool CanJumpMyDp(int[] arr) // O(n)
        {
            int[] dp = new int[arr.Length];
            int capacity = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                capacity = Math.Max(capacity, arr[i]);
                if (capacity <= 0)
                    return false;

                dp[i] = capacity;
                capacity--;
            }

            return true;
        }

        public static bool CanJumpMaxIndex(int[] arr) // O(n)
        {
            int n = arr.Length;
            int maxIndex = 0;
            for (int i = 0; i < n; i++)
            {
                if (i > maxIndex)
                    return false;
                else
                    maxIndex = Math.Max(maxIndex, i + arr[i]);
            }

            return maxIndex >= n - 1;
        }
    }
}
