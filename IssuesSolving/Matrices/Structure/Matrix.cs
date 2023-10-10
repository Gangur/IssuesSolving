namespace IssuesSolving.Matrices.Structure
{
    public static class Matrix
    {
        public static int[][] Create()
        {
            return new int[][]
            {
                new int[] { 3, 12,  4,  7, 10 },
                new int[] { 6,  8, 15, 11,  4 },
                new int[] {19,  5, 14, 32, 21 },
                new int[] { 1, 20,  2,  9,  7 }
            };
        }

        public static int[][] CreatePaths()
        {
            return new int[][]
            {
                new int[] { 0, 0, 0, 0, 1 },
                new int[] { 1, 0, 1, 0, 0 },
                new int[] { 0, 0, 1, 0, 0 },
                new int[] { 0, 0, 0, 0, 0 },
            };
        }
    }
}
