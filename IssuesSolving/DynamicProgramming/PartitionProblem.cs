using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSolving.DynamicProgramming
{
    public static class PartitionProblem
    {
        public static bool CheckForSplitToTwoWithSubsets(int[] arr)
        {
            int sum = arr.Sum();

            if (sum % 2 == 1)
                return false;
            else
                return SubsetSumProblem.FindMaxSumSubsetsMemoization(arr, sum / 2) > 0;
        }

        public static bool CheckForSplitToTwo(int[] arr)
            => checkForSplitToTwo(arr, 0, 0, 0);

        private static bool checkForSplitToTwo(int[] arr, int i, int sum1, int sum2)
        {
            if (arr.Length == i)
                return sum1 == sum2;
            else return checkForSplitToTwo(arr, i + 1, sum1 + arr[i], sum2)
                    || checkForSplitToTwo(arr, i + 1, sum1, sum2 + arr[i]);
        }
    }
}
