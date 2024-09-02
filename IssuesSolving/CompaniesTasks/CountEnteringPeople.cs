using System.Text;

namespace IssuesSolving.CompaniesTasks
{
    public static class CountEnteringPeople
    {
        public static string Find(string input)
        {
            var amountMap = new Dictionary<char, int>()
            {
                { 'M', 0 },
                { 'W', 0 },
                { 'C', 0 },
            };

            var orderMap = new Dictionary<char, ushort>()
            {
                { 'M', 1 },
                { 'W', 2 },
                { 'C', 3 },
            };

            for (int i = 0; i < input.Length; i++)
            {
                amountMap[input[i]]++;
            }

            var result = new StringBuilder(6);

            char max = 'M';
            int count = 0;

            while (count < amountMap.Count)
            {
                foreach (var pair in amountMap)
                {
                    if (pair.Value > amountMap[max])
                    {
                        max = pair.Key;
                    }
                    else if (pair.Key != max && pair.Value == amountMap[max])
                    {
                        max = orderMap[pair.Key] < orderMap[max] ? pair.Key : max;
                    }
                }

                result.Append(max);
                result.Append(amountMap[max]);
                amountMap[max] = int.MinValue;
                count++;
            }

            return result.ToString();
        }
    }
}
