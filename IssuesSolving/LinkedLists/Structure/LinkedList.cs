using System.Text;

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

        public void Print()
        {
            Console.WriteLine();
            var node = head;
            var stringBuilder = new StringBuilder();
            string seporator = " -> ";
            while (node != null)
            {
                stringBuilder.Append(node.data);
                stringBuilder.Append(seporator);
                node = node.next;
            }
            var printText = stringBuilder.ToString();
            printText = printText.Substring(0, printText.Length - seporator.Length);
            Console.WriteLine(printText);
            Console.WriteLine();
        }
    }
}
