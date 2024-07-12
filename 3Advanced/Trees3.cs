using Helpers;

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
            //input = [3, 2, 4, 1, 3, -1, -1, -1, -1, -1, -1];//false

            var A = input.ListToTree<int>();


            var isBST = true;
            MinMaxOfNode(A, ref isBST);
            Console.WriteLine(isBST);

            isBST = ValidateBST(A, long.MinValue, long.MaxValue);
            Console.WriteLine(isBST);
        }
        private static (long Max, long Min) MinMaxOfNode(TreeNode node, ref bool isBST)//TODO: Not working
        {
            if (node == null)
                return (long.MinValue, long.MaxValue);

            var left = MinMaxOfNode(node.left, ref isBST);
            var right = MinMaxOfNode(node.right, ref isBST);

            if (node.val <= left.Max || node.val >= right.Min)
            {
                isBST = false;
            }

            return (Math.Max((long)node.val, Math.Max(left.Max, right.Max)), Math.Min((long)node.val, Math.Min(left.Min, right.Min)));
        }
        private static bool ValidateBST(TreeNode node, long min, long max)
        {
            if (node == null) return true;

            if (node.val <= min || node.val >= max)
                return false;

            var left = ValidateBST(node.left, min, node.val);
            var right = ValidateBST(node.right, node.val, max);

            return left && right;
        }

        /// <summary>
        /// Given an array where elements are sorted in ascending order, convert it to a height Balanced Binary Search Tree (BBST).
        /// Balanced tree : a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
        /// Problem Constraints
        /// 1 <= length of array <= 100000
        /// </summary>
        public static void SortedArrayToBST()
        {
            List<int> A = [1, 2, 3];
            A = [1, 2, 3, 5, 10];

            var root = BalancedBST(A, 0, A.Count - 1);

            var output = new List<int>();
            var stack = new Stack<TreeNode>();
            var current = root;

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
                    output.Add(current.val);
                    current = current.right;
                }
            }
            output.PrintArray();
        }
        private static TreeNode BalancedBST(List<int> A, int left, int right)
        {
            if (left > right)
                return null;
            int mid = left + (right - left) / 2;

            var node = new TreeNode(A[mid]);
            node.left = BalancedBST(A, left, mid - 1);
            node.right = BalancedBST(A, mid + 1, right);
            return node;
        }

        /// <summary>
        /// Given a Binary Search Tree(BST) A. If there is a node with value B present in the tree delete it and return the tree.
        /// Note - If there are multiple options, always replace a node by its in-order predecessor
        /// Problem Constraints
        /// 2 <= No.of nodes in BST <= 10^5
        /// 1 <= value of nodes <= 10^9
        /// Each node has a unique value
        /// </summary>
        public static void DeleteinBST()
        {
            List<int> input = [15, 12, 20, 10, 14, 16, 27, 8, -1, -1, -1, -1, -1, -1, -1];
            int B = 12;

            //input = [8, 6, 21, 1, 7, -1, -1];
            //B = 6;

            input = [3, -1, 4, -1];
            B = 4;

            var A = input.ListToTree<int>();

            A = DeleteinBST(A, B);

            Console.WriteLine(A.TreeToLevelOrderString());
        }

        private static TreeNode DeleteinBST(TreeNode A, int B)
        {
            if (A == null)
                return A;
            if (B < A.val)
            {
                A.left = DeleteinBST(A.left, B);
            }
            else if (B > A.val)
            {
                A.right = DeleteinBST(A.right, B);
            }
            else if (B == A.val)
            {
                if (A.left == null)
                    return A.right;
                else if (A.right == null)
                    return A.left;
                A.val = NodeMaxValue(A.left);
                A.left = DeleteinBST(A.left, A.val);
            }

            return A;
        }
        private static int NodeMaxValue(TreeNode node)
        {
            int maxValue = node.val;
            while (node.right != null)
            {
                maxValue = node.right.val;
                node = node.right;
            }
            return maxValue;
        }

        /// <summary>
        /// Given a binary search tree A, where each node contains a positive integer, and an integer B, 
        /// you have to find whether or not there exist two different nodes X and Y such that X.value + Y.value = B.
        /// Return 1 to denote that two such nodes exist.Return 0, otherwise.
        /// Problem Constraints
        /// 1 <= size of tree <= 100000
        /// 1 <= B <= 10^9
        /// </summary>
        public static void TwoSumBST()
        {
            List<int> input = [];
            int B = 0;

            input = [10, 9, 20];
            B = 31;

            //input = [15, 12, 20, 10, 14, 16, 27, 8, -1, -1, -1, -1, -1, -1, -1];
            //B = 35;

            //input = [12, 5, 14, -1, 8, -1, 18, -1, -1, -1, -1];
            //B = 20;

            //input = [445, 105, 805, -1, 266, 620, 895, -1, -1, 596, 653, -1, -1, -1, -1, -1, -1];
            //B = 1250;

            var A = input.ListToTree<int>();

            var result = false;
            var lStack = new Stack<TreeNode>();
            var rStack = new Stack<TreeNode>();

            //left stack
            var left = A;
            while (left != null)
            {
                lStack.Push(left);
                left = left.left;
            }
            //right stack
            var right = A;
            while (right != null)
            {
                rStack.Push(right);
                right = right.right;
            }
            //TreeNode node = null;
            while (lStack.Peek() != rStack.Peek())
            {
                left = lStack.Peek();
                right = rStack.Peek();
                int sum = left.val + right.val;
                if (B == sum)
                {
                    result = true;
                    break;
                }
                else if (sum > B)// move left
                {
                    right = rStack.Pop();
                   if(right.left != null)
                    {
                        right = right.left;
                        while (right.left != null)
                        {
                            rStack.Push(right);
                            right = right.right;
                        }
                    }
                }
                else // sum < B  -- move right
                {
                    left = lStack.Pop();
                    if (left.right != null)
                    {
                        left = left.right;
                        while (left != null)
                        {
                            lStack.Push(left);
                            left = left.left;
                        }
                    }
                }
            }

            Console.WriteLine(result);
        }

        /// <summary>
        /// Given a binary search tree of integers. You are given a range B and C.
        /// Return the count of the number of nodes that lie in the given range.
        /// Problem Constraints
        /// 1 <= Number of nodes in binary tree <= 100000
        /// 0 <= B< = C <= 10^9
        /// </summary>
        public static void BSTNodesInRange()
        {
            List<int> input = [];
            int B = 0, C = 0;

            //input = [15,12,20, 10,14,16,27,8];
            //B = 12; C = 20;//5

            //input = [8, 6, 21, 1, 7];
            //B = 2; C = 20;//3

            input = [31, 16, 37, 3, 30, 35, 41, 2, 12, 21, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1];
            B = 10;C = 51;//

            var A = input.ListToTree<int>();
            int result = 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(A);

            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                if(current.val >= B && current.val <= C)
                {
                    result++;
                }
                if(current.left != null) 
                    queue.Enqueue(current.left);

                if (current.right != null)
                    queue.Enqueue(current.right);
            }
            Console.WriteLine(result);
        }

        /// <summary>
        /// Given preorder traversal of a binary tree, check if it is possible that it is also a preorder traversal of a Binary Search Tree (BST), 
        /// where each internal node (non-leaf nodes) have exactly one child.
        /// Problem Constraints
        /// 1 <= number of nodes <= 100000
        /// </summary>
        public static void CheckForBSTwithOneChild()
        {
            List<int> A = [4, 10, 5, 8];

            A = [1, 5, 6, 4];

            bool result = true;
            int root = A[0];
            int L = int.MinValue, R = int.MaxValue;

            for (int i = 1; i < A.Count; i++)
            {
                if (A[i] > root)
                    L = root;
                else
                    R = root;

                if (A[i] < L || A[i] > R)
                {
                    result = false;
                    break;
                }
                root = A[i];
            }
            Console.WriteLine(result);
        }
    }
}
