using IssuesSolving.Trees.Structure;

namespace IssuesSolving.Trees
{
    public static class TreeBreadthFirstSearch14
    {
        public static void Print(Tree tree)
        {
            var levels = new Dictionary<int, List<int>>();

            collectLevels(tree, 1, levels);

            foreach (var level in levels)
            {
                Console.WriteLine(level.Key + " - [" + string.Join(' ', level.Value) + "]");
            }
        }

        private static void collectLevels(Tree tree, int level, Dictionary<int, List<int>> levels)
        {
            if (tree == null)
                return;

            if (!levels.ContainsKey(level))
                levels[level] = new List<int>() { tree.data };
            else
                levels[level].Add(tree.data);

            collectLevels(tree.left, level + 1, levels);
            collectLevels(tree.right, level + 1, levels);
        }
    }
}
