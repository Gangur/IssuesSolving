using IssuesSolving.Trees.Structure;

namespace IssuesSolving.Trees
{
    public static class RemoveNodeFromBinarySearchTree34
    {
        public static Tree DeleteNodeBst(Tree root, int num) // O(h)
        {
            if (root == default)
                return default;
            else if (num < root.data)
                root.left = DeleteNodeBst(root.left, num);
            else if (num > root.data)
                root.right = DeleteNodeBst(root.right, num);
            else
            {
                if (root.left == default)
                    return root.right;
                else if (root.right == default)
                    return root.left;
                else
                {
                    var successor = getMinNode(root.right);
                    root.data = successor.data;
                    root.right = DeleteNodeBst(root.right, successor.data);
                }
            }
            return root;
        }

        private static Tree getMinNode(Tree root)
        {
            if (root.left == null)
                return root;
            else
                return getMinNode(root.left);
        }
    }
}
