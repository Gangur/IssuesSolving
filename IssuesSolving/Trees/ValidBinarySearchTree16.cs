using IssuesSolving.Trees.Structure;
using System.ComponentModel.DataAnnotations;

namespace IssuesSolving.Trees
{
    public static class ValidBinarySearchTree16
    {
        public static bool IsBinarySearchTree(Tree root, 
            int min = int.MinValue, 
            int max = int.MaxValue)
        {
            if (root == null)
                return true;
            else if (root.data <= min || root.data >= max)
                return false;
            else
                return IsBinarySearchTree(root.left, min, root.data) &
                       IsBinarySearchTree(root.right, root.data, max);
        }
    }
}
