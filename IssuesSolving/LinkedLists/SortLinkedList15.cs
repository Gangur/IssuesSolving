using IssuesSolving.LinkedLists.Structure;

namespace IssuesSolving.LinkedLists
{
    public static class SortLinkedList15
    {
        public static LinkedList BubbleSortList(LinkedList list) // O(n²)
        {
            bool sorted = false;
            int swaps = 0;
            var node = list.head;
            while (!sorted)
            {
                if (node.next == null)
                {
                    node = list.head;
                    sorted = swaps < 1;
                    swaps = 0;
                    continue;
                }
                else if (node.data > node.next.data)
                {
                    node.data += node.next.data;
                    node.next.data = node.data - node.next.data;
                    node.data -= node.next.data;
                    swaps++;
                }

                node = node.next;
            }
            return list;
        }


        public static LinkedList MergeSort(LinkedList list) // O(nlogn)
        {
            list.head = mergeSort(list.head);
            return list;
        }

        private static Node mergeSort(Node head)
        {
            if (head == null || head.next == null)
                return head;

            Node slow = head;
            Node fast = head.next;

            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            var headRigth = slow.next;
            slow.next = null;

            head = mergeSort(head);
            headRigth = mergeSort(headRigth);
            return mergeSortedList(head, headRigth);
        }

        private static Node mergeSortedList(Node head1, Node head2)
        {
            var ptr1 = head1;
            var ptr2 = head2;
            Node returnedHead = null, 
                lower = null, 
                tail = null;

            while (ptr1 != null || ptr2 != null)
            {
                if (ptr1 != null && ptr2 != null)
                {
                    if (ptr1.data < ptr2.data)
                    {
                        lower = ptr1;
                        ptr1 = ptr1.next;
                    }
                    else
                    {
                        lower = ptr2;
                        ptr2 = ptr2.next;
                    }
                }
                else if (ptr1 != null)
                {
                    lower = ptr1;
                    ptr1 = ptr1.next;
                }
                else
                {
                    lower = ptr2;
                    ptr2 = ptr2.next;
                }

                if (returnedHead == null)
                {
                    returnedHead = lower;
                    tail = lower;
                }
                else
                {
                    tail.next = lower;
                    tail = tail.next;
                }
            }

            return returnedHead;
        }
    }
}
