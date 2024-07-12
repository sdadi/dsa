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
