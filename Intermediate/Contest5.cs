using _3Advanced;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Intermediate
{
    internal class Contest5
    {
        public static void MaxDistanceOfHouseColor()
        {
            List<int> A = [3, 4, 1, 4, 4];//4

            //A = [4, 1, 2, 4, 5, 1, 4];//5
            A = [21,21,21,20,34,32,34,22,21];//
            //A = [36, 26, 22, 24];//3

            var distance = A.Count-1;
            int left = 0, right = A.Count - 1;
            while (left < right)
            {
                if (A[left] == A[right])
                {
                    if (A[left] != A[left + 1])
                        left++;
                    else                   
                        right--;
                    distance--;
                }
                else
                    break;
            }

            Console.WriteLine(distance==0?-1:distance);
        }

        public static void MinimizeHeightOfBinaryTree()
        {
            List<int> input = [1, 2, 3, 4, 5, -1, -1, -1, -1, 11, 7];//11+7=18
            input = [5, 4, 7, 1, -1, -1, 8];//0

            TreeNode A = input.ListToTree<int>();

            int N = NodesCount(A);
            int height = (int)Math.Log2(N);
            int sum = 0;
            TreeTraversal(A, 0, height, ref sum);
            Console.WriteLine(sum);
        }
        private static void TreeTraversal(TreeNode root,int level, int height,ref int sum)
        {
            if(root == null) return;
            if (level > height) sum += root.val;

            TreeTraversal(root.left,level+1,height,ref sum);
            TreeTraversal(root.right,level+1,height,ref sum);
        }
        private static int NodesCount(TreeNode root)
        {
            if(root == null) return 0;
            return 1+ NodesCount(root.left) + NodesCount(root.right);
        }
        public static void WinnerStone()
        {
            List<int> A = [1, 2, 3, 4, 5];//1

            A = [3, 5, 7, 1, 4, 2, 8, 6];//0

            var maxHeap = new PriorityQueue<int,int>(new MaxHeapComparator());
            for (int i = 0; i < A.Count; i++)
            {
                maxHeap.Enqueue(A[i], A[i]);
            }

            int x = 0, y = 0, result = 0 ;

            while (maxHeap.Count > 1)
            {
                y = maxHeap.Dequeue();
                x = maxHeap.Dequeue();

                if(x== y)
                {
                    continue;
                }
                else
                {
                    maxHeap.Enqueue(y - x,y-x);
                }
            }

            if(maxHeap.Count == 1)
                result = maxHeap.Dequeue();

            Console.WriteLine(result);

        }
        
    }

    class MaxHeapComparator : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }
}
