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

        public static Tree CreateOrderdTree()
        {
            return new Tree(1,
                new Tree(2,
                    new Tree(3,
                        new Tree(4),
                        new Tree(5)),
                    new Tree(6)),
                new Tree(7));
        }

        public static Tree CreateTreeForCommonAncestor()
        {
            return new Tree(4,
                new Tree(10,
                    new Tree(5,
                        new Tree(2,
                            new Tree(14),
                            new Tree(9,
                                new Tree(22),
                                new Tree(3))),
                        new Tree(18)),
                    null),
                new Tree(6,
                    new Tree(7,
                        new Tree(1),
                        null),
                    new Tree(13,
                        new Tree(8),
                        new Tree(16))));
        }

        public static Tree CreateBinaryTree() =>
            new Tree(12,
                new Tree(3,
                    new Tree(2),
                    new Tree(5,
                        new Tree(4),
                        new Tree(10,
                            new Tree(8,
                                new Tree(7),
                                null),
                            new Tree(11)))),
                new Tree(23,
                    new Tree(15),
                    new Tree(38)));
    }
}
