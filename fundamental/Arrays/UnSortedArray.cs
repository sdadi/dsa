namespace fundamental.Arrays
{
    internal class UnSortedArray
    {
        internal static void EquilibriumIndex()
        {
            //List<int> A = [-7, 1, 5, 2, -4, 3, 0];
            List<int> A = [-7653, -3893, 2371, 4846, 5531, 7995, -9637, 2740, -5807, -5974, -8040, -5191, 2756, 7044, 1702, 2357, 6428, -3363, -7233, 356, 1161, -6762, 3844, -2591, 1683, -1529, -1485, 5264, 5837, 6942, -2790, 362, -3670, 8013, -882, 1014, 869, -4855, -5179, 2357, -8530, 3458, -3298, 9639, 9387, -3568, -4375, -2076, 6962, 1023, 6093, 7771, -4167, 5472, 710, -1886, -7533, 5588, 1830, -7054, -8271, 7956, 9231, -8723, 133, 5288, -7930, 6596, 9084, 3889, -1322, -9644, -1845, -6600, -3502, -1679, -524, -2646, -7516, 7477, 3345, -9345, 6552, -9659, -8228, 8736, -3801, 2717, -5218, 33, -9392, -737, -343, -5206, -5151, -192, 9857, -7362, 6713, 7524, 1892, 2156, -4224, 8030, -5094, 959, 9250, -4588, -4368, 3531, 5868, -9777, 7064, -5718, 6412, -189, -4323, -5987, 8161, 2709, 7433, 9648, -185, 270, -1299, -1976, -4157, -4372, -7090, -633, -9468, -8274, 9549, -6744, 2385, 8156, 5688, -792, -3338, 2283, 6503, -9786, 3878, 9541, -6152, 3785, 9396, -9695, -6004, 3621, -645, -3609, 2176, 6398, 1248, 2320, -4962, 5011, -8832, 6127, -7635, -6142, -4646, 3047, -2509, -4769, 4140, 5508, 9420, 8120, -2694, 6560, 8398, -100, 5759, 2696, 5696, 7748, -9611, 1007, -5228, 8574, 4507, -1011, 2723, -9726, 179, -2428, 9181, 4898, -8915, 7768, -5208, 8306, -2659, 3844, -661, 8452, 6041, 1380, 7817, 8973, 6751, -4815, 5347, -2711, 188, -5371, -679, -8278, 1903, -5038, -5791, -7893, 6515, -4994, 4527, -2608, -1213, 6028, 8742, -4275, -4817, -6160, 6422, -1766, -8639, 6205, -3150, 4615, 7417, 8710, -6074, -344, 4148, 1425, -632, -9160, 3297, -7114, 5159, 1386, 9770, 2347, -3587, -3875, -2635, 5048, -5901, -7484, 8975, -4308, 161, 299, -4049, -8815, -7762, 7018, -7943, 237, -6695, 7629, -7953, 9459, 4735, -3829, 9727, -6403, 5466, 6218, -5877, 2033, -4857, 1585, 514, -6989, 5236, -9830, -5191, 5947, 2560, -4052, -8077, -1288, 492, -4326, -492, 2294, -4923, -5192, 5162, 3137, 5975, 7399, -5645, 4187, -8523, 3651, -2419, 7813, 6036, -7307, 8254, 7936, -9467, 5581, -3412, 7572, 5229, 101, 1171, 8309, -6208, -8279, 444, -2281, -2046, -8015, 9570, -7134, 4339, 5946, 3592, -3576, -886, -4246, -610, 8529, 114, 6778, -7997, 7117, 7970, -9467, 1722, -1286, 3767, -930, 7682, -3814, -4258, -3810, -8109, -9843, 8266, -732, 6784, -8437, 2357, -4750, -7906, -9440, -4353, -7544, 8803, 5253, 5256, -5497, 8886, 4304, 8080, 908, 6009, 4940, -9357, 3402, -1661, -1435, 5537, -7720, 5460, -872, -1353, -5385, 9094, -4783, 9087, -8572, -1667, 1788, -7608, 2228, 6087, 2984, 7494, -7699, -2480, -3224, -7232, 4543, -6029, -2972, 9430, 8164, 1959, -2684, -2414, -8991, -3467, -4217, -1649, 837, 4336, -2265, -3976, 9518, -734, 4976, 3196, 8596, -6076, -1447, -4851, 4907, -478, -7859, -5003, 8428, -9053, 4681, -795, 3330, 5359, -5970, -220, -7393, 1088, -1559, -9193, 7574, 6186, -9753, -9647, 7090, 443, -4809, 3298, 6116, 2494, 7231, 3493, -6231, -6764, -6311, 5140, 5977, 4169, 5221, 4568, -1875, 7542, 9705, 2771, -718, 3135, 5548, -1085, 3003, -3784, -2730, -6471, 9204, 9575, -8391, -3986, 1410, -5961, 4005, -6029, -6209, 8290, 2692, 3424, 5242, -8314, 4330, -2775, 4755, 8850, 2378, 8147, 5597, 8121, -5413, 7104, 9328, 5535, 0, 9065, -4788, -1505, 2202, -8444, 5989, 7361, 9707, -7802, 3466, -8042, 2077, -8845, -66, -7741, 5097, -268, -4540, -3439, -9265, -2806, 6926, 4592, 3148, -7634, 2777, -9401, -6748, -9755, 7814, -7294, -2509, -820, 338, 7721, 4314, 5798, 5146, -9934, -1057, 8088, 4854, 9482, 719, 7099, -5376, -2543, 587, 2026, -5367, -4480, 2011, -3743, 5779, -9267, -7509, 8485, -666, 1450, -4380, -1108, -2459, -7715, -3057, -1689, 436, 2696, -6039, -1375, -9400, 4052, 5780, 2796, -4295, 3960, 855, 548, -5908, -5673, -8366, 7366, -3138, -3512, 9567, -7559, 9387, -7031, 9293, -4569, -2683, -1176, 7786, -3516, -2594, 4886, 4669, 2079, -6810, -1645, -1342, 3529, 2070, -6946, 6439, 952, -1495, -4243, 8994, -6882];
            //DisplayArray(A, "");
            var pSum = new List<long>();
            long sum = A[0];
            pSum.Add(A[0]);

            for (int i = 1; i < A.Count; i++)
            {
                sum += A[i];
                pSum.Add(A[i] + pSum[i - 1]);
            }
            long leftSum = 0;
            for (int i = 0; i < A.Count; i++)
            {
                sum -= A[i];
                if (sum == leftSum)
                    Console.WriteLine(A[i]);
                leftSum += A[i];
            }
            bool hasResult = false;
            //DisplayArray(pSum, "Prefix Sum Array");
            //Console.WriteLine($"{pSum[224]}, {pSum[A.Count-1]}, {pSum[223]} == {pSum[A.Count - 1] - pSum[224]}");
            for (int i = 0; i < A.Count; i++)
            {
                long lowerSum = i == 0 ? 0 : pSum[i - 1];
                long higherSum = pSum[A.Count - 1] - pSum[i];

                if (lowerSum == higherSum)
                {
                    hasResult = true;
                    Console.WriteLine(i);
                }
            }

            if (!hasResult)
                Console.WriteLine(-1);
        }
        internal static void MagicIndexusingPrefixSum()
        {
            List<int> A = [1, 2, 3, 7, 1, 2, 3];
            List<int> evenPS = new List<int>(A.Count);
            List<int> oddPS = new List<int>(A.Count);

            evenPS.Add(A[0]);
            oddPS.Add(0);

            for (int i = 1; i < A.Count; i++)
            {
                if (i % 2 == 0)
                {
                    evenPS.Add(A[i] + evenPS[i - 1]);
                    oddPS.Add(oddPS[i - 1]);
                }
                else
                {
                    evenPS.Add(evenPS[i - 1]);
                    oddPS.Add(A[i] + oddPS[i - 1]);
                }
            }
            DisplayArray(A, string.Empty);
            DisplayArray(evenPS, "Even Prefix Sum array");
            DisplayArray(oddPS, "Odd Prefix Sum array");

            int count = 0;
            if (evenPS[A.Count - 1] - evenPS[0] == oddPS[A.Count - 1] - oddPS[0])
                count++;

            for (int i = 1; i < A.Count; i++)
            {
                int sumEven = evenPS[i - 1] + oddPS[A.Count - 1] - oddPS[i];
                int sumOdd = oddPS[i - 1] + evenPS[A.Count - 1] - evenPS[i];
                if (sumEven == sumOdd)
                    count++;
            }
            Console.WriteLine($" magic indexes count are {count}");
        }
        internal static void DisplayArray(List<int> A, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                message = "Input Array";
            Console.WriteLine(message);
            foreach (var item in A)
                Console.Write(item.ToString().PadLeft(5, ' ') + " ");
            Console.WriteLine();
            for (int i = 0; i < A.Count; i++)
                Console.Write(i.ToString().PadLeft(5, ' ') + " ");
            Console.WriteLine();
        }
        internal static void DisplayArray(List<long> A, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                message = "Input Array";
            Console.WriteLine(message);
            foreach (var item in A)
                Console.Write(item.ToString().PadLeft(5, ' ') + " ");
            Console.WriteLine();
            for (int i = 0; i < A.Count; i++)
                Console.Write(i.ToString().PadLeft(5, ' ') + " ");
            Console.WriteLine();
        }
        internal static void RotateArrayKtimes()
        {
            List<int> A = [3, 4, 5];
            int B = 2;
            Console.WriteLine("Input Array");
            foreach (var item in A)
                Console.Write(item.ToString().PadLeft(5, ' ') + " ");
            Console.WriteLine();
            for (int i = 0; i < A.Count; i++)
                Console.Write(i.ToString().PadLeft(5, ' ') + " ");
            Console.WriteLine();

            int n = A.Count;
            int k = B % n;
            Reverse(A, 0, n - 1);
            Reverse(A, 0, k - 1);
            Reverse(A, k, n - 1);

            Console.WriteLine($"Array after {B} and ideally {k} times rotation");
            for (int i = 0; i < A.Count; i++)
                Console.Write(A[i].ToString().PadLeft(5, ' ') + " ");

        }
        static void Reverse(List<int> A, int start, int end)
        {
            while (start < end)
            {
                int temp = A[start];
                A[start] = A[end];
                A[end] = temp;
                start++;
                end--;
            }
        }
        static int CountLoop = 0;
        internal static void MaxProfitInArray()
        {
            //List<int> A = [7551982, 8124939, 4023780, 7868369, 4412570, 2542961, 7380261, 1164290, 7781065, 1164599, 2563492, 5354415, 4994454, 2627136, 5933501, 668219, 1821804, 7818378, 33654, 4167689, 8652323, 5750640, 9822437, 3466466, 554089, 6168826, 335687, 2466661, 8511732, 6288553, 2905889, 7747975, 3744045, 1545003, 1008624, 8041203, 7176125, 4321092, 714053, 7200073, 166697, 7814651, 3090485, 8318668, 6600364, 3352620, 2430137, 7685821, 1442555, 828955, 6540266, 5305436, 116568, 1883410, 7975347, 9629015, 4735259, 6559041, 1832532, 5840170, 6983732, 5886179, 1496505, 7241412, 144558, 9462840, 8579314, 2488436, 9677478, 7589124, 5636642, 2440601, 1767332, 2399786, 6299635, 8534665, 1367339, 805592, 5572668, 6990026, 8465261, 4808596, 7641452, 8464860, 3170126, 7403200, 6932907, 3776122, 1313688, 3992189, 2382116, 3886952, 349816, 1596435, 7353742, 9964868, 9882224, 3818546, 3885458, 1200559, 3910256, 7949895, 463872, 6392805, 9513226, 3427933, 3470571, 6225817, 552452, 5567651, 6414423, 6701681, 4725847, 894529, 8046603, 426263, 5280891, 9197661, 9764507, 1740413, 9530261, 9163599, 7561587, 5848442, 7312422, 4794268, 5793465, 5039382, 5147388, 7346933, 4697363, 6436473, 5159752, 2207985, 8256403, 8958858, 6099618, 2172252, 3063342, 4324166, 3919237, 8985768, 2703255, 2386343, 3064166, 247762, 7271683, 1812487, 7163753, 4635382, 449426, 2561592, 3746615, 8741199, 6696192, 606265, 5374062, 3065308, 6918398, 2956279, 8949324, 2804580, 3421479, 7846658, 8895839, 8277589, 1262596, 451779, 9972218, 6378556, 4216958, 7127258, 8593578, 326883, 4737513, 6578257, 7582654, 8675499, 9038961, 7902676, 8874020, 5513073, 631930, 912719, 8394492, 1508363, 455175, 9215635, 6813970, 2021710, 5673212, 184474, 4511247, 4653238, 2218883, 9669544, 295018, 3694660, 1709444, 4019025, 5047809, 45740, 1035395, 8159408, 1557286, 1304144, 6496263, 2094202, 9945315, 1905585, 1143081, 6994125, 9609830, 1077628, 3488222, 6299366, 7187139, 3883908, 7077292, 3210807, 7328762, 7695314, 1138834, 7689433, 5083719, 202831, 8138452, 5495064, 7543763, 1597085, 5429837, 8455839, 6925605, 6600884, 3571512, 3422637, 8911245, 3700762, 2338168, 6830853, 2539094, 490627, 2294717, 497349, 8297867, 7299269, 4769134, 285033, 4335917, 9908413, 152868, 2658658, 3525848, 1884044, 4953877, 8660374, 8989154, 888731, 7217408, 2614940, 7990455, 9779818, 1441488, 9605891, 4518756, 3705442, 9331226, 404585, 9011202, 7355000, 7461968, 6512552, 2689841, 2873446, 256454, 1068037, 8786859, 2323599, 3332506, 2361155, 7476810, 5605915, 5950352, 6491737, 8696129, 4637800, 4207476, 9334774, 840248, 9159149, 5201180, 7211332, 3135016, 8524857, 4566111, 7697488, 1833291, 7227481, 8289951, 2389102, 9102789, 8585135, 1869227, 4082835, 8447466, 4985240, 4176179];
            List<int> A = [3, 4, 5, 15, 1, 3, 9, 13];

            if (A == null || !A.Any() || A.Count < 2)
            {
                Console.WriteLine("Invalid Array so profit is 0");
            }
            int minIndex = 0;
            int profit = 0;
            for (int i = 1; i < A.Count; i++)
            {
                if (A[i] >= A[minIndex])
                {
                    int t = A[i] - A[minIndex];
                    if (t > profit)
                    {
                        profit = t;
                    }
                }
                else
                    minIndex = i;
            }
            Console.WriteLine($"maxprofit is {profit}");



            //Console.WriteLine($"Max profit is {maxProfit} on day {day}");
        }
        internal static void MaxProfitBuySellDay()
        {
            List<int> A = [3, 4, 5, 15, 1, 3, 9, 13];

            if (A == null || !A.Any() || A.Count < 2)
                Console.WriteLine("Invalid Array so profit is 0");

            foreach (var item in A)
                Console.Write(item.ToString().PadLeft(5, ' ') + " ");
            Console.WriteLine();
            for (int i = 0; i < A.Count; i++)
                Console.Write(i.ToString().PadLeft(5, ' ') + " ");
            Console.WriteLine();

            var trans = new List<List<int>>();
            int minIndex = 0;
            int profitIndex = 0;
            int profit = 0;
            for (int i = 1; i < A.Count; i++)
            {
                if (A[i] >= A[minIndex])
                {
                    int t = A[i] - A[minIndex];
                    if (t > profit)
                    {
                        profit = t;
                        profitIndex = i;
                    }
                    else if (t == profit && profitIndex != i)
                    {
                        profitIndex = i;
                        trans.Add(new List<int> { minIndex, profitIndex });
                    }
                }
                else
                {
                    trans.Add(new List<int> { minIndex, profitIndex });
                    minIndex = i;
                }
            }
            if (!trans.Any(x => x[0] == minIndex))
                trans.Add(new List<int> { minIndex, profitIndex });

            foreach (var t in trans)
                Console.WriteLine($"profit is {profit} on buy at {t[0]} -> {A[t[0]]} and sell at {t[1]} -> {A[t[1]]}");
        }
        internal static void KthSmallest()
        {
            List<int> nums = [1, 4, 5, 3, 19, 3];
            int k = 5;


            int low = int.MaxValue;
            int high = int.MinValue;

            foreach (int num in nums)
            {
                low = Math.Min(low, num);
                high = Math.Max(high, num);
            }

            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (Count(nums, mid) < k)
                    low = mid + 1;
                else
                    high = mid;
            }

            Console.WriteLine($"count() loops are {CountLoop}");
            Console.WriteLine($"K'th smallest element is {low}");
        }
        internal static int Count(List<int> nums, int mid)
        {
            CountLoop++;
            int cnt = 0;
            foreach (int num in nums)
            {
                if (num <= mid)
                    cnt++;
            }
            return cnt;
        }
    }
}