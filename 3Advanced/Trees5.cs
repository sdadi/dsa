using System.Drawing;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Security;
using System.Reflection.Metadata;

namespace _3Advanced
{
    internal class Trees5
    {
        /// <summary>
        /// Given a binary tree A. Check whether it is possible to partition the tree to two trees which have equal sum of values after removing exactly one edge on the original tree.
        /// Problem Constraints
        /// 1 <= size of tree <= 100000
        /// 0 <= value of node <= 10^9
        /// </summary>
        public static void EqualTreePartition()
        {
            List<int> input = [5, 3, 7, 4, 6, 5, 6];//true
            //input = [1, 2, 10, -1, -1, 20, 2];//false

            var A = input.ListToTree<int>();

            EqualTreePartition_Recursive(A);
            EqualTreePartition_Iteration(A);
        }
        private static void EqualTreePartition_Iteration(TreeNode A)
        {
            var result = false;
            var current = A;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(current);
            long sum = 0;
            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                sum += current.val;
                if (current.left != null) queue.Enqueue(current.left);
                if (current.right != null) queue.Enqueue(current.right);
            }
            if (sum % 2 != 0)
            {
                result = false;

            }
            else
            {
                current = A;
                queue.Clear();
                var stack = new Stack<TreeNode>();
                long total = 0;
                while (current != null || stack.Count > 0)
                {
                    if (current == null)
                    {
                        current = stack.Pop();
                        total += current.val;
                        if (total == sum / 2)
                        {
                            result = true;
                            break;
                        }
                        current = current.right;
                    }
                    else
                    {
                        stack.Push(current);
                        current = current.left;
                    }
                }
            }
            Console.WriteLine(result);
        }
        private static void EqualTreePartition_Recursive(TreeNode A)
        {

            bool result = false;
            long sum = 0;

            if (A == null)
            {
                Console.WriteLine(result);
                return;
            }

            sum = SumOfTree(A);
            if (sum % 2 != 0)
            {
                result = false;
            }
            else
            {
                CheckSum(A, sum, ref result);
            }
            Console.WriteLine(result);
        }
        private static long SumOfTree(TreeNode root)
        {
            long sum = 0;
            if (root == null)
                return sum;
            sum += root.val;
            sum += SumOfTree(root.left);
            sum += SumOfTree(root.right);
            return sum;
        }
        private static long CheckSum(TreeNode root, long sum, ref bool result)
        {
            if (root == null)
                return 0;
            long total = root.val;
            total += CheckSum(root.left, sum, ref result);
            total += CheckSum(root.right, sum, ref result);

            if (total * 2 == sum)
                result = true;
            return total;
        }


        public static void PathSum()
        {
            List<int> input = [5, 4, 8, 11, -1, 13, 4, 7, 2, -1, -1, -1, 1];
            int B = 22;//1

            input = [5, 4, 8, -11, -1, -13, 4];
            B = -1;//0

            var A = input.ListToTree<int>();

            bool result = CheckSum(A, B);
            Console.WriteLine(result);
        }
        private static bool CheckSum(TreeNode root, int B)
        {
            if (root == null)
                return false;
            if (root.left == null && root.right == null)
                return (B == root.val);
            return CheckSum(root.left, B - root.val) || CheckSum(root.right, B - root.val);
        }
        /// <summary>
        /// Given a binary tree,
        /// Populate each next pointer to point to its next right node.If there is no next right node, the next pointer should be set to NULL.
        /// Initially, all next pointers are set to NULL.
        /// Assume perfect binary tree.
        /// Problem Constraints
        /// 1 <= Number of nodes in binary tree <= 100000
        /// 0 <= node values <= 10^9
        /// </summary>
        public static void NextPointerBinaryTree()
        {
            List<int> input = [1, 2, 3];

            //input = [1, 2, 5, 3, 4, 6, 7];

            var A = input.ListToTreeLink();

            var queue = new Queue<TreeLinkNode>();
            queue.Enqueue(A);
            var last = A;
            var current = A;

            while (queue.Count > 0)
            {
                current = queue.Dequeue();

                if (current.left != null) queue.Enqueue(current.left);
                if (current.right != null) queue.Enqueue(current.right);

                if (current != last)
                {
                    current.next = queue.Peek();
                }
                if (current == last)
                {
                    if (queue.Count > 0)
                        last = queue.Last();
                }
            }

        }

        /// <summary>
        /// Given a Binary Tree A consisting of N integer nodes, you need to find the diameter of the tree.
        /// The diameter of a tree is the number of edges on the longest path between two nodes in the tree.
        /// Problem Constraints
        /// 0 <= N <= 10^5
        /// </summary>
        public static void DiameterOfBST()
        {
            List<int> input = [1, 2, 3, 4, 5, -1, -1];//3
            input = [1, 2, 3, 4, 5, -1, 6];//4

            var root = input.ListToTree<int>();

            int diameter = 0;
            HeightOfNode(root, ref diameter);

            Console.WriteLine(diameter);

        }
        private static int HeightOfNode(TreeNode root, ref int diameter)
        {
            if (root == null) return -1;
            int lH = HeightOfNode(root.left, ref diameter);
            int rH = HeightOfNode(root.right, ref diameter);

            diameter = Math.Max(diameter, (lH + rH + 2));
            //for nodes add +1, for edges add +2//current solution is for counting edges

            return Math.Max(lH, rH) + 1;
        }

        /// <summary>
        /// Given a binary tree A, invert the binary tree and return it.
        /// Inverting refers to making the left child the right child and vice versa.
        /// Problem Constraints
        /// 1 <= size of tree <= 100000
        /// </summary>
        public static void InvertBinaryTree()
        {
            List<int> input = [1, 2, 3];
            //input = [1, 2, 3, 4, 5, 6, 7];
            var A = input.ListToTree<int>();

            InvertBTree(A);
        }
        private static void InvertBTree(TreeNode A)
        {
            if (A == null) return;

            var temp = A.left;
            A.left = A.right;
            A.right = temp;
            InvertBTree(A.left);
            InvertBTree(A.right);
        }

        /// <summary>
        /// Given two binary trees, check if they are equal or not.
        /// Two binary trees are considered equal if they are structurally identical and the nodes have the same value.
        /// Problem Constraints
        /// 1 <= number of nodes <= 10^5
        /// </summary>
        public static void IdenticalBinaryTrees()
        {
            List<int> inputA = [1, 2, 3];
            List<int> inputB = [1, 2, 3];

            //inputA = [1, 2, 3];
            //inputB = [1, 3, 2];

            inputA = [5, 10, -1, -1, -1];
            inputB = [5, -1, -1];

            var A = inputA.ListToTree<int>();
            var B = inputB.ListToTree<int>();

            var result = IdenticalTree(A, B);
            Console.WriteLine(result ? 1 : 0);

            result = IdenticalTreeIteration(A, B);
            Console.WriteLine(result ? 1 : 0);
        }
        private static bool IdenticalTreeIteration(TreeNode A, TreeNode B)
        {
            var qA = new Queue<TreeNode>();
            var qB = new Queue<TreeNode>();
            qA.Enqueue(A);
            qB.Enqueue(B);
            bool result = true;

            var currentA = A;
            var currentB = B;
            var lastA = A;
            var lastB = B;

            while (qA.Count > 0 && qB.Count > 0)
            {
                currentA = qA.Dequeue();
                currentB = qB.Dequeue();
                if (currentA == null && currentB == null)
                    continue;

                if (currentA.val != currentB.val)
                {
                    result = false; break;
                }
                if (currentA.left != null && currentB.left != null)
                {
                    qA.Enqueue(currentA.left);
                    qB.Enqueue(currentB.left);
                }
                else if (currentA.left == null && currentB.left == null)
                {

                }
                else
                {
                    result = false; break;
                }
                if (currentA.right != null && currentB.right != null)
                {
                    qA.Enqueue(currentA.right);
                    qB.Enqueue(currentB.right);
                }
                else if (currentA.right == null && currentB.right == null)
                {

                }
                else
                {
                    result = false; break;
                }

                if (lastA == currentA && qA.Count > 0)
                {
                    lastA = qA.Last();
                }
                if (lastB == currentB && qB.Count > 0)
                {
                    lastB = qB.Last();
                }
            }
            return result;
        }
        private static bool IdenticalTree(TreeNode A, TreeNode B)
        {
            if (A == null && B == null) return true;
            else if (A == null || B == null) return false;

            return (A.val == B.val) && IdenticalTree(A.left, B.left) && IdenticalTree(A.right, B.right);
        }

        /// <summary>
        /// Given a binary tree. Check whether the given tree is a Sum-binary Tree or not.
        /// Sum-binary Tree is a Binary Tree where the value of a every node is equal to sum of the nodes present in its left subtree and right subtree.
        /// An empty tree is Sum-binary Tree and sum of an empty tree can be considered as 0. A leaf node is also considered as SumTree.
        /// Return 1 if it sum-binary tree else return 0.
        /// Problem Constraints
        /// 1 <= length of the array <= 100000
        /// 0 <= node values <= 50
        /// </summary>
        public static void SumBinaryTreeOrNot()
        {

            List<int> input = [26, 10, 3, 4, 6, -1, 3];
            //input = [26, 10, 3, 4, 6, -1, 4];
            input = [10, 4, 2, 2, 2, -1, -1, -1, -1, -1, -1];
            var A = input.ListToTree<int>();

            int sum = NodeSum(A);
            Console.WriteLine(sum <= 0 ? 0 : 1);
        }
        private static int NodeSum(TreeNode root)
        {
            if (root == null)
                return 0;
            int left = NodeSum(root.left);
            int right = NodeSum(root.right);

            if (left == 0 && right == 0)
                return root.val;
            else if (left + right == root.val)
                return 2 * root.val;
            else
                return int.MinValue;
        }
    }
}
