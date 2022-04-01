namespace InterviewPreparationKit.LinkedLists.InsertingNodeIntoSortedDoublyLinkedList
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

        static DoublyLinkedListNode SortedInsert(DoublyLinkedListNode head, int data)
        {
            if (head == null)
            {
                return new DoublyLinkedListNode(data);
            }

            var currentNode = head;

            // Find the position to insert the node
            while (data > currentNode.data)
            {
                if (currentNode.next == null)
                {
                    // Insert into tail
                    var tailNode = new DoublyLinkedListNode(data);
                    currentNode.next = tailNode;
                    tailNode.prev = currentNode;
                    
                    return head;
                }
                    
                currentNode = currentNode.next;
            }

            // Insert and update links
            var prevNode = currentNode.prev;
            var newNode = new DoublyLinkedListNode(data)
            {
                next = currentNode,
                prev = prevNode
            };
            currentNode.prev = newNode;

            if (prevNode == null)
            {
                // New node is the head
                return newNode;
            }

            prevNode.next = newNode;

            return head;
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

                int data = Convert.ToInt32(Console.ReadLine());

                DoublyLinkedListNode llist1 = SortedInsert(llist.head, data);

                PrintDoublyLinkedList(llist1, " ");
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
