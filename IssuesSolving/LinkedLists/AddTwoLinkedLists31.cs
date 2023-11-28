using IssuesSolving.LinkedLists.Structure;

namespace IssuesSolving.LinkedLists
{
    public static class AddTwoLinkedLists31
    {
        public static LinkedList addTwoLinkedLists(LinkedList list1, LinkedList list2)
        {
            var node1 = list1.head; 
            var node2 = list2.head;

            var result = new Node((node1?.data ?? 0) + (node2?.data ?? 0));
            int carry = result.data / 10;
            result.data %= 10;

            node1 = node1?.next;
            node2 = node2?.next;
            var node = result;

            while (node1 != null || node2 != null || carry > 0)
            {
                node.next = new Node((node1?.data ?? 0) + (node2?.data ?? 0) + carry);
                carry = node.next.data / 10;
                node.next.data %= 10;

                node1 = node1?.next;
                node2 = node2?.next;
                node = node.next;
            }

            return new LinkedList(result);
        }
    }
}
