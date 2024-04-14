namespace IssuesSolving.Array
{
    public static class SimpleBinarySearch
    {
        public static bool Search(int[] sortedArr, int num)
        {
            int min = 0,
                max = sortedArr.Length - 1;

            while (min <= max) 
            {
                int mid = (min + max) / 2;
                if (sortedArr[mid] == num)
                    return true;
                else if (num < sortedArr[mid])
                    max = mid - 1;
                else
                    min = mid + 1;
            }

            return false;
        }
    }
}
