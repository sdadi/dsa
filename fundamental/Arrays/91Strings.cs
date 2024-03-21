using System.Text;

namespace fundamental.Arrays
{
    internal class Strings
    {
        internal static void AmazingStrings()
        {
            string A = "pGpEusuCSWEaPOJmamlFAnIBgAJGtcJaMPFTLfUfkQKXeymydQsdWCTyEFjFgbSmknAmKYFHopWceEyCSumTyAFwhrLqQXbWnXSn";
            int N = A.Length;
            int count = 0;

            for (int i = 0; i < N; i++)
            {
                char c = A[i];
                switch (c)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                    case 'A':
                    case 'E':
                    case 'I':
                    case 'O':
                    case 'U':
                        count = (count + N - i);
                        break;
                }
            }
            Console.WriteLine( count % 10003);
        }
        internal static void CommonPrefix()
        {
            List<string> A = ["abcd", "abcd", "efgh"];
            if (A.Count == 1)
                Console.WriteLine($"only one string available {A[0]}");
            var sb = new StringBuilder();
            int N = A.Count;
            int shortIndex = 0;
            int col = A[0].Length;
            for(int i=1; i<N; i++)
            {
                if (A[i].Length < col)
                {
                    col = A[i].Length;
                    shortIndex = i;
                }
            }

            for (int i = 0; i < col; i++)
            {
                bool isQualified = true;
                for (int rows = 0; rows < A.Count; rows++)
                {
                    if (A[rows][i] != A[shortIndex][i])
                    {
                        isQualified = false;
                        break;
                    }
                }
                if (isQualified)
                {
                    sb.Append(A[0][i]);
                }
                else
                    break;
            }
            Console.WriteLine(sb);
        }
        internal static void StringOperations()
        {
            string A = "AbcaZeoB";
            char[] input = A.ToCharArray();
            StringBuilder sb = new StringBuilder();
            int N = input.Length;

            for (int i = 0;i<N;i++)
            {
                if (input[i] >= 'A' && input[i] <= 'Z')
                    continue;
                switch (input[i])
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                        sb.Append("#");
                        break;
                    default:
                        sb.Append(input[i]);
                        break;
                }
            }
            Console.WriteLine(sb.Append(sb));
        }
        internal static void ReverseStringWordByWord()
        {
            string A = "crulgzfkif gg ombt vemmoxrgf qoddptokkz op xdq hv";
            
            StringBuilder sb = new StringBuilder();
            StringBuilder current = new StringBuilder();

            for(int i = A.Length-1; i >=0;i--)
            {
                if (A[i] == ' ')
                {
                    if(current.Length > 0)
                    {
                        sb.Append(current);
                        sb.Append(" ");
                    }
                    current.Clear();
                    continue;
                }
                current.Insert(0, A[i]);
            }
            if(current.Length > 0)
            {
                sb.Append(current);
                current.Clear();
            }

            Console.WriteLine($" reversed string is '{sb.ToString()}' ");
        }
        internal static void LongestPalindrome()
        {
            string A = "bb";
            int N = A.Length; ;

            int maxL = 0, start = -1, end = -1;

            //Odd palindrome
            for (int i = 0; i < N; i++)
            {
                int left = i, right = i;
                while (left >= 0 && right < N)
                {
                    if (A[left] == A[right])
                    {
                        left--;
                        right++;
                    }
                    else
                        break;
                }
                int len = (right - 1) - (left + 1) + 1;

                if (len > maxL)
                {
                    maxL = len;
                    start = left + 1;
                    end = right - 1;
                }
            }

            //EvenPalindrome
            for (int i = 0; i < N; i++)
            {
                int left = i, right = i + 1;

                while (left >= 0 && right < N)
                {
                    if (A[left] == A[right])
                    {
                        left--;
                        right++;
                    }
                    else
                        break;
                }
                int len = (right - 1) - (left + 1) + 1;
                if (len > maxL)
                {
                    maxL = len;
                    start = left + 1;
                    end = right - 1;
                }
            }

            Console.WriteLine($"max palindrome is {A.Substring(start,(end-start+1))} of length {maxL}");
        }
    }
}
