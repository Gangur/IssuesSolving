using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSolving.DynamicProgramming
{
    public class TopDownApproachMemoization
    {
        public static int CountFibonacci(int n, Dictionary<int, int> dictionary = default)
        {
            if (dictionary == default) 
                dictionary = new Dictionary<int, int>();
            return countFibonacci(n, dictionary);
        }

        private static int countFibonacci(int n, Dictionary<int, int> dictionary)
        {
            if (dictionary.ContainsKey(n))
                return dictionary[n];
            else if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            else
            {
                dictionary[n] = countFibonacci(n - 1, dictionary) + countFibonacci(n - 2, dictionary);
                return dictionary[n];
            }
        }
    }
}
