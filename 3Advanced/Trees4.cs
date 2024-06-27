using Helpers;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace _3Advanced
{
    internal class Trees4
    {
        /// <summary>
        /// Given a binary tree, return the inorder traversal of its nodes' values.
        /// NOTE: Using recursion and stack are not allowed.
        /// Problem Constraints
        /// 1 <= number of nodes <= 10^5
        /// </summary>
        public static void MorrisInorderTraversal()
        {
            List<int> input = [1, -1, 2, -1, -1, 3, -1, -1, -1, -1, -1]; //[1,3,2]
            //input = [1, 6, 2, -1, -1, 3, -1];// [6,1,3,2]

            var A = input.ListToTree<int>();

            var result = new List<int>();
            var current = A;

            while (current != null)
            {

                if (current.left == null)
                {
                    result.Add(current.val);
                    current = current.right;
                }
                else
                {
                    var pre = current.left;
                    while (pre.right != null && pre.right != current)
                    {
                        pre = pre.right;
                    }
                    if (pre.right == null)
                    {
                        pre.right = current;
                        current = current.left;
                    }
                    else
                    {
                        pre.right = null;
                        result.Add(current.val);
                        current = current.right;
                    }
                }
            }
            result.PrintArray();
        }


        /// <summary>
        /// Given a binary search tree represented by root A, write a function to find the Bth smallest element in the tree.
        /// Problem Constraints
        /// 1 <= Number of nodes in binary tree <= 100000
        /// 0 <= node values <= 10^9
        /// </summary>
        public static void KthSmallestElementInBST()
        {
            List<int> input = [2, 1, 3];
            int B = 2;//[2]
            input = [3, 2, -1, 1, -1];// [1]
            B = 1;

            var A = input.ListToTree<int>();

            var result = new List<int>();
            var stack = new Stack<TreeNode>();
            var current = A;

            while (current != null || stack.Count > 0)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                else
                {
                    current = stack.Pop();
                    result.Add(current.val);
                    current = current.right;
                    if (result.Count == B)
                        break;
                }
            }

            Console.WriteLine(result.Last());
        }

        /// <summary>
        /// Two elements of a Binary Search Tree (BST), represented by root A are swapped by mistake. 
        /// Tell us the 2 values, when swapped, will restore the Binary Search Tree (BST).
        /// A solution using O(n) space is pretty straightforward.Could you devise a constant space solution?
        /// Note: The 2 values must be returned in ascending order
        /// Problem Constraints
        /// 1 <= size of tree <= 100000
        /// </summary>
        public static void RecoverBST()
        {
            List<int> input = [1, 2, 3];//[2,1]
            //input = [2, 3, 1]; //[3,1]
            //input = [344, 162, 345, 152, 181, -1, -1, 106, 161, 173, 261, 92, 133, 157, -1, 165, 178, 256, 329, 86, 104, 108, 137, 154, 160, 163, 171, 174, 179, 210, 258, 265, 335, 83, 87, 102, 105, 107, 114, 134, 147, 153, 155, 159, -1, -1, 164, 170, 172, -1, 176, -1, 180, 182, 221, 257, 259, 264, 311, 334, 337, 80, 85, -1, 90, 96, 103, -1, -1, -1, -1, 109, 132, -1, 135, 144, 148, -1, -1, -1, 156, 158, -1, -1, -1, 167, -1, -1, -1, 175, 177, -1, -1, -1, 202, 219, 223, -1, -1, -1, 260, 262, -1, 278, 314, 331, -1, 336, 339, 79, 82, 84, -1, 88, 91, 93, 97, -1, -1, -1, 113, 117, -1, -1, 136, 139, 145, -1, 150, -1, -1, -1, -1, 166, 168, -1, -1, -1, -1, 186, 208, 214, 220, 222, 245, -1, -1, -1, 263, 269, 304, 313, 319, 330, 333, -1, -1, 338, 341, -1, -1, 81, -1, -1, -1, -1, 89, -1, -1, -1, 95, -1, 98, 110, -1, 115, 125, -1, -1, 138, 141, -1, 146, 149, 151, -1, -1, -1, 169, 185, 193, 203, 209, 213, 218, -1, -1, -1, -1, 241, 247, -1, -1, 268, 276, 297, 307, 312, -1, 317, 328, -1, -1, 332, -1, -1, -1, 340, 343, -1, -1, -1, -1, 94, -1, -1, 99, -1, 111, 116, -1, 120, 128, -1, -1, 140, 142, -1, -1, -1, -1, -1, -1, -1, -1, 184, -1, 192, 198, -1, 206, -1, -1, 211, -1, 215, -1, 224, 244, 246, 250, 267, -1, 275, 277, 291, 299, 306, 308, -1, -1, 316, 318, 320, -1, -1, -1, -1, -1, 342, -1, -1, -1, -1, 101, -1, 112, -1, -1, 118, 122, 126, 130, -1, -1, -1, 143, 183, -1, 189, -1, 195, 200, 205, 207, -1, 212, -1, 217, -1, 227, 243, -1, -1, -1, 248, 251, 266, -1, 274, -1, -1, -1, 281, 295, 298, 301, 305, -1, -1, 309, 315, -1, -1, -1, -1, 323, -1, -1, 100, -1, -1, -1, -1, 119, 121, 124, -1, 127, 129, 131, -1, -1, -1, -1, 187, 190, 194, 196, 199, 201, 204, -1, -1, -1, -1, -1, 216, -1, 226, 239, 242, -1, -1, 249, -1, 253, -1, -1, 270, -1, 280, 290, 294, 296, -1, -1, 300, 302, -1, -1, -1, 310, -1, -1, 321, 325, -1, -1, -1, -1, -1, -1, 123, -1, -1, -1, -1, -1, -1, -1, -1, 188, -1, 191, -1, -1, -1, 197, -1, -1, -1, -1, -1, -1, -1, -1, 225, -1, 231, 240, -1, -1, -1, -1, 252, 254, -1, 272, 279, -1, 283, -1, 292, -1, -1, -1, -1, -1, -1, 303, -1, -1, -1, 322, 324, 327, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 228, 232, -1, -1, -1, -1, -1, 255, 271, 273, -1, -1, 282, 284, -1, 293, -1, -1, -1, -1, -1, -1, 326, -1, -1, 229, -1, 238, -1, -1, -1, -1, -1, -1, -1, -1, -1, 285, -1, -1, -1, -1, -1, 230, 237, -1, -1, 287, -1, -1, 235, -1, 286, 288, 233, 236, -1, -1, -1, 289, -1, 234, -1, -1, -1, -1, -1, -1];//[115, 116]

            var A = input.ListToTree<int>();

            var inOrder = new List<int>();
            var result = new List<int>();
            var current = A;

            while (current != null)
            {
                if (current.left == null)
                {
                    if (inOrder.Count > 0 && current.val < inOrder.Last())
                    {
                        if (result.Count == 0)
                        {
                            result.Add(current.val);
                            result.Add(inOrder.Last());
                        }
                        else
                        {
                            result[0] = current.val;
                        }
                    }
                    inOrder.Add(current.val);
                    current = current.right;
                }
                else
                {
                    var pre = current.left;
                    while (pre.right != null && pre.right != current)
                    {
                        pre = pre.right;
                    }
                    if (pre.right == null)
                    {
                        pre.right = current;
                        current = current.left;
                    }
                    else
                    {
                        pre.right = null;
                        if (inOrder.Count > 0 && current.val < inOrder.Last())
                        {
                            if (result.Count == 0)
                            {
                                result.Add(current.val);
                                result.Add(inOrder.Last());
                            }
                            else
                            {
                                result[0] = current.val;
                            }
                        }
                        inOrder.Add(current.val);
                        current = current.right;
                    }
                }
            }
            result.PrintArray();
        }

        /// <summary>
        /// Given a binary search tree.
        /// Return the distance between two nodes with given two keys B and C.It may be assumed that both keys exist in BST.
        /// NOTE: Distance between two nodes is number of edges between them.
        /// Problem Constraints
        /// 1 <= Number of nodes in binary tree <= 1000000
        /// 0 <= node values <= 10^9
        /// </summary>
        public static void DistanceBetween2NodesInBST()
        {
            List<int> input = [5, 2, 8, 1, 4, 6, 11];
            int B = 2, C = 11;//3

            //input = [6, 2, 9, 1, 4, 7, 10];
            //B = 2; C = 6;//1

            //input = [32, 25, 46, 17, 27, 40, 49, 9, -1, -1, -1, -1, -1, -1, -1, -1, -1];
            //B = 32; C = 9;//3

            input = [23, 16, 38, 8, 18, 32, 40];
            B = 18; C = 40;//4

            var A = input.ListToTree<int>();

            if (C < B)
            {
                B = B + C;
                C = B - C;
                B = B - C;
            }
            int dist1 = 0, dist2 = 0;
            var current = A;
            var lca = A;

            while (current != null)
            {
                if (current.val > B && current.val > C)
                    current = current.left;
                else if (current.val < B && current.val < C)
                    current = current.right;
                else if (B <= current.val && current.val <= C)
                {
                    lca = current;
                    break;
                }
            }
            current = lca;
            while (current != null)
            {
                if (current.val == B)
                    break;
                current = (current.val < B) ? current.right : current.left;
                dist1++;
            }
            current = lca;
            while (current != null)
            {
                if (current.val == C)
                    break;
                current = (current.val < C) ? current.right : current.left;
                dist2++;
            }
            Console.WriteLine(dist1 + dist2);
        }

        /// <summary>
        /// Given two BST's A and B, return the (sum of all common nodes in both A and B) % (109 +7) .
        /// In case there is no common node, return 0.
        /// NOTE:
        /// Try to do it one pass through the trees.
        /// Problem Constraints
        /// 1 <= Number of nodes in the tree A and B <= 10^5
        /// 1 <= Node values <= 10^6
        /// </summary>
        public static void SumOfCommonNodesInBST()
        {
            List<int> x = [5, 2, 8, -1, 3, -1, 15, -1, -1, -1, -1, -1, -1, 9, -1];
            List<int> y = [7, 1, 10, -1, 2, -1, 15, -1, -1, -1, -1, -1, -1, 11, -1];

            //x = [7, 1, 10, -1, 2, -1, 15, -1, -1, -1, -1, -1, -1, 11, -1];
            //y = [7, 1, 10, -1, 2, -1, 15, -1, -1, -1, -1, -1, -1, 11, -1];

            var A = x.ListToTree<int>();
            var B = y.ListToTree<int>();

            int mod = 1000000007;

            //if (A == null || B == null)
            //    return 0;
            long result = 0;
            var stack = new Stack<TreeNode>();
            var left = new List<int>();
            var right = new List<int>();
            var current = A;

            while (current != null || stack.Count > 0)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                else
                {
                    current = stack.Pop();
                    left.Add(current.val);
                    current = current.right;
                }
            }

            current = B;

            while (current != null || stack.Count > 0)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                else
                {
                    current = stack.Pop();
                    right.Add(current.val);
                    current = current.right;
                }
            }

            int l = 0, r = 0;
            while (l < left.Count && r < right.Count)
            {
                if (left[l] == right[r])
                {
                    result = (result % mod + left[l] % mod) % mod;
                    l++;
                    r++;
                }
                else if (left[l] < right[r])
                {
                    l++;
                }
                else
                    r++;
            }
            int ans = (int)(result % mod);
            Console.WriteLine(ans);
        }
    }
}
