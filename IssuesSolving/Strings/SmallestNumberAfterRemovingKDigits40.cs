using System.Text;

namespace IssuesSolving.Strings
{
    public static class SmallestNumberAfterRemovingKDigits40
    {
        public static string FindSmallest(string num, int k)
        {
            if (k == num.Length)
                return "0";

            var stack = new Stack<int>(num.Length - k);
            
            for (int i = 0; i < num.Length; i++)
            {
                while (stack.Count > 0 && num[i] - '0' < stack.Peek() && k > 0)
                {
                    stack.Pop();
                    k--;
                }
                stack.Push(num[i] - '0');
            }

            while (k > 0)
            {
                stack.Pop();
                k--;
            }

            var reverse = stack.Reverse().ToList();

            while (reverse.Count > 0 && reverse[0] == 0)
                reverse.Remove(reverse[0]);

            var result = string.Join(string.Empty, reverse);

            if (result.Length > 0)
                return result;
            else
                return "0";
        }
    }
}
