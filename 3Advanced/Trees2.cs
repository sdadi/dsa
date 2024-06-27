using Helpers;
using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Xml.XPath;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _3Advanced
{
    internal class Trees2
    {
        /// <summary>
        /// Given a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).
        /// Problem Constraints
        /// 1 <= number of nodes <= 10^5
        /// </summary>
        public static void LevelOrder()
        {
            var root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);//[[3],[9,20],[15,7]]

            root = new TreeNode(1);
            root.left = new TreeNode(6);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3); //[[1],[6, 2],[3]]

            var result = new List<List<int>>();
            if (root == null)
                return;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var last = root;
            var levelItems = new List<int>();
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                levelItems.Add(current.val);
                if (current.left != null)
                    queue.Enqueue(current.left);
                if (current.right != null)
                    queue.Enqueue(current.right);

                if (last == current)
                {
                    result.Add(levelItems);
                    levelItems = new List<int>();
                    if (queue.Count > 0)
                        last = queue.Last();
                }
            }

            foreach (var level in result)
                level.PrintArray();
        }

        /// <summary>
        /// Given a binary tree of integers denoted by root A. Return an array of integers representing the right view of the Binary tree.
        /// Right view of a Binary Tree is a set of nodes visible when the tree is visited from Right side.
        /// Problem Constraints
        /// 1 <= Number of nodes in binary tree <= 100000
        /// 0 <= node values <= 10^9
        /// </summary>
        public static void RightViewofBinaryTree()
        {
            List<int> input = [3, 9, 20, -1, -1, 15, 7];
            input = [1, 6, 2, -1, -1, 3, -1];

            var root = input.ListToTree<int>();

            var result = new List<int>();
            if (root == null)
                return;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var last = root;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.left != null)
                    queue.Enqueue(current.left);
                if (current.right != null)
                    queue.Enqueue(current.right);

                if (last == current)
                {
                    result.Add(current.val);
                    if (queue.Count > 0)
                        last = queue.Last();
                }
            }
            result.PrintArray();
        }

        class QueuePair
        {
            public int distance;
            public TreeNode node;
            public QueuePair(int dist, TreeNode n)
            {
                distance = dist;
                node = n;
            }
        }
        public static void VerticalOrderTraversal()
        {

            List<int> input = [];
            //input = [6,3,7,2,5,-1,9];
            input = [6, 9, 4, -1, -1, 8, -1, -1, 3];
            //input = [3510, 6894, 1818, 975, 9969, 7514, -1, 6530, 5799, 587, 2878, 8936, -1, 803, 1519, 4973, 3851, 2878, 6223, 983, 4565, 5221, -1, -1, 3789, -1, 2541, 620, 4576, -1, 4103, -1, 686, 6487, 4628, 780, -1, 7036, 4608, 1935, -1, -1, 8161, -1, 5504, 1912, -1, 3319, 4358, -1, 5007, -1, 115, 6044, 734, 603, 9533, 6915, -1, 610, 4171, -1, 853, 6176, 8371, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1];

            TreeNode root = input.ListToTree<int>();

            var queue = new Queue<QueuePair>();
            var result = new List<List<int>>();
            var dict = new Dictionary<int, List<int>>();//distance, Nodes


            queue.Enqueue(new QueuePair(0, root));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (dict.ContainsKey(current.distance))
                    dict[current.distance].Add(current.node.val);
                else
                {
                    dict.Add(current.distance, new List<int> { current.node.val });
                }

                if (current.node.left != null)
                {
                    queue.Enqueue(new QueuePair(current.distance - 1, current.node.left));
                }

                if (current.node.right != null)
                {
                    queue.Enqueue(new QueuePair(current.distance + 1, current.node.right));
                }
            }

            foreach (var kv in dict.OrderBy(k => k.Key))
            {
                kv.Value.PrintArray();
            }
        }


        /// <summary>
        /// Given a root of binary tree A, determine if it is height-balanced.
        /// A height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
        /// Problem Constraints
        /// 1 <= size of tree <= 100000
        /// </summary>
        public static void IsBalancedBinaryTree()
        {
            List<int> input = [];
            //input = [1, 2, 3,-1,-1,-1,-1];//1
            //input = [1, 2, -1, 3, -1,-1,-1];//0
            input = [7, 15, 11, 6, 13, -1, 22, 21, 19, 3, 14, 20, -1, 1, -1, 23, -1, -1, -1, 9, -1, 4, 27, -1, 5, -1, 10, -1, 2, 8, 25, 18, -1, -1, 16, -1, 26, 12, -1, -1, -1, 17, -1, -1, -1, -1, -1, 24, -1, -1, -1, -1, -1, -1, -1];//
            var root = input.ListToTree<int>();

            bool result = true;
            int h = HeightOfNode(root, ref result);

            Console.WriteLine(result ? 1 : 0);
        }

        private static int HeightOfNode(TreeNode node, ref bool result)
        {
            if (node == null) return -1;

            int lH = HeightOfNode(node.left, ref result);
            int rH = HeightOfNode(node.right, ref result);

            if (Math.Abs(lH - rH) > 1)
                result &= false;
            return Math.Max(lH, rH) + 1;
        }

        /// <summary>
        /// Given a binary tree of integers denoted by root A. Return an array of integers representing the top view of the Binary tree.
        /// The top view of a Binary Tree is a set of nodes visible when the tree is visited from the top.
        /// Return the nodes in any order.
        /// Problem Constraints
        /// 1 <= Number of nodes in binary tree <= 100000
        /// 0 <= node values <= 10^9
        /// </summary>
        public static void TopViewOfBinaryTree()
        {
            List<int> input = [];
            input = [1, 2, 3, 4, 5, 6, 7, 8, -1];// [1, 2, 4, 8, 3, 7]

            //input = [1, 2, 3 - 1, 4, -1, -1, -1, 5];// [1, 2, 3]

            var queue = new Queue<QueuePair>();
            var result = new List<int>();
            var dict = new Dictionary<int, List<int>>();//distance, node.val

            var A = input.ListToTree<int>();

            queue.Enqueue(new QueuePair(0, A));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (!dict.ContainsKey(current.distance))
                    dict.Add(current.distance, new List<int>());
                dict[current.distance].Add(current.node.val);

                if (current.node.left != null)
                {
                    queue.Enqueue(new QueuePair(current.distance - 1, current.node.left));
                }
                if (current.node.right != null)
                {
                    queue.Enqueue(new QueuePair(current.distance + 1, current.node.right));
                }
            }
            foreach (var kv in dict.OrderBy(k => k.Key))
            {
                result.Add(kv.Value[0]);
            }
            result.PrintArray();
        }

        /// <summary>
        /// Given the root node of a Binary Tree denoted by A. You have to Serialize the given Binary Tree in the described format.
        /// Serialize means encode it into a integer array denoting the Level Order Traversal of the given Binary Tree.
        /// NOTE:
        /// In the array, the NULL/None child is denoted by -1.
        /// For more clarification check the Example Input.
        /// Problem Constraints
        /// 1 <= number of nodes <= 10^5
        /// </summary>
        public static void SerializeBinaryTree()
        {
            List<int> input = [1, 2, 3, 4, 5, -1, -1, -1, -1, -1, -1];
            input = [1, 2, 3, 4, 5, -1, 6, -1, -1, -1, -1, -1, -1];

            var A = input.ListToTree<int>();

            var result = new List<int>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(A);
            var last = A;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                result.Add(current == null ? -1 : current.val);

                if (current != null)
                {
                    queue.Enqueue(current.left);
                    queue.Enqueue(current.right);
                }
            }

            result.PrintArray();
        }

        /// <summary>
        /// You are given an integer array A denoting the Level Order Traversal of the Binary Tree.
        /// You have to Deserialize the given Traversal in the Binary Tree and return the root of the Binary Tree.
        /// NOTE:
        /// In the array, the NULL/None child is denoted by -1.
        /// For more clarification check the Example Input.
        /// Problem Constraints
        /// 1 <= number of nodes <= 10^5
        /// -1 <= A[i] <= 10^5
        /// </summary>
        public static void DeserializeBinaryTree()
        {
            List<int> A = [];
            //A = [1, 2, 3, 4, 5, -1, -1, -1, -1, -1, -1];
            //A = [1, 2, 3, 4, 5, -1, 6, -1, -1, -1, -1, -1, -1];
            //A = [1, 2, 4, -1, 3, -1, 5, 7, -1, -1, 6, -1, 8, -1, -1, -1, -1];
            A = [1, -1, 2, -1, -1, 3, -1, -1, -1, -1, -1];


            var root = new TreeNode(A[0]);
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int i = 1;

            while (queue.Count > 0 && i < A.Count)
            {
                var current = queue.Dequeue();
                if (current == null)
                    continue;

                current.left = A[i] == -1 ? null : new TreeNode(A[i]);
                queue.Enqueue(current.left);
                i++;

                current.right = A[i] == -1 ? null : new TreeNode(A[i]);
                queue.Enqueue(current.right);
                i++;
            }

            Console.WriteLine(root.TreeToLevelOrderString());
        }

        /// <summary>
        /// Given a binary tree, return the zigzag level order traversal of its nodes values. 
        /// (ie, from left to right, then right to left for the next level and alternate between).
        /// Problem Constraints
        /// 1 <= number of nodes <= 10^5
        /// </summary>
        public static void ZigZagLevelOrderBT()
        {
            List<int> input = [1, 2, 4, -1, 3, -1, 5, 7, -1, -1, 6, -1, 8, -1, -1, -1, -1];
            TreeNode A = input.ListToTree<int>();

            var result = new List<List<int>>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(A);
            var last = A;
            var levelItems = new List<int>();
            bool l2r = true;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                levelItems.Add(current.val);


                if (current.left != null)
                    queue.Enqueue(current.left);
                if (current.right != null)
                {
                    queue.Enqueue(current.right);
                }

                if (last == current && queue.Count > 0)
                {
                    if (!l2r)
                        levelItems.Reverse();
                    result.Add(levelItems);
                    levelItems = new List<int>();
                    last = queue.Last();
                    l2r = !l2r;
                }
            }
            if (levelItems.Any())
            {
                if (!l2r)
                    levelItems.Reverse();
                result.Add(levelItems);
            }
            foreach (var level in result)
                level.PrintArray();
        }
    }
}
