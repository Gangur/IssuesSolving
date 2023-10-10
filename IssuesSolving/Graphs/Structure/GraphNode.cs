namespace IssuesSolving.Graphs.Structure
{
    public class GraphNode
    {
        public int Data { get; init; }

        public HashSet<GraphNode> Nodes { get; set; }

        public GraphNode(int data, HashSet<GraphNode> nodes)
        {
            Data = data;
            Nodes = nodes;
        }

        public GraphNode(int data)
        {
            Data = data;
            Nodes = new HashSet<GraphNode>();
        }

        public override int GetHashCode()
            => Data.GetHashCode();

        public static GraphNode Create()
        {
            var n5 = new GraphNode(5);
            var n8 = new GraphNode(8);
            var n12 = new GraphNode(12);
            var n1 = new GraphNode(1);
            var n14 = new GraphNode(14);
            var n7 = new GraphNode(7);
            var n4 = new GraphNode(4);
            var n16 = new GraphNode(16);

            n5.Nodes.Add(n8);
            n5.Nodes.Add(n12);
            n5.Nodes.Add(n1);

            n8.Nodes.Add(n5);
            n8.Nodes.Add(n12);
            n8.Nodes.Add(n14);
            n8.Nodes.Add(n4);

            n12.Nodes.Add(n5);
            n12.Nodes.Add(n8);
            n12.Nodes.Add(n14);

            n14.Nodes.Add(n12);
            n14.Nodes.Add(n8);
            n14.Nodes.Add(n4);

            n4.Nodes.Add(n14);
            n4.Nodes.Add(n8);

            n1.Nodes.Add(n5);
            n1.Nodes.Add(n7);

            n7.Nodes.Add(n1);
            n7.Nodes.Add(n16);

            return n5;
        }
    }
}
