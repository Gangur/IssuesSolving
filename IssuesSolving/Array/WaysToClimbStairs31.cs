namespace IssuesSolving.Array
{
    public static class WaysToClimbStairs31
    {
        public static int WaysToClimb(int n, int[] possibleSteps) // O(m^n)
        {
            if (n == 0) 
                return 1;

            var ways = 0;
            for (int i = 0; i < possibleSteps.Length; i++)
            {
                var stepWay = n - possibleSteps[i];
                if (stepWay >= 0)
                    ways += WaysToClimb(stepWay, possibleSteps);
            }

            return ways;
        }

        public static int WaysToClimbDp(int n, int[] possibleSteps) // O(n*m)
        {
            var dpMap = new int[n + 1];
            dpMap[0] = 1;

            for (int i = 0; i < dpMap.Length; i++)
            {
                for (int j = 0; j < possibleSteps.Length; j++)
                {
                    var step = i - possibleSteps[j];
                    if (step >= 0)
                    {
                        dpMap[i] += dpMap[step];
                    }
                }
            }

            return dpMap[n];
        }
    }
}
