using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Xml;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _3Advanced
{
    internal class Trees3
    {
        /// <summary>
        /// Given a Binary Search Tree A. Check whether there exists a node with value B in the BST.
        /// Problem Constraints
        /// 1 <= Number of nodes in binary tree <= 105
        /// 0 <= B <= 10^6
        /// </summary>
        public static void SearchBST()
        {
            List<int> input = [];
            int B = 0;

            //input = [15, 12, 20, 10, 14, 16, 27, 8, -1, -1, -1, -1, -1, -1, -1];
            //B = 16;//1

            input = [8, 6, 21, 1, 7, -1, -1];
            B = 9;//0

            var A = input.ListToTree<int>();
            var current = A;

            var isfound = false;

            while (current != null)
            {
                if (current.val == B)
                {
                    isfound = true;
                    break;
                }
                else if (B <= current.val)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }

            Console.WriteLine(isfound);
        }

        /// <summary>
        /// You are given a binary tree represented by root A. You need to check if it is a Binary Search Tree or not.
        /// Assume a BST is defined as follows:
        /// 1) The left subtree of a node contains only nodes with keys less than the node's key.
        /// 2) The right subtree of a node contains only nodes with keys greater than the node's key.
        /// 3) Both the left and right subtrees must also be binary search trees.
        /// Problem Constraints
        /// 1 <= Number of nodes in binary tree <= 105
        /// 0 <= node values <= (2^32)-1
        /// </summary>
        public static void ValidateBST()
        {
            List<int> input = [1, 2, 3];//false
            //input = [2, 1, 3];//true
            //input = [2147483647, -1, -1];//true
            input = [3, 2, 4, 1, 3, -1, -1, -1, -1, -1, -1];//false

            var A = input.ListToTree<int>();


            //var isBST = true;
            //MinMaxOfNode(A, ref isBST);

            var isBST = ValidateBST(A,long.MinValue,long.MaxValue);
            Console.WriteLine(isBST);
        }
        private static (int Min, int Max) MinMaxOfNode(TreeNode node, ref bool isBST)//TODO: Not working
        {
            if (node == null)
                return (int.MinValue, int.MaxValue);

            var left = MinMaxOfNode(node.left, ref isBST);
            var right = MinMaxOfNode(node.right, ref isBST);

            if (left.Max > node.val || right.Min < node.val)
            {
                isBST = false;
            }

            return (Math.Min(node.val,Math.Min(left.Min,right.Min)), Math.Max(node.val,Math.Max(left.Max,right.Max)));
        }
        private static bool ValidateBST(TreeNode node, long min,  long max)
        {
            if (node == null) return true;

            if (node.val <= min || node.val >= max)
                return false;

            var left = ValidateBST(node.left, min, node.val);
            var right = ValidateBST(node.right, node.val, max);

            return left && right;
        }
    }
}
