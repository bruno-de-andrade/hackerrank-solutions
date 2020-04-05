using System;
using System.Collections.Generic;

namespace Interview_Preparation_Kit.Linked_Lists.Find_Merge_Point_of_Two_Lists
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

        static int findMergeNode(SinglyLinkedListNode curNode1, SinglyLinkedListNode curNode2)
        {
            var head = curNode1;

            // Find list1 tail node
            while (curNode1.next != null)
            {
                curNode1 = curNode1.next;
            }

            // Merge the two lists
            curNode1.next = curNode2;

            // Find the node that starts the cycle and return its data
            return getStartCycleNode(head).data;
        }

        static SinglyLinkedListNode getStartCycleNode(SinglyLinkedListNode head)
        {
            var visitedNodes = new HashSet<SinglyLinkedListNode>();
            var currentNode = head;

            while (currentNode != null)
            {
                // Node was visited previously, cycle exists.
                if (visitedNodes.Contains(currentNode))
                {
                    return currentNode;
                }

                visitedNodes.Add(currentNode);
                currentNode = currentNode.next;
            }

            return null;
        }

        static void Main(string[] args)
        {
            var file = new System.IO.StreamReader(@"Linked Lists\Find Merge Point of Two Lists\testCase1.txt");

            int tests = Convert.ToInt32(file.ReadLine());

            for (int testsItr = 0; testsItr < tests; testsItr++)
            {
                int index = Convert.ToInt32(file.ReadLine());

                SinglyLinkedList llist1 = new SinglyLinkedList();

                int llist1Count = Convert.ToInt32(file.ReadLine());

                for (int i = 0; i < llist1Count; i++)
                {
                    int llist1Item = Convert.ToInt32(file.ReadLine());
                    llist1.InsertNode(llist1Item);
                }

                SinglyLinkedList llist2 = new SinglyLinkedList();

                int llist2Count = Convert.ToInt32(file.ReadLine());

                for (int i = 0; i < llist2Count; i++)
                {
                    int llist2Item = Convert.ToInt32(file.ReadLine());
                    llist2.InsertNode(llist2Item);
                }

                SinglyLinkedListNode ptr1 = llist1.head;
                SinglyLinkedListNode ptr2 = llist2.head;

                for (int i = 0; i < llist1Count; i++)
                {
                    if (i < index)
                    {
                        ptr1 = ptr1.next;
                    }
                }

                for (int i = 0; i < llist2Count; i++)
                {
                    if (i != llist2Count - 1)
                    {
                        ptr2 = ptr2.next;
                    }
                }

                ptr2.next = ptr1;

                int result = findMergeNode(llist1.head, llist2.head);

                Console.WriteLine(result);
            }

            file.Close();

            Console.ReadKey();
        }
    }
}
