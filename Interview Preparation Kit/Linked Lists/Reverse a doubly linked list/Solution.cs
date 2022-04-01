namespace InterviewPreparationKit.LinkedLists.ReverseDoublyLinkedList
{
    class Solution
    {
        class DoublyLinkedListNode
        {
            public int data;
            public DoublyLinkedListNode next;
            public DoublyLinkedListNode prev;

            public DoublyLinkedListNode(int nodeData)
            {
                data = nodeData;
                next = null;
                prev = null;
            }
        }

        class DoublyLinkedList
        {
            public DoublyLinkedListNode head;
            public DoublyLinkedListNode tail;

            public DoublyLinkedList()
            {
                head = null;
                tail = null;
            }

            public void InsertNode(int nodeData)
            {
                DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);

                if (head == null)
                {
                    head = node;
                }
                else
                {
                    tail.next = node;
                    node.prev = tail;
                }

                tail = node;
            }
        }

        static void PrintDoublyLinkedList(DoublyLinkedListNode node, string sep)
        {
            while (node != null)
            {
                Console.Write(node.data);

                node = node.next;

                if (node != null)
                {
                    Console.Write(sep);
                }
            }
        }

        static DoublyLinkedListNode Reverse(DoublyLinkedListNode currentNode)
        {
            while (true)
            {
                var next = currentNode.next;

                // Invert the links
                currentNode.next = currentNode.prev;
                currentNode.prev = next;

                if (next == null)
                {
                    // Return the tail as the new head
                    return currentNode;
                }

                currentNode = next;
            }
        }

        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                DoublyLinkedList llist = new DoublyLinkedList();

                int llistCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llistCount; i++)
                {
                    int llistItem = Convert.ToInt32(Console.ReadLine());
                    llist.InsertNode(llistItem);
                }

                DoublyLinkedListNode llist1 = Reverse(llist.head);

                PrintDoublyLinkedList(llist1, " ");
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
