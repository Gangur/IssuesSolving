namespace IssuesSolving.Array
{
    public static class MaximumSubarray6
    {
        public static int Find(int[] arr)
        {
            if (arr.Length == 1) 
                return arr[0];

            int localMax = arr[0],
                max = int.MinValue;

            for (int i = 1; i < arr.Length; i++)
            {
                localMax = Math.Max(arr[i], localMax + arr[i]);
                max = Math.Max(max, localMax);
            }

            return max;
        }
    }
}
