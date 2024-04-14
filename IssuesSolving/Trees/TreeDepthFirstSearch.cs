using IssuesSolving.Trees.Structure;

namespace IssuesSolving.Trees
{
    public static class TreeDepthFirstSearch
    {
        public static void Preorder(Tree root)
        {
            if (root == null)
                return;

            Console.Write(root.data + " ");
            Preorder(root.left);
            Preorder(root.right);
        }

        public static void Inorder(Tree root)
        {
            if (root == null)
                return;

            Inorder(root.left);
            Console.Write(root.data + " ");
            Inorder(root.right);
        }

        public static void Postorder(Tree root)
        {
            if (root == null)
                return;

            Postorder(root.left);
            Postorder(root.right);
            Console.Write(root.data + " ");
        }
    }
}
