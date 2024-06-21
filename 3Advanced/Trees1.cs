using Helpers;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _3Advanced
{
    internal class Trees1
    {
        /// <summary>
        /// Given a binary tree, return the preorder traversal of its nodes values.
        /// Problem Constraints
        /// 1 <= number of nodes <= 10^5
        /// </summary>
        public static void PreOrderTraversal()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(6); // [1,6,2,3]
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);// [1,2,3]

            var result = new List<int>();

            //PreOrderRecursive(root, result);
            PreOrderIteration(root, result);

            result.PrintArray();
        }

        private static void PreOrderIteration(TreeNode root, List<int> result)
        {
            var current = root;
            var stack = new Stack<TreeNode>();

            while (current != null || stack.Count>0)
            {
                if(current != null)
                {
                    result.Add(current.val);
                    stack.Push(current);
                    current = current.left;
                }
                else
                {
                    current = stack.Pop();
                    current = current.right;
                }
            }
        }
        private static void PreOrderRecursive(TreeNode root, List<int> result)
        {
            if (root == null)
                return;

            var current = root;

            while (current != null)
            {
                result.Add(current.val);

                PreOrderRecursive(current.left, result);
                PreOrderRecursive(current.right, result);
            }
        }


        public static void InOrderTraversal()
        {
            var root = new TreeNode(1);
            //root.left = new TreeNode(6); // [6, 1, 3, 2]
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);//  [1, 3, 2]

            if (root == null)
            {
                (new List<int>()).PrintArray();
                return;
            }
            var result = new List<int>();
            var stack = new Stack<TreeNode>();

            var current = root;
            while (current != null || stack.Count > 0)
            {
                if(current != null)
                {
                    stack.Push(current);
                    current = current.left;
                } else
                {
                    current = stack.Pop();
                    result.Add(current.val);
                    current = current.right;
                }
            }


            result.PrintArray();
        }

        public static void PostOrderTraversal()
        {
            var root = new TreeNode(1);
            //root.left = new TreeNode(6); // [6, 3, 2, 1]
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);//  [3, 2, 1]

            var result = new List<int>();
            PostOrderIteration(root,result);
            result.PrintArray();
        }
        private static void PostOrderIteration(TreeNode root, List<int> result) 
        {
            if (root == null)
            {
                Console.WriteLine("[]");
                return;
            }
            var stack = new Stack<TreeNode>();
            TreeNode lastVisited = null;

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
                    TreeNode peekNode = stack.Peek();
                    if (peekNode.right != null && peekNode.right != lastVisited)
                    {
                        current = peekNode.right;
                    }
                    else
                    {
                        lastVisited = stack.Pop();
                        result.Add(peekNode.val);
                    }
                }
            }
        }

        public static void BinaryTreeFromInOrderPostOrder()
        {
            List<int> A = [2, 1, 3];//in-order
            List<int> B = [2, 3, 1];//post-order
            //List<int> C = [1, 2, 3];//pre-order
            /*
             *      1
             *  2       3
             */

            A = [6, 1, 3, 2];
            B = [6, 3, 2, 1];
            //C = [1,6,2,3];//pre-order
            /*
             *      1
             *  6           2
             *          3
             */
            var dict = new Dictionary<int, int>();
            for(int i=0;i<A.Count;i++)
                dict.Add(A[i],i);

            var root = BinaryTreeFrom_IO_PO(A, dict, B, 0, A.Count - 1, 0, B.Count - 1);
            var result = new List<int>();

            PreOrderIteration(root, result);
            result.PrintArray();
        }

        private static TreeNode BinaryTreeFrom_IO_PO(List<int> inO, Dictionary<int,int> dict, List<int> postO,int inOL,int inOR, int postOL, int postOR)
        {
            if (inOL > inOR)
                return null;
            var root = new TreeNode(postO[postOR]);
            int io_ind = dict[root.val];
            int cntR = inOR - io_ind;
            root.left = BinaryTreeFrom_IO_PO(inO, dict, postO, inOL, (io_ind-1), postOL, (postOR-cntR-1));
            root.right = BinaryTreeFrom_IO_PO(inO, dict, postO, (io_ind+1), inOR, io_ind, (postOR-1));

            return root;
        }

        public static void BinaryTreeFromPreOrderInOrder()
        {
            List<int> A = [1, 2, 3];//pre-orderr
            List<int> B = [2, 1, 3];//in-order
            //post-order [2,3,1]


            //A = [1, 6, 2, 3];
            //B = [6, 1, 3, 2];
            ////post-order [6,3,2,1]
            A = [1, 2, 3, 4, 5];
            B = [3, 2, 4, 1, 5];
            // post-order [3,4,2,5,1]

            var result = new List<int>();
            var dict = new Dictionary<int,int>();
            for (int i = 0; i < B.Count; i++)
                dict.Add(B[i], i);
            var root = BinaryTreeFrom_PreO_IO(A, B, dict, 0,0, B.Count - 1);

            PostOrderIteration(root, result);

            result.PrintArray();
        }

        private static TreeNode BinaryTreeFrom_PreO_IO(List<int> preOrder, List<int> InOrder, Dictionary<int,int> dict,int preL,int inL, int inR)
        {
            if (inL > inR)
                return null;
            var root = new TreeNode(preOrder[preL]);
            if (inL == inR)
                return root;
            int index = dict[root.val];
            int cntL = index - inL;
            root.left = BinaryTreeFrom_PreO_IO(preOrder, InOrder, dict,preL+1, inL, (index-1));
            root.right = BinaryTreeFrom_PreO_IO(preOrder, InOrder, dict,preL+cntL+1, (index+1),inR);

            return root;
        }
    }
}
