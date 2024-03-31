using System.Text;

namespace IssuesSolving.LinkedLists.Structure
{
    public class LinkedList
    {
        public Node head { get; set; }
        public LinkedList() { head = null; }
        public LinkedList(Node head) { this.head = head; }

        public LinkedList(int[] arr)
        {
            if (arr.Length != 0)
            {
                Node node = new Node(arr[0]);
                head = node;
                for (int i = 1; i < arr.Length; i++)
                {
                    node.next = new Node(arr[i]);
                    node = node.next;
                }
            }
        }

        public static LinkedList Create() 
            => new LinkedList(new Node(4, new Node(8, new Node(1, new Node(6, new Node(2, new Node(5)))))));

        public static LinkedList CreatePalindrome()
            => new LinkedList(new Node(1, new Node(4, new Node(6, new Node(5, new Node(6, new Node(4, new Node(1))))))));

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
