namespace _1Advanced
{
    internal class _8Backtracking
    {
        public static void PhoneLetterRun()
        {
            string A = "012";
            var keyMap = new Dictionary<int, List<char>>
            {
                { 0, ['0'] },
                { 1, ['1'] },
                { 2, ['a', 'b', 'c'] },
                { 3, ['d', 'e', 'f'] },
                { 4, ['g', 'h', 'i'] },
                { 5, ['j', 'k', 'l'] },
                { 6, ['m', 'n', 'o'] },
                { 7, ['p', 'q', 'r','s'] },
                { 8, ['t', 'u','v'] },
                { 9, ['w', 'x', 'y','z'] }
            };
            var result = new  List<string>();

            var current = new List<char>();
            PhoneLetter(A, keyMap,0, current, result);


            foreach (var i in result)
                Console.WriteLine($"[{i}]");

        }

        private static void PhoneLetter(string A,Dictionary<int, List<char>> keyMap, int index, List<char> current,List<string> result)
        {
            if(A.Length == current.Count)
            {
                result.Add(string.Join("",current));
                return;
            }

            int val = A[index] - '0';
            for(int i = 0; i < keyMap[val].Count; i++)
            {
                current.Add(keyMap[val][i]);
                PhoneLetter(A,keyMap,index+1,current,result);
                current.RemoveAt(current.Count-1);
            }
        }
        public static void PermutationsUniqueRun()
        {
            List<int> A = [1,2,3];

            var current = new List<int>();
            var result = new List<List<int>>();
            Dictionary<int,int> map = new Dictionary<int,int>();
            foreach (int i in A) {
                if (map.ContainsKey(i))
                {
                    map[i] += 1;
                }
                else
                    map.Add(i, 1);
            }

            PermutationUnique(A,map, current, result);

            foreach (var i in result)
                Console.WriteLine($"[{string.Join(" ", i)}]");

        }
        private static void PermutationUnique(List<int> A, Dictionary<int,int> map, List<int> current, List<List<int>> result)
        {
            if (A.Count == current.Count)
            {
                result.Add(new List<int>(current));
                return;
            }
            
            foreach(var i in map.Keys.ToList())
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
            List<int> A = [9, 1, 1];//, -12, -20, 1, 4];
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

            for(int i=index;i<A.Count;i++)
            {
                if (i > index && A[i] == A[i - 1]) continue; // Skip duplicates

                current.Add(A[i]); // Include the current element

                LexographicSubset(A, current, i + 1, result); // Recursively generate subsets

                current.RemoveAt(current.Count - 1); // Backtrack
            }

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
            current.Remove(A[index]);

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
