namespace _15Competitive {
    internal class _11SegmentTree {
        #region Q1. Range Minimum Query
        /// <summary>
        /// Problem Description
        /// Given an integer array A of size N.
        /// You have to perform two types of query, in each query you are given three integers x, y, z.
        /// If x = 0, then update A[y] = z.
        /// If x = 1, then output the minimum element in the array A between index y and z inclusive.
        /// Queries are denoted by a 2-D array B of size M x 3 where B[i][0] denotes x, B[i][1] denotes y, B[i][2] denotes z.
        /// 
        /// Problem Constraints
        /// 1 <= N, M <= 10^5
        /// 1 <= A[i] <= 10^9
        /// If x = 0, 1<= y <= N and 1 <= z <= 10^9
        /// If x = 1, 1<= y <= z <= N
        /// </summary>
        public void RangeMinimumQuery() {
            List<int> A = [1, 4, 1];
            List<List<int>> B = [[1, 1, 3], [0, 1, 5], [1, 1, 2]];// [1, 4]

            //A = [5, 4, 5, 7];
            //B = [[1, 2, 4], [0, 1, 2], [1, 1, 4]];// [4, 2]

            Helpers.ArrayExtension.PrintArray<int>(A);
            var result = new List<int>();
            var tree = new List<int>(Enumerable.Repeat(int.MaxValue, A.Count * 4));
            Helpers.ArrayExtension.PrintArray<int>(tree);
            BuildSegmentTree(0, 0, A.Count - 1, A, tree);
            Helpers.ArrayExtension.PrintArray<int>(tree);
            for (int i = 0; i < B.Count; i++) {
                int qType = B[i][0];
                int pos = B[i][1]-1;
                int newVal = B[i][2];
                if (qType == 0)
                    UpdateSegmentTree(0, 0, A.Count - 1, pos, newVal, A, tree);
                else if (qType == 1)
                    result.Add(QuerySegmentTree(0, 0, A.Count - 1, pos, newVal-1, tree));
            }
            Helpers.ArrayExtension.PrintArray<int>(tree);
            Console.WriteLine("Result: -----------------------------------");
            Helpers.ArrayExtension.PrintArray<int>(result);
        }
        public void BuildSegmentTree(int idx, int start, int end, List<int> A, List<int> tree) {
            if (start == end) {
                tree[idx] = A[start];
            } else {
                int mid = start + (end - start) / 2;
                int lc = 2 * idx + 1;
                int rc = 2 * idx + 2;
                BuildSegmentTree(lc, start, mid, A, tree);
                BuildSegmentTree(rc, mid + 1, end, A, tree);
                tree[idx] = Math.Min(tree[lc], tree[rc]);
            }
        }

        public int QuerySegmentTree(int idx, int start, int end, int left, int right, List<int> tree) {
            // if in range
            if(left <= start && end <= right) {
                return tree[idx];
            }

            // out of range
            if(start > right || end < left) {
                return int.MaxValue;
            }

            // partial in range
            int mid = start + (end - start) / 2;
            int lc = QuerySegmentTree(2 * idx + 1, start, mid, left, right, tree);
            int rc = QuerySegmentTree(2 * idx + 2, mid + 1, end, left, right, tree);
            return Math.Min(lc, rc);
        }

        public void UpdateSegmentTree(int idx, int start, int end, int pos, int newVal, List<int> A, List<int> tree) {
            if (start == end) {
                A[pos] = newVal;
                tree[idx] = newVal;
                return;
            }

            int mid = start + (end - start) / 2;
            if (pos <= mid) {
                UpdateSegmentTree(2 * idx + 1, start, mid, pos, newVal, A, tree);
            }
            else {
                UpdateSegmentTree(2 * idx + 2, mid + 1, end, pos, newVal, A, tree);
            }
            tree[idx] = Math.Min(tree[2 * idx + 1], tree[2 * idx + 2]);
        }
        #endregion

        #region Q2. Bob and Queries
        /// <summary>
        /// Bob has an array A of N integers. Initially, all the elements of the array are zero.
        /// Bob asks you to perform Q operations on this array.
        /// You have to perform three types of query, in each query you are given three integers x, y and z.
        /// if x = 1: Update the value of A[y] to 2 * A[y] + 1.
        /// if x = 2: Update the value A[y] to ⌊A[y]/2⌋ , where ⌊⌋ is Greatest Integer Function.
        /// if x = 3: Take all the A[i] such that y <= i <= z and convert them into their corresponding binary strings.
        /// Now concatenate all the binary strings and find the total no.of '1' in the resulting string.
        /// Queries are denoted by a 2-D array B of size M x 3 where B[i][0] denotes x, B[i][1] denotes y, B[i][2] denotes z.
        /// Problem Constraints
        /// 1 <= N, Q <= 100000
        /// 1 <= y, z <= N
        /// 1 <= x <= 3
        /// </summary>
        public void BobAndQueries() {
            List<int> A = new List<int>(Enumerable.Repeat(0,5));
            List<List<int>> B = [
                                    [1, 1, -1]
                                    ,[1, 2, -1]
                                    ,[1, 3, -1]
                                    ,[3, 1, 3]
                                    ,[3, 2, 4]
                                 ];// [3,2]


            //A = new List<int>(Enumerable.Repeat(0, 5));
            //B = [
            //        [1, 1, -1]
            //        ,[1, 2, -1]
            //        ,[3, 1, 3]
            //        ,[2, 1, -1]
            //        ,[3, 1, 3]
            //     ];//[2, 1]

            Helpers.ArrayExtension.PrintArray<int>(A);
            var result = new List<int>();
            var tree = new List<int>(Enumerable.Repeat(int.MinValue, A.Count * 4));
            Helpers.ArrayExtension.PrintArray<int>(tree);
            //BuildSegmentTreeMax(0, 0, A.Count - 1, A, tree);
            Helpers.ArrayExtension.PrintArray<int>(tree);
            for (int i = 0; i < B.Count; i++) {
                int left = B[i][0];
                int right = B[i][1];
                //result.Add(QuerySegmentTreeMax(0, 0, A.Count - 1, left, right, tree));
            }
            Helpers.ArrayExtension.PrintArray<int>(tree);
            Console.WriteLine("Result: -----------------------------------");
            Helpers.ArrayExtension.PrintArray<int>(result);
        }
        #endregion
    }
}
