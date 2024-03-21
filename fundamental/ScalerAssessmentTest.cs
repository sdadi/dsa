namespace fundamental
{
    internal class ScalerAssessmentTest
    {
        /// <summary>
        /// Implement pow(A, B) % C.
        /// In other words, given A, B and C, Find (AB % C).
        /// </summary>
        internal static void PowABModC()
        {
            int A = -1, B = 1, C = 20;
            if(A==0)
            {
                Console.WriteLine("A is 0 so result is 0");
                return;
            }    
            if(B==0)
            {
                Console.WriteLine("B is 0 so result is 1");
                return;
            }
            if(C==0) {
                Console.WriteLine("C is 0 so value can't be calculated");
                return;
            }
            int result = A;
            for (int i = 0; i < B && B > 1; i++)
            {
                result = result * A;
            }
            if (result < 0)
                result += C;
            Console.WriteLine(result % C);
        }
        /// <summary>
        /// Given an array of integers A, find and return whether the given array contains a non-empty subarray with a sum equal to 0.
        /// If the given array contains a sub-array with sum zero return 1, else return 0.
        /// </summary>
        internal static void SubArrayEqualsZero()
        {
            var A = new List<int> { 1,-1 };
            //A = new List<int> { 1, 2, -2, 1 };
            var map = new Dictionary<int, int>();
            int ans = 0;
            int targetSum = 0;
            map.Add(0, targetSum);
            for (int i = 0; i < A.Count; i++)
            {
                var val = 0 - A[i];
                if (map.ContainsKey(val))
                {
                    ans = 1;
                    break;
                }
                if (!map.ContainsKey(A[i]))
                    map.Add(A[i], val);
                map[0] = map[0] + A[i];
                if (0 == map[0])
                    ans = 1;
            }
            //return ans;
            Console.WriteLine(ans);

            Console.WriteLine("\nBetter approach");
            int sum = 0;
            A.Sort();
            var hasSet = new HashSet<int>();
            for (int i = 0;i< A.Count; i++)
            {
                sum += A[i];
                if(sum == targetSum || hasSet.Contains(sum))
                {
                    ans = 1;break;
                }
                hasSet.Add(sum);
            }

            Console.WriteLine(ans);
        }
        /// <summary>
        /// Given two integer arrays, A and B of size N and M, respectively.
        /// Your task is to find all the common elements in both the array
        /// </summary>
        internal static void CommonElementsIn2Arrays()
        {
            List<int> A = new List<int> { 1, 2, 2, 1 };
            List<int> B = new List<int> { 2, 3, 1, 2 };

            //List<int> A = new List<int> { 2, 1, 2, 4, 10 };
            //List<int> B = new List<int> { 3, 6, 2, 10, 10 };

            List<int> C = new List<int>();
            Dictionary<int, int> res = new Dictionary<int, int>();
            
            Console.WriteLine("Brute force O(n2)");
            for (int i = 0; i < A.Count; i++)
            {
                for (int j = 0; j < B.Count; j++)
                {
                    if (A[i] == B[j] && !res.ContainsValue(j))
                    {
                        if (!res.ContainsKey(i)) res.Add(i, j);
                    }
                }
            }

            //return res;
            foreach (KeyValuePair<int, int> x in res)
            {
                C.Add(A[x.Key]);
                Console.Write(A[x.Key] + " ");
            }

            Console.WriteLine("\n O(n)");
            var map = new Dictionary<int,int>();
            C = new List< int>();
            int loop = Math.Min(A.Count, B.Count);

            for (int i = 0; i < A.Count; i++)
            {
                if (map.ContainsKey(A[i]))
                {
                    var c = map[A[i]] + 1;
                    map[A[i]] = c;
                }
                else
                    map.Add(A[i], 1);
            }
            for (int i = 0; i < B.Count; i++)
            {

                if (map.ContainsKey(B[i]) && map.GetValueOrDefault(B[i])>0)
                {
                    C.Add(B[i]);
                    map[B[i]] = map.GetValueOrDefault(B[i]) - 1;
                }
            }

            
            foreach (var i in C)
                Console.Write(i + " ");
        }

        static void MaxEvenMinusMinOdd()
        {
            var A = new List<int> { -98, 54, -52, 15, 23, -97, 12, -64, 52, 85 };
            int maxEven = int.MinValue, minOdd = int.MaxValue;
            int ans = 0;
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] > maxEven && A[i] % 2 == 0) maxEven = A[i];
                if (A[i] < minOdd && A[i] % 2 != 0) minOdd = A[i];
            }

            ans = maxEven - minOdd;
            Console.WriteLine(ans);
        }
        internal static void CountOfPairsWithSum()
        {
            var A = new List<int> { 1, 2, 3, 2, 1 };
            //A = new List<int> { 1, 1, 1 };
            int B = 5;

            int count = 0;
            // Brute force O(n2)
            for (int i = 0; i < A.Count; i++)
            {
                for (int j = i + 1; j < A.Count; j++)
                {
                    if (A[i] + A[j] == B) count++;
                }
            }
            Console.WriteLine(count);

            // O(n)
            count = 0;
            Dictionary<int, int> result = new Dictionary<int, int>();
            foreach (int i in A)
            {
                if (result.ContainsKey(B - i))
                {
                    count += result.GetValueOrDefault(B-i);
                }
                result.TryAdd(i,result.GetValueOrDefault(i)+1);
            }
            //return count;
            Console.WriteLine(count);
        }
    }
}
