using IssuesSolving.Trees.Structure;

namespace IssuesSolving.Trees
{
    public static class LowestCommonAncestor28
    {
        public static Tree? LowestCommonAncestor(Tree root, int num1, int num2)
        {
            var pathNum1 = new List<Tree>();
            var pathNum2 = new List<Tree>();

            if (!getPath(root, ref pathNum1, num1) || !getPath(root, ref pathNum2, num2))
                return null;

            int minLength = Math.Min(pathNum1.Count, pathNum2.Count),
                i = 0;

            while (i < minLength)
                if (pathNum1[i] == pathNum2[i])
                    i++;
                else 
                    break;

            return pathNum1[i - 1];
        }

        private static bool getPath(Tree root, ref List<Tree> list, int target)
        {
            if (root == null) 
                return false;

            list.Add(root);

            if (root.data == target) 
                return true;

            if (getPath(root.left, ref list, target) || 
                getPath(root.right, ref list, target))
                return true;

            list.Remove(root);
            return false;
        }
    }
}
