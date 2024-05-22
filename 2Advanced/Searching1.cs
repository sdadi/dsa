namespace _2Advanced
{
    internal class Searching1
    {
        /// <summary>
        /// You are given a sorted array A of size N and a target value B.
        /// Your task is to find the index(0-based indexing) of the target value in the array.
        /// If the target value is present, return its index.
        /// If the target value is not found, return the index of least element greater than equal to B.
        /// If the target value is not found and least number greater than equal to target is also not present, return the length of array (i.e.the position where target can be placed)
        /// Your solution should have a time complexity of O(log(N)).
        /// </summary>
        /// <seealso cref="">
        /// 1 <= N <= 10^5
        /// 1 <= A[i] <= 10^5
        /// 1 <= B <= 10^5
        /// </seealso>
        public static void SortedInsertPosition()
        {
            //List<int> A = [1, 3, 5, 6];
            //int B = 5;//2

            List<int> A = [1, 4, 9];
            int B = 3;//1

            int result = -1;
            int N = A.Count;
            int l = 0, r = N - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (A[mid] == B)
                {
                    result = mid; break;
                }
                else if (A[mid] > B)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            if (result == -1)
                result = l;

            Console.WriteLine(l);
        }

        /// <summary>
        /// Given a matrix of integers A of size N x M and an integer B. Write an efficient algorithm that searches for integer B in matrix A.
        /// This matrix A has the following properties:
        /// Integers in each row are sorted from left to right.
        /// The first integer of each row is greater than or equal to the last integer of the previous row.
        /// Return 1 if B is present in A, else return 0.
        /// NOTE: Rows are numbered from top to bottom, and columns are from left to right.
        /// 1 <= N, M <= 1000
        /// 1 <= A[i][j], B <= 10^6
        /// </summary>
        public static void MatrixSearch()
        {
            //List<List<int>> A = [
            //                      [1,   3,  5,  7],
            //                      [10, 11, 16, 20],
            //                      [23, 30, 34, 50]
            //                    ];
            //int B = 3;//1

            List<List<int>> A = [
                                  [5, 17, 100, 111],
                                  [119, 120, 127, 131]
                                ];
            int B = 3;//0

            int N = A.Count;
            int M = A[0].Count;
            int result = 0;

            int left = 0, right = N * M - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int r = mid / M;
                int c = mid % M;

                if (A[r][c] == B)
                { result = 1; break; }
                else if (A[r][c] > B)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            Console.WriteLine(result);
        }

        /// <summary>
        /// Given a sorted array of integers A (0-indexed) of size N, find the left most and the right most index of a given integer B in the array A.
        /// Return an array of size 2, such that
        /// First element = Left most index of B in A
        /// Second element = Right most index of B in A.
        /// If B is not found in A, return [-1, -1].
        /// Note : Your algorithm's runtime complexity must be in the order of O(log n).
        /// 1 <= N <= 10^6
        /// 1 <= A[i], B <= 10^9
        /// </summary>
        public static void SearchforaRange()
        {
            List<int> A = [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10];
            int B = 10;//[3,4]

            //List<int> A = [5, 17, 100, 111];
            //int B = 3;//[-1,-1]

            int N = A.Count;
            var result = new List<int> { -1, -1 };
            int left = 0, right = N - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (A[mid] == B)
                {
                    if (mid == 0 || A[mid - 1] < B)
                    {
                        result[0] = mid;
                        break;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                else if (A[mid] > B)
                {
                    right = mid - 1;
                }
                else { left = mid + 1; }
            }
            if (result[0] == -1)
            {
                Console.WriteLine($"[{result[0]},{result[1]}]");
                return;
            }
            left = result[0];
            right = N - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (A[mid] == B)
                {
                    if (mid == N - 1 || A[mid + 1] > B)
                    {
                        result[1] = mid;
                        break;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else if (A[mid] > B)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            Console.WriteLine($"[{result[0]},{result[1]}]");
        }

        /// <summary>
        /// Given a sorted array of integers A where every element appears twice except for one element which appears once, find and return this single element that appears only once.
        /// Elements which are appearing twice are adjacent to each other.
        /// NOTE: Users are expected to solve this in O(log(N)) time.
        /// 1 <= |A| <= 100000
        /// 1 <= A[i] <= 10^9
        /// </summary>
        public static void SingleElementInArray()
        {
            List<int> A = [1, 1, 7];

            int N = A.Count;
            int left = 0, right = N - 1;

            while (left <= right)
            {
                int mid = (left+right) / 2;
                if ((mid ==0 || A[mid] != A[mid-1]) &&
                    (mid == N-1 || A[mid] != A[mid + 1]))
                {
                    Console.WriteLine(A[mid]);
                    return;
                }
                if(mid >0 && A[mid-1] == A[mid])
                {
                    if (mid % 2 == 1)
                        left = mid + 1;
                    else 
                        right = mid - 1;
                }
                else if(mid < N-1 && A[mid] == A[mid+1])
                {
                    if (mid % 2 == 1)
                        right = mid - 1;
                    else 
                        left = mid + 1;
                }
            }
        }

        /// <summary>
        ///Given an array of integers A, find and return the peak element in it.
        ///An array element is considered a peak if it is not smaller than its neighbors.
        ///For corner elements, we need to consider only one neighbor.
        ///NOTE:
        ///     It is guaranteed that the array contains only a single peak element.
        ///     Users are expected to solve this in O(log(N)) time.The array may contain duplicate elements.
        ///1 <= |A| <= 100000
        ///1 <= A[i] <= 10^9
        /// </summary>
    public static void FindPeakElement()
        {
            //List<int> A = [1, 2, 3, 4, 5];

            List<int> A = [2,3];

            int N = A.Count;
            int left =1,right = N - 2;
            if (N == 1)
            {
                Console.WriteLine(A[0]);
                return;
            }
            else if (A[0] > A[1])
            {
                Console.WriteLine(A[0]);
                return ;
            }
            else if (A[N-1] > A[N - 2])
            {
                Console.WriteLine(A[N-1]);
                return;
            }

            while (left <= right)
            {
                int mid = left+ (right-left) / 2;  
                if(A[mid] >= A[mid-1] &&
                    A[mid] >= A[mid + 1])
                {
                    Console.WriteLine(A[mid]);
                    return;
                }
                else if(A[mid-1] < A[mid] && A[mid]  < A[mid + 1])
                {// for incr slope...move right side
                    left = mid + 1;
                }
                else if(A[mid-1] > A[mid] && A[mid] > A[mid+1])
                { // decr slope...move left side
                    right = mid - 1;
                }
            }
            Console.WriteLine(-1);
        }
    }
}
