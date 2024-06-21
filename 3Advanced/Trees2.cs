using Helpers;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing;
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
                if(current.left !=null)
                    queue.Enqueue(current.left);
                if(current.right !=null)
                    queue.Enqueue(current.right);

                if(last == current)
                {
                    result.Add(levelItems);
                    levelItems = new List<int>();
                    if(queue.Count > 0)
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

            var root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);//[3,20,7]]

            root = new TreeNode(1);
            root.left = new TreeNode(6);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3); //[[1,2,3]]

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

        public static void VerticalOrderTraversal()
        {
            List<int> input = [6, 9, 4, -1, -1, 8, -1, -1, 3, -1, -1];
            //input = [3510, 6894, 1818, 975, 9969, 7514, -1, 6530, 5799, 587, 2878, 8936, -1, 803, 1519, 4973, 3851, 2878, 6223, 983, 4565, 5221, -1, -1, 3789, -1, 2541, 620, 4576, -1, 4103, -1, 686, 6487, 4628, 780, -1, 7036, 4608, 1935, -1, -1, 8161, -1, 5504, 1912, -1, 3319, 4358, -1, 5007, -1, 115, 6044, 734, 603, 9533, 6915, -1, 610, 4171, -1, 853, 6176, 8371, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1];

            TreeNode root = input.ListToTree<int>();

            // root = new TreeNode(6);
            //root.left = new TreeNode(3);
            //root.right = new TreeNode(7);
            //root.left.left = new TreeNode(2);
            //root.left.right = new TreeNode(5);
            //root.right.right = new TreeNode(9); //

            var queue = new Queue<TreeNode>();
            var result = new List<List<int>>();
            var distance = new Dictionary<int, int>();//val, distance
            var dict = new Dictionary<int, List<TreeNode>>();//distance, Nodes
            int minLevel = int.MaxValue, maxLevel = int.MinValue;

            queue.Enqueue(root);  
            dict.Add(0,new List<TreeNode> { root});
            distance.Add(root.val,0);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.left != null)
                {
                    distance[current.left.val] = distance[current.val] - 1;
                    queue.Enqueue(current.left);
                    if (!dict.ContainsKey(distance[current.left.val]))
                        dict.Add(distance[current.left.val], (new List<TreeNode>()));

                    dict[distance[current.left.val]].Add(current.left);
                }

                if (current.right != null)
                {
                    distance[current.right.val] = distance[current.val] + 1;
                    queue.Enqueue(current.right);
                    if (!dict.ContainsKey(distance[current.right.val]))
                        dict.Add(distance[current.right.val], (new List<TreeNode>()));
                    dict[distance[current.right.val]].Add(current.right);
                }
            }

            foreach(var kv in dict.OrderBy(k => k.Key))
            {
                var items = kv.Value;
                foreach (var item in items)
                    Console.Write($"{item.val}, ");
                Console.WriteLine();
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

            Console.WriteLine(result?1:0);
        }

        private static int HeightOfNode(TreeNode node, ref bool result)
        {
            if (node == null) return -1;

            int lH = HeightOfNode(node.left,ref result);
            int rH = HeightOfNode(node.right,ref result);

            if (Math.Abs(lH - rH) > 1)
                result &= false;
            return Math.Max(lH, rH) + 1;
        }
    }
}
