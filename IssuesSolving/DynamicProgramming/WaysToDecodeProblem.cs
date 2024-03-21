using IssuesSolving.Matrices.Structure;

namespace IssuesSolving.DynamicProgramming
{
    public static class WaysToDecodeProblem
    {
        private static HashSet<char> secondPlace = new HashSet<char>()
        {
            '0', '1', '2', '3', '4', '5', '6'
        };

        private static HashSet<char> firstPlace = new HashSet<char>()
        {
            '1', '2'
        };

        public static int FindWaysTabulation(string s)
        {
            int n = s.Length;
            var dpMap = new int[n];
            if (s[0] == '0')
                return 0;
            else if (s.Length == 1)
                return 1;

            dpMap[0] = 1;
            dpMap[1] = s[1] != '0' ? 1 : 0 + (firstPlace.Contains(s[0]) && secondPlace.Contains(s[1]) ? 1 : 0);

            for (int i = 2; i < n; i++) 
            {
                if (s[i] != '0')
                    dpMap[i] += dpMap[i - 1];

                if (firstPlace.Contains(s[i - 1]) && secondPlace.Contains(s[i]))
                    dpMap[i] += dpMap[i - 2];
            }

            return dpMap[n - 1];
        }

        public static int FindWaysMemoization(string s)
            => findWaysMemoization(s, 0, new Dictionary<int, int>());

        private static int findWaysMemoization(string s, int i, Dictionary<int, int> lookup)
        {
            if (lookup.ContainsKey(i))
                return lookup[i];

            if (s.Length <= i)
                return 1;
            else if (s[i] == '0')
                return 0;
            else if (i + 1 < s.Length && (firstPlace.Contains(s[i]) && secondPlace.Contains(s[i + 1])))
            {
                lookup[i] = findWaysMemoization(s, i + 1, lookup) + findWaysMemoization(s, i + 2, lookup);
                return lookup[i];
            }
            else
            {
                lookup[i] = findWaysMemoization(s, i + 1, lookup);
                return lookup[i];
            }
        }
    }
}
