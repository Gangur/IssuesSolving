using IssuesSolving.Matrices.Structure;
using System;
using System.Linq;

namespace IssuesSolving.DynamicProgramming
{
    public static class MinimumCostForTicketsProblem
    {
        public static int FindMemoization(int[] train_days, int[] costs, int n)
            => findMemoization(train_days.ToHashSet(), costs, n, 0, new Dictionary<int, int>());

        private static int findMemoization(HashSet<int> train_days, int[] costs, int n, int day, Dictionary<int, int> lookup)
        {
            if (lookup.ContainsKey(day))
                return lookup[day];

            if (day >= n)
                return 0;
            else if (!train_days.Contains(day))
            {
                lookup[day] = findMemoization(train_days, costs, n, day + 1, lookup);
                return lookup[day];
            }
            else
            {
                lookup[day] = new int[]
                {
                    costs[0] + findMemoization(train_days, costs, n, day + 1, lookup),
                    costs[1] + findMemoization(train_days, costs, n, day + 7, lookup),
                    costs[2] + findMemoization(train_days, costs, n, day + 30, lookup)
                }.Min();
                return lookup[day];
            }
        }

        public static int FindTabulation(int[] train_days, int[] costs, int n)
        {
            Span<int> daysForCosts = stackalloc int[] { 1, 7, 30 };

            Span<int> dpMapSpan = stackalloc int[n];

            HashSet<int> settraindays = train_days.ToHashSet();

            for (int i = 0; i < dpMapSpan.Length; i++)
            {
                if (!settraindays.Contains(i))
                {
                    if (i - 1 >= 0)
                        dpMapSpan[i] = dpMapSpan[i - 1];
                    else
                        dpMapSpan[i] = 0;
                }
                else
                {
                    int day_cost =   costs[0] + (i - daysForCosts[0] >= 0 ? dpMapSpan[i - 1] : 0);
                    int week_cost =  costs[1] + (i - daysForCosts[1] >= 0 ? dpMapSpan[i - 7] : 0);
                    int month_cost = costs[2] + (i - daysForCosts[2] >= 0 ? dpMapSpan[i - 30] : 0);

                    dpMapSpan[i] = new int[] { day_cost, week_cost, month_cost }.Min();
                }
            }

            //dpMap.Print();

            return dpMapSpan[n - 1];
        }
    }
}
