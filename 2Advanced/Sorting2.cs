using Helpers;

namespace _2Advanced
{
    internal class Sorting2
    {
        public static void QuickSortRun()
        {
            List<int> A = [23,5, 66,11,8,20];

            Console.WriteLine("Input Array");
            ArrayExtension.PrintArray(A);

            QuickSort(A,0,A.Count-1);

            Console.WriteLine("\nSorted Array");
            ArrayExtension.PrintArray(A);
        }
        private static void QuickSort(List<int> A, int l, int r)
        {
            if (l >= r) return;
            int pivot = Partition(A, l, r);
            QuickSort(A, l, pivot - 1);//sort left
            QuickSort(A, pivot + 1, r);//sort right
        }
        private static int Partition(List<int> A, int l, int r)
        {
            int partition = A[l];
            int l_ind = l;
            while (l <= r)
            {
                if (A[l] <= partition) l++;
                else if (A[r] > partition) r--;
                else Swap(A, l, r);
            }
            Swap(A, l_ind, r);
            return r;
        }
        private static void Swap(List<int> A,int l,int r)
        {
            int temp = A[l];
            A[l] = A[r];
            A[r] = temp;
        }
    }
}
