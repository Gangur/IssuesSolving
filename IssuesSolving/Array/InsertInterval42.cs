namespace IssuesSolving.Array
{
    public static class InsertInterval42
    {
        public static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            for (int i = 0; i < intervals.Length; i++)
            {
                if (intervals[i][1] >= newInterval[0])
                {
                    newInterval[0] = Math.Max(newInterval[0], intervals[i][0]);
                    for (int j = i + 1; j < intervals.Length; j++)
                    {
                        if (newInterval[1] <= intervals[j][1])
                        {
                            intervals[i][1] = intervals[j][1];
                            i = j;
                            intervals[j] = new int[0];
                            break;
                        }
                        intervals[j] = new int[0];
                    }
                    break;
                }
            }

            return intervals.Where(x => x.Length > 0).ToArray();
        }
    }
}
