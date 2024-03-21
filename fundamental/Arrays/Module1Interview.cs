namespace fundamental.Arrays
{
    internal class Module1Interview
    {
        internal static void ColourfulNumber()
        {
            int A = 23;
            var hashSet = new HashSet<int>();
            var digits = new List<int>();

            while (A > 0)
            {
                digits.Insert(0,(A % 10));
                A = A / 10;
            }

            for (int i = 0; i < digits.Count; i++)
            {
                int product = 1;
                for (int j = i; j < digits.Count; j++)
                {
                    product *= digits[j];
                    if (!hashSet.Contains(product))
                        hashSet.Add(product);
                    else
                    {
                        Console.WriteLine(0);
                        return;
                    }
                }
            }
            Console.WriteLine(1);
        }
        internal static void CheckAnagram()
        {
            string A = "cat";
            A.Substring(0, "a".Length);
            string B = "bat";
            var hashMap = new Dictionary<char, int>();

            if (A.Trim().Length == 0 && B.Trim().Length == 0)
                Console.WriteLine(0);

            for(int i=0;i<A.Length;i++)
            {
                char c = A[i];
                if (hashMap.ContainsKey(c))
                {
                    hashMap[c] += 1;
                }
                else
                {
                    hashMap.Add(c, 1);
                }
            }

            foreach (char c in B)
            {
                if (hashMap.ContainsKey(c))
                {
                    if (hashMap[c] > 0)
                    {
                        hashMap[c] -= 1;
                    }
                    else
                    {
                        Console.WriteLine("0");
                    }
                }
            }
            foreach(var m in hashMap)
            {
                if(m.Value > 0)
                {
                    Console.WriteLine(0);
                    break;
                }
                  
            }
            Console.WriteLine(1);
        }
        internal static void MajorityN3rd()
        {
            List<int> a = [1];
            if (a.Count == 1)
                Console.WriteLine(a[0]);
            else if (a.Count == 2)
                Console.WriteLine(a[0]);
            int first = a[0];
            int second = a[1];

            int count1 = 0;
            int count2 = 0;

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] == first)
                    count1++;
                else if (a[i] == second)
                    count2++;
                else if (count1 == 0)
                {
                    first = a[i];
                    count1 = 1;
                }
                else if (count2 == 0)
                {
                    second = a[i];
                    count2 = 1;
                }
                else
                {
                    count1--;
                    count2--;
                }
            }
            count1 = count2 = 0;
            foreach (var cand in a)
            {
                if (cand == first)
                    count1++;
                if (cand == second)
                    count2++;
            }
            int majorityCount = a.Count / 3;
            if (count1 > majorityCount)
                Console.WriteLine(first);
            else if(count2 > majorityCount)
                Console.WriteLine(second);
            else
                Console.WriteLine(-1);
        }
        internal static void RowToColumnZero()
        {
            //List<List<int>> A = [
            //                    [1, 2, 3, 4],
            //                    [5, 6, 7, 0],
            //                    [9, 2, 0, 4]
            //                    ];
            List<List<int>> A = [[97,18,55,1,50,17,16,0,22,14],[58,14,75,54,11,23,54,95,33,23],[73,11,2,80,6,43,67,82,73,4],[61,22,23,68,23,73,85,91,25,7],[6,83,22,81,89,85,56,43,32,89],[0,6,1,69,86,7,64,5,90,37],[10,3,11,33,71,86,6,56,78,31],[16,36,66,90,17,55,27,26,99,59],[67,18,65,68,87,3,28,52,9,70],[41,19,73,5,52,96,91,10,52,21]];
            Helper.DisplayMatrix(A);
            bool hasZero = false;
            for (int row = 0; row < A.Count; row++)
            {
                hasZero = false;
                for (int col = 0; col < A[row].Count; col++)
                {
                    if (A[row][col] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
                if (hasZero)
                {
                    for (int col = 0; col < A[row].Count; col++)
                    {
                        if (A[row][col] != 0)
                            A[row][col] = -1;
                    }
                }
            }

            for (int col = 0; col < A[0].Count; col++)
            {
                hasZero = false;

                for (int row = 0; row < A.Count; row++)
                {
                    if (A[row][col] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
                if (hasZero)
                {
                    for (int row = 0; row < A.Count; row++)
                    {
                        if (A[row][col] != 0)
                            A[row][col] = -1;
                    }
                }
            }

            for(int row=0;row<A.Count; row++)
            {
                for(int col=0; col < A[row].Count; col++)
                {
                    if (A[row][col] == -1)
                        A[row][col] = 0;
                }
            }

            Console.WriteLine();
            Helper.DisplayMatrix<int>(A);
        }
        internal static void LongestConsecutive1s()
        {
            string A = "000000000000000";
            int result = int.MinValue;
            int count = 0;

            foreach (var c in A)
            {
                if (c == '1')
                    count++;
            }
            if (count == A.Length)
            {
                Console.WriteLine(count);
                return;
            }
                

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == '0')
                {
                    int l = 0, r = 0;
                    for (int left = i - 1; left >= 0; left--)
                    {
                        if (A[left] == '1')
                            l++;
                        else
                            break;
                    }

                    for (int right = i + 1; right < A.Length; right++)
                    {
                        if (A[right] == '1')
                            r++;
                        else
                            break;
                    }
                    result = Math.Max(result, (r + l + 1));
                }
            }

            Console.WriteLine(result);
        }
    }
}
