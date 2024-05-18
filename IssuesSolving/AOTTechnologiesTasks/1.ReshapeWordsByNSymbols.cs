using System.Text;

namespace IssuesSolving.AOTTechnologiesTasks
{
    public static class ReshapeWordsByNSymbols
    {
        public static string Reshape(int n, string str)
        {
            var arr = str.Split(' ');
            var extra = new Stack<char>();
            int m = arr.Length;

            for (int i = 0; i < m; i++)
            {
                if (arr[i].Length > n)
                {
                    int removed = 0;
                    var local = arr[i].ToArray();
                    while (local.Length - removed != n)
                    {
                        extra.Push(local[removed]);
                        local[removed] = ' ';
                        removed++;
                    }

                    arr[i] = string.Join("", local).Trim();
                }
            }

            for (int i = 0; i < m; i++)
            {
                if (arr[i].Length < n)
                {
                    while (arr[i].Length != n && extra.Count != 0)
                        arr[i] += extra.Pop();
                }
            }

            var result = new StringBuilder(string.Join(" ", arr));
            var localResult = new StringBuilder();
            if (extra.Count != 0)
            {
                for (int i = 0; i < extra.Count; i++)
                {
                    localResult.Append(extra.Pop());
                    if (i / n == 0 && i != 0)
                    {
                        result.Append(" ");
                        result.Append(localResult.ToString());
                        localResult = new StringBuilder();
                    }
                }
            }

            if (localResult.Length > 0)
            {
                result.Append(" ");
                result.Append(localResult.ToString());
            }

            return result.ToString();
        }
    }
}
