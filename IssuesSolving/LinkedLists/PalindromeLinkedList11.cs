using IssuesSolving.LinkedLists.Structure;

namespace IssuesSolving.LinkedLists
{
    public static class PalindromeLinkedList11
    {
        public static bool Check(LinkedList list)
        {
            Node slow = list.head,
                fast = list.head;

            while (fast != null)
            {
                slow = slow.next;
                fast = fast.next?.next;
            }

            slow = Revert(slow);
            fast = list.head;

            while (slow != null)
            {
                if (slow.data != fast.data)
                    return false;

                slow = slow.next;
                fast = fast.next;
            }

            return true;
        }

        private static Node Revert(Node node)
        {
            Node next,
                current = node,
                previous = null;

            while (current != null)
            {
                next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }

            return previous;
        }
    }
}
