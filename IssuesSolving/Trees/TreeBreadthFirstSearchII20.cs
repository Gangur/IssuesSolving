using IssuesSolving.Trees.Structure;

namespace IssuesSolving.Trees
{
    public static class TreeBreadthFirstSearchII20
    {
        public static int[][] GetValuesByLevelMine(Tree tree) // O(n)
        {
            var stack = new Queue<(Tree key, int level)>();
            stack.Enqueue(new (tree, 0));

            Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();

            while (stack.Count > 0)
            {
                var node = stack.Dequeue();
                if (node.key != null)
                {
                    if (!dictionary.ContainsKey(node.level))
                        dictionary[node.level] = new List<int>();

                    dictionary[node.level].Add(node.key.data);

                    stack.Enqueue(new (node.key.left, node.level + 1));
                    stack.Enqueue(new (node.key.right, node.level + 1));
                }
            }

            int[][] result = new int[dictionary.Count][];

            for (int i = 0; i < dictionary.Count; i++)
                result[i] = dictionary[i].ToArray();

            return result;
        }
    }
}
