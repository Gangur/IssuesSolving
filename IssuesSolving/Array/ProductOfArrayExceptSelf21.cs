namespace IssuesSolving.Array
{
    public static class ProductOfArrayExceptSelf21
    {
        public static int[] CalculateBruteForce(int[] arr) // O(n²)
        {
            Span<int> result = stackalloc int[arr.Length];
            int product;
            for (int i = 0; i < arr.Length; i++)
            {
                product = 1;
                for (int j = 0; j < arr.Length; j++)
                    if (i != j)
                        product *= arr[j];
                result[i] = product;
            }

            return result.ToArray();
        }

        public static int[] CalculateWithCumulativeArr(int[] arr) // O(n)
        {
            int n = arr.Length;
            Span<int> result = stackalloc int[n],
                cumulativeLeft = stackalloc int[n],
                cumulativeRigth = stackalloc int[n];

            int i = 1;
            cumulativeLeft[0] = 1;
            cumulativeRigth[n - 1] = 1;

            for(; i < arr.Length; i++)
                cumulativeLeft[i] = cumulativeLeft[i - 1] * arr[i -1];
            i = i - 2;
            for(; i >=0; i--)
                cumulativeRigth[i] = cumulativeRigth[i + 1] * arr[i + 1];

            i++;
            for (; i < n; i++)
                result[i] = cumulativeLeft[i] * cumulativeRigth[i];

            return result.ToArray();
        }
    }
}
