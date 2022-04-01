namespace InterviewPreparationKit.Trees.TreeHeightOfABinaryTree
{
    class Solution
    {
        class Node
        {
            public Node left;
            public Node right;
            public int data;

            public Node(int data)
            {
                this.data = data;
                left = null;
                right = null;
            }
        }

        static int Height(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftHeight = 0;
            int rightHeight = 0;

            if (root.left != null)
            {
                leftHeight = 1 + Height(root.left);
            }

            if (root.right != null)
            {
                rightHeight = 1 + Height(root.right);
            }

            return leftHeight > rightHeight ? leftHeight : rightHeight;
        }

        static Node Insert(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data <= root.data)
                {
                    cur = Insert(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = Insert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }

        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            string[] treeValues = Console.ReadLine().Split(' ');

            Node root = null;

            for (int i = 0; i < t; i++)
            {
                int data = Convert.ToInt32(treeValues[i]);
                root = Insert(root, data);
            }

            int treeHeight = Height(root);

            Console.WriteLine(treeHeight);

            Console.ReadKey();
        }
    }
}
