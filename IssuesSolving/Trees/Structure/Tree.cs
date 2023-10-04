namespace IssuesSolving.Trees.Structure
{
    public class Tree
    {
        public int data { get; set; }
        public Tree left { get; set; }
        public Tree right { get; set; }
        public Tree(int data) { this.data = data; this.left = null; this.right = null; }
        public Tree(int data, Tree left, Tree right) { this.data = data; this.left = left; this.right = right; }

        public static Tree CreateBinarySearchTree()
        {
            return new Tree(16, 
                new Tree(8, 
                    new Tree(3, 
                        new Tree(1), 
                        new Tree(6)), 
                    new Tree(11)), 
                new Tree(22));
        }

        public static Tree CreateBalancedBinaryTree()
        {
            return new Tree(5,
                new Tree(8,
                    new Tree(6, 
                        new Tree(9), 
                        new Tree(4)),
                    new Tree(7)),
                new Tree(1,
                    new Tree(2),
                    new Tree(3, 
                        new Tree(10), 
                        new Tree(4))));
        }
    }
}
