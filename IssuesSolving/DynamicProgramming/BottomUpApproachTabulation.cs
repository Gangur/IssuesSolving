using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSolving.DynamicProgramming
{
    public static class BottomUpApproachTabulation
    {
        public static int CountFibonacci(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1 || n == 2)
                return 1;

            int previous = 0,
                current = 1,
                next = 1;

            for (int i = 2; i < n; i++)
            {
                previous = current;
                current = next;
                next = previous + current;
            }

            return next;
        }
    }
}
