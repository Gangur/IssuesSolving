namespace IssuesSolving.Array
{
    public static class MinimumInRotatedSortedArray30
    {
        public static int Minimum(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                    return arr[i];
            }

            return arr[0];
        }
    }
}
