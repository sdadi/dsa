using System.Text;

namespace _1Advanced
{
    internal class _8Backtracking
    {
        public static void PermutationsRun()
        {
            List<char> A = ['a', 'b', 'c'];
            int index = 0;

            var current = A;
            var visited = new List<char>();

            Permutation(A, current, index, visited);
        }
        private static void Permutation(List<char> A, List<char> current, int index, List<char> visited)
        {
            if (A.Count == index)
            {
                Console.Write("[");
                foreach (var i in current)
                    Console.Write(i + "  ");
                Console.Write("]\n");
                return;
            }
            for (int i = 0; i < A.Count; i++)
            {
                if (visited.Any(x => x == A[i]))
                    continue;
                //{
                    visited.Add(A[i]);
                current[index] = A[i];
                    Permutation(A, current, index + 1, visited);
                    visited.Remove(A[i]);
                //}
            }
            //current.Clear();

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
            AllSubset(A, current, index + 1);
            current.Add(A[index]);
            AllSubset(A, current, index + 1);
            current.Remove(A[index]);

        }
        public static void OpenCloseRun()
        {
            int N = 2, open = 0, close = 0;
            string sb = string.Empty;
            //StringBuilder sb = new StringBuilder();

            OpenClose(sb, N, open, close);

        }

        private static void OpenClose(string sb, int N, int open, int closed)
        {
            if (sb.Length == 2 * N)
            {
                Console.WriteLine(sb.ToString());
                return;
            }
            if (open < N)
            {
                //sb.Append("(");
                //OpenClose(sb, N, open + 1, closed);
                //sb.Remove(sb.Length - 1, 1);
                OpenClose(sb + "(", N, open + 1, closed);
            }
            if (closed < open)
            {
                //sb.Append(")");
                //OpenClose(sb, N, open, closed + 1);
                //sb.Remove(sb.Length - 1, 1);
                OpenClose(sb + ")", N, open, closed + 1);
            }
        }
    }
}
