namespace IssuesSolving.LinkedLists.Structure
{
    public class Node
    {
        public int data { get; set; }
        public Node next { get; set; }
        public Node(int data) { this.data = data; next = default; }
        public Node(int data, Node next) { this.data = data; this.next = next; }
    }
}
