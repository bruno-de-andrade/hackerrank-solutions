using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Preparation_Kit.Search.Swap_Nodes__Algo_
{
    class Solution
    {
        class Node
        {
            public Node Left { get; set; }

            public Node Right { get; set; }

            public int Value { get; set; }

            public Node(int value)
            {
                Value = value;
            }
        }

        static Dictionary<int, List<Node>> dicNodesByLevel = new Dictionary<int, List<Node>>();

        static int[][] swapNodes(int[][] indexes, int[] queries)
        {
            int[][] result = new int[queries.Length][];

            addNodesToTree(indexes);

            for (int i = 0; i < queries.Length; i++)
            {
                // Swap all levels multiples of query number
                for (int level = queries[i]; level < dicNodesByLevel.Count(); level+=queries[i])
                {
                    doSwap(level);
                }

                // Traverse the tree begining by root node
                result[i] = traverseTree(dicNodesByLevel[1][0], new List<int>()).ToArray();
            }

            return result;
        }

        static void addNodesToTree(int[][] indexes)
        {
            // Add root node
            dicNodesByLevel.Add(1, new List<Node> { new Node(1) });

            var currentLevelNodes = new List<Node>();
            int currentLevelIndex = 0;
            int currentLevel = 2;

            for (int index = 0; index < indexes.Length; index++)
            {
                var previousNode = dicNodesByLevel[currentLevel - 1][currentLevelIndex];

                // Add left node
                if (indexes[index][0] != -1)
                {
                    var leftNode = new Node(indexes[index][0]);
                    previousNode.Left = leftNode;

                    currentLevelNodes.Add(leftNode);
                }

                // Add right node
                if (indexes[index][1] != -1)
                {
                    var rightNode = new Node(indexes[index][1]);
                    previousNode.Right = rightNode;

                    currentLevelNodes.Add(rightNode);
                }

                currentLevelIndex++;

                // Check if already added child nodes for all previous level nodes
                if (currentLevelIndex == dicNodesByLevel[currentLevel - 1].Count() && currentLevelNodes.Count() > 0)
                {
                    // Add current level nodes to dictionary and go one level depth
                    dicNodesByLevel.Add(currentLevel, currentLevelNodes);
                    currentLevelNodes = new List<Node>();
                    currentLevelIndex = 0;
                    currentLevel++;
                }
            }
        }

        // Swap tree left and right sides
        static void doSwap(int levelToSwap)
        {
            var nodes = dicNodesByLevel[levelToSwap];

            foreach (var node in nodes)
            {
                var nodeAux = node.Left;

                node.Left = node.Right;
                node.Right = nodeAux;
            }
        }

        static List<int> traverseTree(Node currentNode, List<int> traversedNodes)
        {
            // First traverse the whole tree left side
            if (currentNode.Left != null)
            {
                traverseTree(currentNode.Left, traversedNodes);
            }

            // Add current node into the list
            traversedNodes.Add(currentNode.Value);

            // Then traverse right side
            if (currentNode.Right != null)
            {
                traverseTree(currentNode.Right, traversedNodes);
            }

            return traversedNodes;
        }

        static void Main(string[] args)
        {
            var file = new System.IO.StreamReader(@"Search\Swap Nodes [Algo]\testCase1.txt");

            int n = Convert.ToInt32(file.ReadLine());

            int[][] indexes = new int[n][];

            for (int indexesRowItr = 0; indexesRowItr < n; indexesRowItr++)
            {
                indexes[indexesRowItr] = Array.ConvertAll(file.ReadLine().Split(' '), indexesTemp => Convert.ToInt32(indexesTemp));
            }

            int queriesCount = Convert.ToInt32(file.ReadLine());

            int[] queries = new int[queriesCount];

            for (int queriesItr = 0; queriesItr < queriesCount; queriesItr++)
            {
                int queriesItem = Convert.ToInt32(file.ReadLine());
                queries[queriesItr] = queriesItem;
            }

            int[][] result = swapNodes(indexes, queries);

            Console.WriteLine(string.Join("\n", result.Select(x => string.Join(" ", x))));

            Console.ReadKey();
        }
    }
}
