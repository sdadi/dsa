namespace _2Advanced
{
    internal class Sorting1
    {
        public static void MergeSortRun()
        {
            List<int> A = [];

            MergeSort(A, 0, A.Count - 1);
        }
        private static void MergeSort(List<int> A,int l,int r)
        {
            if (l >= r) return;
            int mid = (l + r) / 2;
            MergeSort(A, l, mid);//left sort
            MergeSort(A, mid + 1, r);//right sort

            MergeSortedArray(A, l, mid, r); //merge sorted left and right parts
        }
        private static void MergeSortedArray(List<int> A,int l, int mid, int r)
        {
            var lArray = new List<int>();
            var rArray = new List<int>();

            for(int i=l;i<=mid; i++)
            {
                lArray.Add(A[i]);
            }
            for(int i = mid + 1; i <= r; i++)
            {
                rArray.Add(A[i]);
            }

            int k = l, i = 0, j = 0;

            while(i < (mid-l+1) && j < (r - mid))
            {
                if (A[i] < A[j])
                {
                    A[k++] = A[i++];
                }
                else
                {
                    A[k++] = A[j++];
                }
            }
            while(i < (mid - l + 1))
            {
                A[k++] = A[i++];
            }
            while(j < (r - mid))
            {
                A[k++] = A[j++];
            }
        }
        public static void MergeSortedArrayRun()
        {
            List<int> A = [];
            List<int> B = [];
            List<int> C = new List<int>();

        }
        private static void MergeSortedArray(List<int> A,List<int> B,List<int> C)
        {
            int i = 0,j=0,k=0;
            int N = A.Count, M = B.Count;

            while(i < N && j< M)
            {
                if (A[i] < B[j])
                {
                    C.Add(A[i]);
                    i++;
                }
                else
                {
                    C.Add(B[j]);
                    j++;
                }
            }
            while (i < N)
            {
                C.Add(A[i]); 
                i++;
            }
            while (j < M)
            {
                C.Add(B[j]);
                j++;
            }
        }
    }
}
