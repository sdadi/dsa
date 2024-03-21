using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamental
{
    internal class Node
    {
        public Node left, right;
        public int data;
        public Node(int data)
        {
            this.data = data;
            left = right = null;
        }
    }
    internal class BST
    {
        internal static void LevelOrder()
        {
            Node root = null;
            int T = Int32.Parse(Console.ReadLine());
            while (T-- > 0)
            {
                int data = Int32.Parse(Console.ReadLine());
                root = insert(root, data);
            }
            PrintLevelOrder(root);
        }
        static void PrintLevelOrder(Node root)
        {
            //Write your code here
            if (root == null)
                return;
            int height = getHeight(root);
            for (int i = 1; i <= height; i++)
            {
                PrintCurrentLevel(root, i);
            }
        }
        static void PrintCurrentLevel(Node node, int level)
        {
            if (node == null)
                return;
            if (level == 1)
            {
                Console.Write(node.data + " ");
            }
            else if (level > 1)
            {
                PrintCurrentLevel(node.left, level - 1);
                PrintCurrentLevel(node.right, level - 1);
            }
        }

        internal static int getHeight(Node root)
        {
            //Write your code here
            if (root == null)
                return 0;

            int leftHeight = 0;
            if(root.left !=null)
                leftHeight = getHeight(root.left)+1;

            int rightHeight = 0;
            if(root.right != null)
                rightHeight = getHeight(root.right)+1;

            return Math.Max(leftHeight, rightHeight);
        }

        internal static Node insert(Node root, int data)
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
                    cur = insert(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = insert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }
        internal static void Run()
        {
            Node root = null;
            int T = Int32.Parse(Console.ReadLine());
            while (T-- > 0)
            {
                int data = Int32.Parse(Console.ReadLine());
                root = insert(root, data);
            }
            int height = getHeight(root);
            Console.WriteLine(height);

        }
    }
}
