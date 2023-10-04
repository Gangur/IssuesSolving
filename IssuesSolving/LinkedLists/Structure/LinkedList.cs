namespace IssuesSolving.LinkedLists.Structure
{
    public class LinkedList
    {
        public Node head { get; set; }
        public LinkedList() { head = null; }
        public LinkedList(Node head) { this.head = head; }

        public static LinkedList Create() 
        { 
            return new LinkedList(new Node(4, new Node(8, new Node(1, new Node(6, new Node(2, new Node(5))))))); 
        }
    }
}
