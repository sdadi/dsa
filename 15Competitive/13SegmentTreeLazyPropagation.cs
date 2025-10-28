namespace _15Competitive {
    internal class _13SegmentTreeLazyPropagation {

        #region Question 1: Flipping Sign
        /// <summary>
        /// Problem Description
        ///You are given an array A of numbers and an array B of size M X 3, having operations as follows.
        ///If B[i][0] = 1, flip(multiply A[i] by -1) the value of A[i] where B[i][1] <= i <= B[i][2] .
        ///If B[i][0] = 2, calculate the sum of the array in given range inclusive of both B[i][1] and B[i][2] .
        ///Return an array of answers to the Type 2 queries.
        ///Problem Constraints
        ///1 <= |A| <= 100000
        /// </summary>
        public void FlippingSign() {
            List<int> A = [2, 3, 4];
            List<List<int>> B = [[1, 1, 2], [2, 1, 3]];//Output [-1]

            //A = [1, 2, 3];
            //B = [[1, 3, 3], [2, 1, 3], [2, 1, 1]]; // Output [0, 1]

            Helpers.ArrayExtension.PrintArray<int>(A);
            var result = new List<int>();
            var tree = new List<int>(Enumerable.Repeat(0, A.Count * 4));
            var lazy = new List<int>(Enumerable.Repeat(0, A.Count * 4));

            build(0, 0, A.Count-1, A, tree);
            Helpers.ArrayExtension.PrintArray<int>(tree);

            for (int i = 0; i < B.Count; i++) {
                int qType = B[i][0];
                int left = B[i][1] - 1;//zero based index
                int right = B[i][2] - 1;
                if (qType == 1)
                    update(0, 0, A.Count - 1, left, right, tree, lazy);
                if (qType == 2)
                    result.Add(query(0, 0, A.Count - 1, left, right,  tree, lazy));
                Helpers.ArrayExtension.PrintArray<int>(tree);
            }

            Helpers.ArrayExtension.PrintArray<int>(tree);
            Console.WriteLine("Result: -----------------------------------");
            Helpers.ArrayExtension.PrintArray<int>(result);
        }

        private void build(int idx, int start, int end, List<int> A, List<int> tree) {
            if(start == end) {
                tree[idx] = A[start];
            } else {
                int mid = (start + end) / 2;
                int lc = 2 * idx + 1;
                int rc = 2 * idx + 2;

                build(lc, start, mid, A, tree);
                build(rc,mid+1,end, A, tree);

                tree[idx] = tree[lc] + tree[rc];
            }
        }

        private int query(int idx, int start, int end, int l, int r,  List<int> tree, List<int> lazy) {
            if (lazy[idx] != 0) {
                tree[idx] *= -1;
                if(start != end) {
                    lazy[2 * idx + 1] ^= 1;
                    lazy[2 * idx + 2] ^= 1;
                }
                lazy[idx] = 0;
            }
            //nt range
            if(l <= start && end <= r) {
                return tree[idx];
            }
            //out of range
            if(r < start || end < l) {
                return 0;
            }
            int mid = (start + end) / 2;
            return query(2 * idx + 1, start, mid, l, r,  tree, lazy) + query(2 * idx + 2, mid + 1, end, l, r,  tree, lazy);
        }

        private void update(int idx, int start, int end, int l, int r, List<int> tree, List<int> lazy) {
            if (lazy[idx] != 0) {
                tree[idx] *= -1;
                if (start != end) { // if the current index has children
                    lazy[2 * idx + 1] ^= 1;
                    lazy[2 * idx + 2] ^= 1;
                }
                lazy[idx] = 0;
            }

            //if in range
            if (l <= start && end <= r) {
                tree[idx] *= -1;
                if (start != end) {
                    lazy[2 * idx + 1] ^= 1;
                    lazy[2 * idx + 2] ^= 1;
                }
                return;
            }
            // if out of range
            if (r < start || end < l) {
                return;
            }
            // partial range
            int mid = (start + end) / 2;
            update(2*idx+1, start, mid, l, r,  tree, lazy);
            update(2*idx+2,mid+1,end,l,r, tree, lazy);
            tree[idx] = tree[2*idx+1] + tree[2*idx+2];
        }
        #endregion
    }
}
