using System.Text;

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

        public static void Print(this int[][] matrix)
        {
            Console.WriteLine();
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine("[ " + string.Join(' ', matrix[i])+ " ]");
            }
            Console.WriteLine();
        }

        public static void Print(this int[,] matrix)
        {
            int maxPlace = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    maxPlace = Math.Max(maxPlace, findPlaceofNumber(matrix[i, j]));

            Console.WriteLine();
            StringBuilder stringBuilder;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                stringBuilder = new StringBuilder("[ ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int localPlace = findPlaceofNumber(matrix[i, j]);

                    stringBuilder.Append(matrix[i, j]);
                    while (maxPlace > localPlace)
                    {
                        stringBuilder.Append(' ');
                        localPlace++;
                    }
                    stringBuilder.Append(' ');
                }
                stringBuilder.Append("]");

                Console.WriteLine(stringBuilder.ToString());
            }

            Console.WriteLine();
        }

        private static int findPlaceofNumber(int n)
        {
            if (n == 0)
                return 1;

            int result = 0;
            while (n > 0)
            {
                n /= 10;
                result++;
            }

            return result;
        }

        public static void Print<T>(this T[] arr) where T : struct
        {
            Console.WriteLine();
            Console.WriteLine("[ " + string.Join(" ", arr) + " ]");
            Console.WriteLine();
        }

        public static void Print(this bool[,] matrix)
        {
            Console.WriteLine();
            StringBuilder stringBuilder;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                stringBuilder = new StringBuilder("[ ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    stringBuilder.Append(matrix[i, j] ? '1' : '0');
                    stringBuilder.Append(' ');
                }
                stringBuilder.Append("]");

                Console.WriteLine(stringBuilder.ToString());
            }

            Console.WriteLine();
        }
    }
}
