namespace IssuesSolving.Strings
{
    public static class ValidBrackets26
    {
        private static Dictionary<char, char> _brackets = new Dictionary<char, char>()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };

        private static HashSet<char> _openBrackets = new HashSet<char>()
        {
            { '(' },
            { '[' }, 
            { '{' }
        };

        public static bool IsValid(string str) // O(n)
        {
            var stack = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];
                if (_openBrackets.Contains(c))
                {
                    stack.Push(_brackets[c]);
                }
                else if (_brackets.ContainsValue(c))
                {
                    var rc = stack.Pop();
                    if (c != rc)
                        return false;
                }
            }

            return true;
        }
    }
}
