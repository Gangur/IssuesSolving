using IssuesSolving.LinkedLists.Structure;

namespace IssuesSolving.LinkedLists
{
    public static class ReverseLinkedList9
    {
        public static LinkedList Reverse(LinkedList list)
        {
            Node next,
                current = list.head,
                previous = null;

            while (current != null)
            {
                next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }

            list.head = previous;
            return list;
        }
    }
}
