﻿namespace _1Advanced
{
    internal class _9MathModGCD
    {
        /// <summary>
        /// Scooby has 3 three integers A, B, and C.
        /// Scooby calls a positive integer special if it is divisible by B and it is divisible by C.
        /// You need to tell the number of special integers less than or equal to A.
        /// </summary>
        public static void DivisorGame()
        {
            int A = 12, B = 3, C = 2;//2
            //int A = 6, B = 1, C = 4;//1
            int count = 0;
            int g = gcd(B, C);
            int lcm = B * C /g;

            count = A / lcm;

            Console.WriteLine($"number of special integers less than or equal to A is {count}");

        }
        public static void MaxGCDAfterDeleteAny()
        {
            //List<int> A = [12, 15, 18];//6
            //List<int> A = [5, 15, 30];//15
            List<int> A = [21, 7, 3, 42, 63];//7

            var pSum = new List<int>();
            pSum.Add(A[0]);
            for (int i = 1; i < A.Count; i++)
            {
                pSum.Add(gcd(pSum[i - 1], A[i]));
            }

            var sSum = new List<int>();
            for (int i = 0; i < A.Count; i++)
            {
                sSum.Add(0);
            }

            sSum[A.Count-1] = A[A.Count - 1];
            for (int i = A.Count - 2; i >= 0; i--)
            {
                sSum[i] = gcd(sSum[i + 1], A[i]);
            }

            int result = Math.Max(sSum[1], pSum[A.Count - 2]);


            for (int i = 1; i < A.Count - 1; i++)
            {
                result = Math.Max(result, gcd(pSum[i - 1], sSum[i + 1]));
            }

            Console.WriteLine(result);
        }

        private static int gcd(int A, int B)
        {
            if (B == 0) return A;

            return gcd(B, A % B);
        }
        public static void PairSumMODm()
        {
            //List<int> A = [1, 2, 3, 4, 5];
            //int B = 2;//4

            //List<int> A= [5, 17, 100, 11];
            //int B = 28;//1

            //List<int> A = [93, 9, 46, 79, 56, 24, 10, 26, 9, 93, 31, 93, 75, 7, 4, 80, 19, 67, 49, 84, 62, 100, 17, 40, 35, 84, 14, 81, 99, 31, 100, 66, 70, 2, 11, 84, 60, 89, 13, 57, 47, 60, 59, 60, 42, 67, 89, 29, 85, 83, 42, 47, 66, 80, 88, 85, 83, 82, 16, 23, 21, 55, 26, 2, 21, 92, 85, 26, 46, 3, 7, 95, 50, 22, 84, 52, 57, 44, 4, 23, 25, 55, 41, 49];
            //int B = 37;//84

            List<int> A = [169, 291, 899, 864, 809, 102, 755, 715, 216, 933, 625, 33, 648, 305, 38, 160, 290, 684, 343, 607, 26, 303, 985, 328, 36, 940, 690, 635, 125, 797, 791, 52, 867, 487, 795, 89, 472, 952, 346, 32, 822, 796, 934, 378, 219, 138, 65, 462, 258, 588, 100, 158, 643, 351, 674, 269, 950, 795, 389, 385, 57, 42, 490, 515, 441, 255, 355, 775, 613, 349, 936, 776, 713, 784, 709, 106, 683, 961, 344, 528, 521, 466, 25, 20, 788, 116, 289, 859, 971, 281, 340, 274, 278, 458, 986, 46, 163, 445, 790, 602, 213, 749, 514, 805, 996, 52, 681, 614, 174, 668, 898, 262, 455, 907, 638, 408, 929, 202, 299, 944, 974, 646, 727, 832, 184, 334, 849, 341, 692, 508, 692, 552, 880, 59, 893, 849, 698, 386, 706, 372, 714, 929, 661, 127, 589, 1000, 275, 463, 877, 635, 628, 188, 926, 320, 199, 442, 189, 362, 101, 758, 419, 600, 716, 472, 102, 902, 789, 718, 924, 625, 252, 803, 276, 761, 375, 666, 579, 58, 390, 438, 674, 758, 367, 917, 674, 969, 977, 842, 408, 842, 742, 472, 72, 938, 502, 880, 757, 123, 156, 772, 270, 330, 138, 398, 106, 357, 736, 283, 433, 604, 103, 132, 722, 363, 728, 204, 980, 778, 225, 869, 607, 127, 512, 874, 560, 410, 853, 25, 862, 556, 766, 638, 487, 703, 522, 88, 288, 156, 789, 271, 986, 603, 8, 575];
            int B = 16;//1918
            int mod = 1000000007;
            int result = 0;
            var freq = new Dictionary<int, int>();
            for (int i = 0; i < B; i++)
            {
                freq.Add(i, 0);
            }

            for (int i = 0; i < A.Count; i++)
            {
                int val = A[i] % B;
                freq[val] += 1;
            }
            int temp = freq[0];
            result = temp * (temp - 1) / 2;
            result %= mod;

            for (int i = 1; i <= (B - 1) / 2; i++)
            {
                temp = freq[i];
                int temp2 = freq[B - i];
                result += temp * temp2;
                result %= mod;
            }

            if (B % 2 == 0)
            {
                int mid = B / 2;
                temp = freq[mid];
                result += temp * (temp - 1) / 2;
                result %= mod;
            }
            Console.WriteLine(result);
        }
    }
}
