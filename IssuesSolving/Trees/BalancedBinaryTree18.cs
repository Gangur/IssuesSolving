using IssuesSolving.Trees.Structure;

namespace IssuesSolving.Trees
{
    public static class BalancedBinaryTree18
    {
        public static bool IsBalancedMySolution(Tree root) // O(n)
        {
            var left = root.left; 
            var right = root.right;

            return checkMirriorBalance(left, right);
        }

        private static bool checkMirriorBalance(Tree left, Tree right)
        {
            if (left == null && right == null)
                return true;
            else if (left != null && right != null)
                return  checkMirriorBalance(left.right, right.left) & 
                        checkMirriorBalance(left.left, right.right);
            else return false;
        }
    }
}
