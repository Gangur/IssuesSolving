using IssuesSolving.Trees.Structure;

namespace IssuesSolving.Trees
{
    public static class FlattenBinaryTree27
    {
        public static void FlattenTree(Tree root) // O(n²)
        {
            if (root == null) 
                return;
            FlattenTree(root.left);
            FlattenTree(root.right);
            var rightSubtree = root.right;
            root.right = root.left;
            root.left = null;
            var temp = root;
            while (temp.right != null)
                temp = temp.right;

            temp.right = rightSubtree;
        }

        private static Tree _head { get; set; }
        public static void FlattenTreeFaster(Tree root) // O(n)
        {
            if (root == null)
                return;
            FlattenTreeFaster(root.right);
            FlattenTreeFaster(root.left);
            root.left = null;
            root.right = _head;
            _head = root;
        }
    }
}
