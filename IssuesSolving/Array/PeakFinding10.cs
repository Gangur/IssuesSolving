namespace IssuesSolving.Array
{
    public static class PeakFinding10
    {
        public static int Find(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                if ((i == 0 || arr[i] >= arr[i - 1]) && (i == n - 1 || arr[i] >= arr[i + 1]))
                    return i;
            }

            return -1;
        }
    }
}
