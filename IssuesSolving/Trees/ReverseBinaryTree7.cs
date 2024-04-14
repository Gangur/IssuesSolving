using IssuesSolving.Trees.Structure;

namespace IssuesSolving.Trees
{
    public static class ReverseBinaryTree7
    {
        public static void Reverse(Tree tree)
        {
            if (tree == null)
                return;

            var left = tree.left;
            tree.left = tree.right;
            tree.right = left;

            Reverse(tree.left);
            Reverse(tree.right);
        }
    }
}
