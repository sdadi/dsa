using Helpers;
using static System.Net.Mime.MediaTypeNames;

namespace _3Advanced
{
    internal class Stack2
    {
        /// <summary>
        /// Given an array A, find the nearest smaller element G[i] for every element A[i] in the array such that the element has an index smaller than i.
        /// More formally,
        /// G[i] for an element A[i] = an element A[j] such that
        /// j is maximum possible AND
        /// j<i AND
        /// A[j] < A[i]
        /// Elements for which no smaller element exist, consider the next smaller element as -1.
        /// Problem Constraints
        /// 1 <= |A| <= 100000
        /// -10^9 <= A[i] <= 10^9
        /// </summary>
        public static void NearestSmallestElement()
        {
            List<int> A = [4, 5, 2, 10, 8];//[-1, 4, -1, 2, 2]
            //A = [3, 2, 1];// [-1, -1, -1]
            

            Stack stack = new Stack();
            var result = new List<int>();
            
            for (int i = 0; i < A.Count; i++)
            {
                while(!stack.IsEmpty() && stack.Peek() >= A[i])
                {
                    stack.Pop();
                }
                if (stack.IsEmpty())
                {
                    result.Add(-1);
                }
                else
                {
                    result.Add(stack.Peek());
                }
                stack.Push(A[i]);
            }
            result.PrintArray();
        }
        /// <summary>
        /// Given an array of integers A.
        /// A represents a histogram i.e A[i] denotes the height of the ith histogram's bar. Width of each bar is 1.
        /// Find the area of the largest rectangle formed by the histogram.
        /// Problem Constraints
        /// 1 <= |A| <= 100000
        /// 1 <= A[i] <= 10000
        /// </summary>
        public static void LargestRectangleInHistogram()
        {
            List<int> A = [2, 1, 5, 6, 2, 3];//10
            //A = [2];//2
            A = [90, 58, 69, 70, 82, 100, 13, 57, 47, 18];//348

            int maxArea = int.MinValue;
            var smallestLeft = GetNearestSmallestonLeft(A);
            var smallestRight = GetNearestSmallestonRight(A);
            smallestLeft.PrintArray();
            smallestRight.PrintArray();
            for(int i=0;i<A.Count; i++)
            {
                int j = smallestLeft[i];
                int k = smallestRight[i];

                maxArea = Math.Max(maxArea, A[i]*(k-j-1));
            }

            Console.WriteLine(maxArea);
        }
        private static List<int> GetNearestSmallestonLeft(List<int> A)
        {
            Stack stack = new Stack();
            var result = new List<int>();

            for (int i = 0; i < A.Count; i++)
            {
                while (!stack.IsEmpty() && A[stack.Peek()] >= A[i])
                {
                    stack.Pop();
                }
                if (stack.IsEmpty())
                {
                    result.Add(-1);
                }
                else
                {
                    result.Add(stack.Peek());
                }
                stack.Push(i);
            }
            return result;
        }
        private static List<int> GetNearestSmallestonRight(List<int> A)
        {
            Stack stack = new Stack();
            var result = new List<int>();

            foreach (var item in A)
                result.Add(A.Count);

            for (int i = A.Count-1; i >= 0; i--)
            {
                while (!stack.IsEmpty() && A[stack.Peek()] >= A[i])
                {
                    stack.Pop();
                }
                if (!stack.IsEmpty())
                {
                    result[i] = stack.Peek();
                }
                stack.Push(i);
            }
            return result;
        }

        /// <summary>
        /// Given an array A, find the next greater element G[i] for every element A[i] in the array.
        /// The next greater element for an element A[i] is the first greater element on the right side of A[i] in the array, A.
        /// More formally:
        /// G[i] for an element A[i] = an element A[j] such that
        /// j is minimum possible AND
        /// j > i AND
        /// A[j] > A[i]
        /// Elements for which no greater element exists, consider the next greater element as -1.
        /// Problem Constraints
        /// 1 <= |A| <= 10^5
        /// 1 <= A[i] <= 10^7
        /// </summary>
        public static void NearestGreaterOnRight()
        {
            List<int> A = [4, 5, 2, 10];// [5, 10, 10, -1]

            //A = [3, 2, 1];//[-1, -1, -1] 

            var result = new List<int>();
            var stack = new Stack<int>();
            int N = A.Count;

            foreach (var i in A)
                result.Add(-1);

            for (int i = N - 1; i >= 0; i--)
            {
                while(stack.Count > 0 && stack.Peek() <= A[i])
                {
                    stack.Pop();
                }
                if(stack.Count > 0)
                {
                    result[i] = stack.Peek();
                }
                stack.Push(A[i]);
            }

            result.PrintArray();
        }

        /// <summary>
        /// Given an array of integers A.
        /// The value of an array is computed as the difference between the maximum element in the array and the minimum element in the array A.
        /// Calculate and return the sum of values of all possible subarrays of A modulo 109+7.
        /// Problem Constraints
        /// 1 <= |A| <= 100000
        /// 1 <= A[i] <= 1000000
        /// </summary>
        public static void MaxMinDifferenceSubArrays()
        {
            List<int> A = [1];//0

            //A = [4, 7, 3, 8];//26
            A = [994390, 986616, 976849, 979707, 950477, 968402, 992171, 937674, 933065, 960863, 980981, 937319, 951236, 959547, 991052, 991799, 992213, 941294, 978103, 997198, 960759, 988476, 963517, 980366, 921767, 979757, 977912, 983761, 981869, 947454, 930202, 999086, 973538, 999798, 996446, 944001, 974217, 951595, 942688, 975075, 970973, 970130, 897109, 927660, 862233, 997130, 986068, 954098, 978175, 889682, 988973, 996036, 969675, 985751, 977724, 881538, 988613, 924230, 906475, 915565, 986952, 975702, 994316, 964011, 986848, 983699, 949076, 989673, 981788, 929094, 988310, 926471, 994763, 999736, 980762, 973560, 996622, 934475, 998365, 966255, 998697, 998700, 911868, 983245, 996382, 996992, 953142, 994104, 987303, 853837, 960626, 904203, 998063, 977596, 977868, 996012, 946345, 949255, 988138, 996298, 954933, 965036, 886976, 998628, 990878, 953725, 916744, 985233, 919661, 970903, 986066, 982834, 996134, 988578, 924067, 964987, 895871, 989569, 991934, 993670, 928504, 971382, 960979, 998169, 973228, 988281, 983189, 991485, 944233, 973783, 941261, 923792, 985917, 972178, 995552, 932538, 977948, 831043, 982500, 974932, 980093, 995555, 855119, 987762, 990660, 996979, 931854, 978143, 982252, 999221, 932885, 996105, 997326, 996647, 976042, 970619, 975097, 998109, 871025, 951901, 979738, 900284, 998956, 987627, 921089, 989769, 958835, 992974, 976595, 959604, 859028, 993491, 976455, 998222, 950918, 973438, 977098, 999331, 985052, 902616, 964024, 998017, 964862, 982286, 992021, 999432, 988790, 983432, 998257, 898200, 982149, 961846, 981776, 972586, 943520, 989744, 996782, 936912, 982773, 984487, 964704, 978053, 990572, 982577, 877360, 993485, 993128, 982365, 957996, 984782, 964986, 929686, 946512, 993638, 989743, 981187, 999291, 964851, 964919, 965233, 930389, 957153, 986534, 922734, 994292, 993966, 983035, 939292, 994130, 999256, 957902, 877167, 972310, 927470, 921104, 996656, 955604, 934894, 995249, 996579, 991386, 990653, 986682, 985974, 993285, 903581, 971714, 924382, 986343, 977598, 933679, 974313, 982100, 970408, 907216, 997984, 950850, 958622, 984158, 993847, 929720, 923348, 967208, 999597, 988348, 998811, 961541, 966362, 940613, 981003, 993594, 968554, 981285, 930932, 991355, 993263, 878745, 993563, 915412, 966036, 999838, 969211, 975704, 979385, 990821, 942093, 976357, 942635, 997959, 989237, 939642, 968693, 930209, 994538, 935784, 954249, 944245, 990888, 987848, 988546, 999588, 999028, 992032, 917869, 894288, 968699, 873965, 972781, 985545, 993724, 996463, 923395, 805403, 974413, 990780, 982119, 984037, 869141, 983980, 876028, 963988, 997833, 932782, 975124, 966784, 987924, 928141, 968885, 980773, 982960, 974977, 967643, 995021, 996808, 952551, 873877, 990787, 889355, 989604, 963856, 954631, 962090, 873838, 896439, 993785, 973575, 990782, 891989, 977470, 974062, 983977, 991962, 923453, 986950, 962334, 982877, 988008, 965207, 997111, 994131, 989699, 993494, 975880, 964154, 910941, 952384, 976645, 948814, 950258, 990702, 942481, 999928, 997402, 985579, 955724, 957814, 992773, 994346, 960551, 999916, 985146, 980016, 971405, 915730, 979996, 971264, 947553, 993662, 916492, 949623, 957551, 914712, 994517, 991254, 995253, 985502, 986418, 991954, 974334, 985759, 996473, 994193, 969665, 957951, 959110, 987361, 967935, 994191, 893930, 983508, 973786, 990594, 980434, 998035, 942603, 991289, 987485, 999339, 894427, 994267, 953575, 972110, 970077, 998136, 942218, 958445, 930803, 995974, 991771, 932667, 916064, 995595, 945371, 992587, 957625, 994702, 985472, 987117, 972295, 984889, 965561, 963310, 998823, 954436, 967833, 984504, 977643, 999765, 997027, 895941, 997151, 982125, 927318, 946063, 997652, 987731, 991662, 977362, 935595, 980203, 964915, 952077, 984666, 991081, 978349, 851943, 939403, 993074, 866294, 981672, 943037, 932016, 952104, 968450, 955030, 995370, 994658, 945375, 964813, 884068, 995510, 980270, 993480, 930747, 922657, 985952, 988767, 997878, 998039, 996152, 906651, 967207, 971668, 957100, 981743, 976162, 987856, 975561, 929266, 978997, 976910, 990538, 972836, 989490, 964325, 942220, 979891, 868086, 971086, 996444, 992072, 988563, 991291, 969749, 977935, 863017, 934178, 999180, 890192, 871282, 966302, 976429, 944495, 987868, 883763, 995840, 945981, 992396, 915496, 984916, 989150, 871770];//402832155

            int N = A.Count;    
            var ngLeft = new List<int>();
            var ngRight = new List<int>();
            var nsLeft = new List<int>();
            var nsRight = new List<int>();

            var stack = new Stack<int>();
            long result = 0, mod = 1000000007;

            foreach(int i in A)
            {
                ngRight.Add(N);
                nsRight.Add(N);
            }

            for(int i=0;i<N; i++)
            {
                while(stack.Count > 0 && A[stack.Peek()] >= A[i])
                {
                    stack.Pop();
                }
                nsLeft.Add(stack.Count > 0 ? stack.Peek():-1);
                stack.Push(i);
            }

            stack = new Stack<int>();
            for(int i = N - 1; i >= 0; i--)
            {
                while(stack.Count > 0 && A[stack.Peek()] >= A[i])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                    nsRight[i] = stack.Peek();
                stack.Push(i);
            }

            stack = new Stack<int>();
            for(int i=0;i<N; i++)
            {
                while(stack.Count > 0 && A[stack.Peek()] <= A[i])
                {
                    stack.Pop();
                }
                ngLeft.Add(stack.Count > 0? stack.Peek():-1);
                stack.Push(i);
            }

            stack = new Stack<int>();
            for(int i=N-1; i>=0; i--)
            {
                while(stack.Count > 0 && A[stack.Peek()] <= A[i])
                {
                    stack.Pop();
                }
                if(stack.Count > 0)
                    ngRight[i] = stack.Peek();
                stack.Push(i);
            }
            //A.PrintArray();
            //nsLeft.PrintArray();
            //nsRight.PrintArray();
            //ngLeft.PrintArray(); 
            //ngRight.PrintArray();
            for(int i=0; i<N ; i++)
            {
                int sl = nsLeft[i];
                int sr = nsRight[i];
                int gl = ngLeft[i];
                int gr = ngRight[i];

                long max = (i - gl) * (gr - i);
                long min = (i - sl) * (sr - i);
                result += A[i] * (max - min);
            }
            Console.WriteLine((int)(result%mod));
        }
    }
}
