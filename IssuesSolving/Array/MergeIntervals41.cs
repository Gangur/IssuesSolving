namespace IssuesSolving.Array
{
    public static class MergeIntervals41
    {
        public static int[][] Merge(int[][] intervals) // O(nlogn)
        {
            intervals = intervals.OrderBy(x => x[0]).ToArray();

            for (int i = 0; i < intervals.Length - 1; i++)
            {
                if (intervals[i][1] >= intervals[i + 1][0])
                {
                    intervals[i + 1][0] = intervals[i][0];
                    intervals[i + 1][1] = Math.Min(intervals[i][1], intervals[i + 1][1]);
                    intervals[i] = new int[0];
                }
            }

            return intervals.Where(x => x.Length > 0).ToArray();
        }
    }
}
