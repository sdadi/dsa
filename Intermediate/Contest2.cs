namespace Intermediate
{
    internal class Contest2
    {
        static int max_result = 0;
        public static void LongestPossibleRoute()
        {
            List<int> A = [0, 1];
            List<int> B = [2, 0];
            List<List<int>> C = [[1, 1], [0, 0], [1, 1]];

            var visited = new List<List<bool>>();
            for (int a = 0; a < C.Count; a++)
            {
                var item = new List<bool>();
                for (int b = 0; b < C[0].Count; b++)
                {
                    item.Add(false);
                }
                visited.Add(item);
            }

            if (C[A[0]][A[1]] == 0)
            {
                Console.WriteLine(-1);
                return;
            }

            int i = A[0], j = A[1];
            visited[i][j] = true;


            int result = 0;
            LongestPathMove(A, B, i, j, C, visited, result);
            Console.WriteLine(max_result);
        }

        private static void LongestPathMove(List<int> A, List<int> B, int i, int j, List<List<int>> C, List<List<bool>> visited, int result)
        {
            if (i == B[0] && j == B[1])
            {
                max_result = result;
                return;
            }
            while (i < C.Count && j < C[0].Count)
            {
                if (C[i][j] == 0) { break; }
                // check top exist
                if (i > 0 && C[i - 1][j] == 1 && visited[i - 1][j] == false)
                {
                    result += 1;

                    visited[i - 1][j] = true;
                    max_result = Math.Max(max_result, result);
                    LongestPathMove(A, B, i - 1, j, C, visited, result);
                }
                // check left exist
                if (j > 0 && C[i][j - 1] == 1 && visited[i][j - 1] == false)
                {
                    visited[i][j - 1] = true;
                    result += 1;
                    max_result = Math.Max(max_result, result);
                    LongestPathMove(A, B, i, j - 1, C, visited, result);
                }

                // check down exst
                if (i < C.Count - 1 && C[i + 1][j] == 1 && visited[i + 1][j] == false)
                {
                    result += 1;
                    visited[i + 1][j] = true;
                    LongestPathMove(A, B, i + 1, j, C, visited, result);
                    max_result = Math.Max(max_result, result);
                }

                // check right exist
                if (j < C[0].Count - 1 && C[i][j + 1] == 1 && visited[i][j + 1] == false)
                {
                    result += 1;
                    visited[i][j + 1] = true;
                    LongestPathMove(A, B, i, j + 1, C, visited, result);
                    max_result = Math.Max(max_result, result);
                }
                i++; j++;
            }
        }
        public static void LongestRouteMoveRun()
        {
            List<int> A = [1, 1];
            List<int> B = [2, 2];
            List<List<int>> C = [   [1, 1, 1], 
                                    [1, 1, 1], 
                                    [1, 1, 1]
                                ];

            int result = LongestRouteMove(A[0], A[1], B[0], B[1], C);
            Console.WriteLine(result);
        }
        private static int LongestRouteMove(int sr, int sc, int er, int ec, List<List<int>> matrix)
        {
            if (sr == er && sc == ec) return 0;
            int N = matrix.Count,
                M = matrix[0].Count;
            List<int> dir_r = [-1, 0, 1, 0];//top, left, down, right
            List<int> dir_c = [0, -1, 0, 1];//top, left, down, right
            int max_path = -1;
            matrix[sr][sc] = -1;

            for (int i = 0; i < 4; i++)
            {
                int new_r = sr + dir_r[i];
                int new_c = sc + dir_c[i];

                if (0 <= new_r && new_r < N && 0 <= new_c && new_c < M && matrix[new_r][new_c] == 1)
                {
                    int result = LongestRouteMove(new_r, new_c, er, ec, matrix);
                    if (result != -1)
                    {
                        max_path = Math.Max(result+1, max_path);
                    }
                }
            }
            matrix[sr][sc] = 1;
            return max_path;
        }
    }
}
