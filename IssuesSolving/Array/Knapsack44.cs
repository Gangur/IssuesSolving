namespace IssuesSolving.Array
{
    public static class Knapsack44
    {
        public static int PackMax(int[] values, int[] weights, int maxWeight)
        {
            double[] ratios = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
                ratios[i] = values[i] / weights[i];

            int result = 0,
                 itemIndex = 1,
                 max = 0;

            while (maxWeight > 0)
            {
                itemIndex = -1;
                max = int.MinValue;
                for (int i = 0; i < ratios.Length; i++)
                {
                    if (ratios[i] > max && maxWeight >= weights[i])
                    {
                        max = values[i];
                        itemIndex = i;
                    }
                }

                if (itemIndex >= 0)
                {
                    ratios[itemIndex] = -1;
                    maxWeight -= weights[itemIndex];
                    result += max;
                }
                else
                    break;
            }

            return result;
        }
    }
}
