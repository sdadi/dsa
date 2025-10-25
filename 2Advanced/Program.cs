using System.ComponentModel.Design;

namespace _2Advanced {
    internal class Program {
        static void Main(string[] args) {
            //Sorting1.CountSort();
            //Sorting1.MergeSortRun();
            //Sorting1.MergeSortedArrayRun();
            Sorting1.InverseCountRun();

            //Sorting2.LargestNumber();
            //Sorting2.QuickSortRun();
            //Sorting2.BClosestPointsToOrigin();
            //Sorting2.FactorsSort();

            //Searching1.SortedInsertPosition();
            //Searching1.MatrixSearch();
            //Searching1.SearchforaRange();
            //Searching1.FindPeakElement();

            //Searching2.RotatedArraySearch();
            //Searching2.AthMagicalNumber();
            //Searching2.SquareRoot();
            //Searching2.MedianOf2SortedArrays();
            //Searching2.MedianOfSortedArrays();

            //Searching3.PaintersBoard();
            //Searching3.SpecialInteger();

            //TwoPointer.PairKExist();
            //TwoPointer.ContainerWithMaxWater(); 
            //TwoPointer.SubArrayWithSum();
            //TwoPointer.PairsWithSumInArrayDuplicates();
            //TwoPointer.PairsWithGiveDifference();
            //TwoPointer.Sum3();

            //Console.WriteLine(hotel());
        }

        public static int hotel() {
            List<int> A = [1,3,5]; 
            List< int > B = [2,6,8]; 
            int C = 1;
            A.Sort();
            B.Sort();
            int occup = 1;
            for (int i = 1; i < A.Count; i++) {
                if (A[i] < B[i - 1])
                    occup++;
                else if (A[i] > B[i - 1])
                    occup--;
                else if (A[i] != B[i - 1])
                    occup++;
                if (occup > C)
                    return 0;
            }
            return 1;
        }

    }
}
