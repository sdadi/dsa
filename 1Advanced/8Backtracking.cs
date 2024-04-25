using System;

namespace _1Advanced
{
    internal class _8Backtracking
    {
        public static void PhoneLetterRun()
        {
            string A = "257";
            var keyMap = new Dictionary<int, List<char>>();
            keyMap.Add(0, new List<char>() { '0' });
            keyMap.Add(1, new List<char>() { '1' });
            keyMap.Add(2, new List<char>() { 'a', 'b', 'c' });
            keyMap.Add(3, new List<char>() { 'd', 'e', 'f' });
            keyMap.Add(4, new List<char>() { 'g', 'h', 'i' });
            keyMap.Add(5, new List<char>() { 'j', 'k', 'l' });
            keyMap.Add(6, new List<char>() { 'm', 'n', 'o' });
            keyMap.Add(7, new List<char>() { 'p', 'q', 'r', 's' });
            keyMap.Add(8, new List<char>() { 't', 'u', 'v' });
            keyMap.Add(9, new List<char>() { 'w', 'x', 'y', 'z' });

            var result = new List<string>();

            var current = new List<char>();
            PhoneLetter(A, keyMap, 0, current, result);


            foreach (var i in result)
                Console.WriteLine($"[{i}]");

        }

        private static void PhoneLetter(string A, Dictionary<int, List<char>> keyMap, int index, List<char> current, List<string> result)
        {
            if (A.Length == current.Count)
            {
                result.Add(string.Join("", current));
                return;
            }

            int val = A[index] - '0';
            for (int i = 0; i < keyMap[val].Count; i++)
            {
                current.Add(keyMap[val][i]);
                PhoneLetter(A, keyMap, index + 1, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }
        public static void PermutationsUniqueRun()
        {
            List<int> A = [1, 2, 3];

            var current = new List<int>();
            var result = new List<List<int>>();
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int i in A)
            {
                if (map.ContainsKey(i))
                {
                    map[i] += 1;
                }
                else
                    map.Add(i, 1);
            }

            PermutationUnique(A, map, current, result);

            foreach (var i in result)
                Console.WriteLine($"[{string.Join(" ", i)}]");

        }
        private static void PermutationUnique(List<int> A, Dictionary<int, int> map, List<int> current, List<List<int>> result)
        {
            if (A.Count == current.Count)
            {
                result.Add(new List<int>(current));
                return;
            }

            foreach (var i in map.Keys.ToList())
            {
                if (map[i] > 0)
                {
                    map[i] -= 1;
                    current.Add(i);
                    PermutationUnique(A, map, current, result);
                    current.RemoveAt(current.Count - 1);
                    map[i] += 1;
                }
            }
        }
        public static void PermutationsRun()
        {
            List<char> A = ['a', 'a', 'c'];
            int index = 0;

            var current = new List<char>();
            var visited = new List<bool>();
            var result = new List<string>();

            current.AddRange(A);

            for (int i = 0; i < A.Count; i++)
                visited.Add(false);

            Permutation(A, current, index, visited, result);

            foreach (var i in result)
                Console.WriteLine($"[{string.Join(" ", i)}]");

        }
        private static void Permutation(List<char> A, List<char> current, int index, List<bool> visited, List<string> result)
        {
            if (A.Count == index)
            {
                result.Add(string.Join("", current));
                return;
            }
            for (int i = 0; i < A.Count; i++)
            {
                if (visited[i] == false)
                {
                    visited[i] = true;
                    current[index] = A[i];
                    Permutation(A, current, index + 1, visited, result);
                    visited[i] = false;
                }
            }
        }
        /// <summary>
        /// Given a set of distinct integers A, return all possible subsets.
        /// NOTE:
        ///     Elements in a subset must be in non-descending order.
        ///     The solution set must not contain duplicate subsets.
        ///     Also, the subsets should be sorted in ascending (lexicographic ) order.
        ///     The initial list is not necessarily sorted.
        /// </summary>
        public static void LexographicSubSetRun()
        {
            List<int> A = [1,2,1,3];//, -12, -20, 1, 4];
            A.Sort();
            var result = new List<List<int>>();

            LexographicSubset(A, (new List<int>()), 0, result);

            foreach (var item in result)
            {
                Console.WriteLine($"[{string.Join(" ", item)}]");
            }
        }
        private static void LexographicSubset(List<int> A, List<int> current, int index, List<List<int>> result)
        {
            result.Add(new List<int>(current));

            for (int i = index; i < A.Count; i++)
            {
                if (i > index && A[i] == A[i - 1]) continue; // Skip duplicates

                current.Add(A[i]); // Include the current element

                LexographicSubset(A, current, i + 1, result); // Recursively generate subsets

                current.RemoveAt(current.Count - 1); // Backtrack
            }

        }
        /// <summary>Given an array of integers A, the array is squareful if for every pair of adjacent elements, 
        ///            their sum is a perfect square.
        /// Find and return the number of permutations of A that are squareful.
        ///            Two permutations A1 and A2 differ if and only if there is some index i such that A1[i] != A2[i].
        /// </summary>
        public static void SquarefulRun()
        {
            List<int> A = [36229, 1020, 69, 127, 162, 127];
            A.Sort();
            var result = new List<List<int>>();

            Squareful(A, 0, result);

            foreach (var item in result)
            {
                Console.WriteLine($"[{string.Join(" ", item)}]");
            }
        }
        private static void Squareful(List<int> A, int index, List<List<int>> result)
        {
            if (index == A.Count)
            {
                result.Add(new List<int>(A));
                return;
            }

            for (int K = index; K < A.Count; K++)
            {
                if (index == K ||  A[index] != A[K])
                {
                    SwapSquarefull(A, index, K);
                    if (index == 0 || (index > 0 && IsAdjacentSquare(A, index, index - 1)))
                    {
                        Squareful(A, index + 1, result);
                    }
                    SwapSquarefull(A, index, K);
                }
            }
        }
        private static bool IsAdjacentSquare(List<int> A,int a, int b)
        {
            int sqrt = (int)Math.Sqrt(A[a] + A[b]);
            return (sqrt * sqrt == A[a] + A[b]);
        }
        private static bool IsSquareFull(List<int> A)
        {
            for(int i = 1; i < A.Count; i++)
            {
                int sqrt = (int)Math.Sqrt(A[i - 1] + A[i]);
                if(sqrt*sqrt != (A[i - 1] + A[i]))
                    return false;
            }
            return true;
        }
        private static void SwapSquarefull(List<int> A, int left, int right)
        {
            if (left == right) return;
            int temp = A[left];
            A[left] = A[right];
            A[right] = temp;
        }
        public static void AllSubsetRun()
        {
            List<int> A = [1, 2, 3];
            int index = 0;
            var current = new List<int>();

            AllSubset(A, current, index);
        }
        private static void AllSubset(List<int> A, List<int> current, int index)
        {
            if (A.Count == index)
            {
                Console.Write("[");
                foreach (int i in current)
                    Console.Write(i + "  ");
                Console.Write("]\n");
                return;
            }
            AllSubset(A, current, index + 1);/* not include current item */

            current.Add(A[index]);/* include current item */
            AllSubset(A, current, index + 1);
            current.RemoveAt(current.Count - 1);

        }
        public static void OpenCloseRun()
        {
            int N = 3, open = 0, close = 0;
            var sb = new List<string>();
            var result = new List<string>();

            OpenClose(sb, N, open, close, result);

            foreach (var str in result)
                Console.WriteLine(str);
        }

        private static void OpenClose(List<string> sb, int N, int open, int closed, List<string> result)
        {
            if (sb.Count == 2 * N)
            {
                result.Add(string.Join(" ", sb));
                return;
            }
            if (open < N)
            {
                sb.Add("(");
                OpenClose(sb, N, open + 1, closed, result);
                sb.RemoveAt(sb.Count - 1);
            }
            if (closed < open)
            {
                sb.Add(")");
                OpenClose(sb, N, open, closed + 1, result);
                sb.RemoveAt(sb.Count - 1);
            }
        }
    }
}
