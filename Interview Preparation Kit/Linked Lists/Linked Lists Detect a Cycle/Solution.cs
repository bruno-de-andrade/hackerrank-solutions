using System.Collections.Generic;

namespace Interview_Preparation_Kit.Linked_Lists.Linked_Lists_Detect_a_Cycle
{
    class Solution
    {
        class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                }

                this.tail = node;
            }
        }

        bool hasCycle(SinglyLinkedListNode head)
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
