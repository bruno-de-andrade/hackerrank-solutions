namespace InterviewPreparationKit.LinkedLists.LinkedListsDetectCycle
{
    class Solution
    {
        class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                data = nodeData;
                next = null;
            }
        }

        class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                head = null;
                tail = null;
            }

            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (head == null)
                {
                    head = node;
                }
                else
                {
                    tail.next = node;
                }

                tail = node;
            }
        }

        bool HasCycle(SinglyLinkedListNode head)
        {
            var visitedNodes = new HashSet<SinglyLinkedListNode>();
            var currentNode = head;

            while (currentNode != null)
            {
                // Node was visited previously, cycle exists.
                if (visitedNodes.Contains(currentNode))
                {
                    return true;
                }

                visitedNodes.Add(currentNode);
                currentNode = currentNode.next;
            }

            return false;
        }
    }
}
