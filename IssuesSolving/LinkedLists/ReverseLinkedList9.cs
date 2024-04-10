using IssuesSolving.LinkedLists.Structure;

namespace IssuesSolving.LinkedLists
{
    public static class ReverseLinkedList9
    {
        public static LinkedList Reverse(LinkedList list)
        {
            Node previous = null,
                current = list.head,
                next = null;

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
