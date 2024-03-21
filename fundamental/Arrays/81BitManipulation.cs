using System.Text;

namespace fundamental.Arrays
{
    internal class BitManipulation
    {
        internal static void NumberToBinary()
        {
            int n = 439;

            int result = 0;
            int maxOnes = 0;
            StringBuilder sb = new StringBuilder();
            int mod = 0;

            while (n > 0)
            {
                mod = n % 2;
                if (mod == 1)
                {
                    result++;
                    if (result > maxOnes)
                        maxOnes = result;
                }
                else
                {
                    result = 0;
                }
                sb.Insert(0, mod);
                n = n / 2;
            }
            if (n == 1)
            {
                result++;
                if(result > maxOnes) 
                    maxOnes = result;
            }

            Console.WriteLine(maxOnes);
        }
        internal static void AndOp()
        {
            int a = 20, b = 45;

            int c = a & b;

            Console.WriteLine($"{Convert.ToString(a, 2).PadLeft(8,'0')} is binary of {a}");
            Console.WriteLine($"{Convert.ToString(b, 2).PadLeft(8, '0')} is binary of {b}");
            Console.WriteLine($"{Convert.ToString(c, 2).PadLeft(8, '0')} is binary of {c}");
            Console.WriteLine($"{c} is Decimal Value of {a}&{b}");
        }
        internal static void XOR()
        {
            int a = 20, b = 45;

            int c = a ^ b;

            Console.WriteLine($"{Convert.ToString(a, 2).PadLeft(8, '0')} is binary of {a}");
            Console.WriteLine($"{Convert.ToString(b, 2).PadLeft(8, '0')} is binary of {b}");
            Console.WriteLine($"{Convert.ToString(c, 2).PadLeft(8, '0')} is binary of {c}");
            Console.WriteLine($"{c} is Decimal Value of {a}^{b}");
        }
        internal static void Add2Binary()
        {
            string A = "1010110111001101101000";
            string B = "1000011011000000111100110";
            //1001110001111010101001110

            int i = A.Length-1;
            int j = B.Length-1;
            StringBuilder result = new StringBuilder();

            int carry=0, sum=0;

            while(i >=0 ||  j >=0)
            {
                sum = 0;
                if (i >= 0)
                {
                    sum += A[i] == '0' ? 0 : 1;
                    i--;
                }
                if(j>= 0)
                {
                    sum += B[j] == '0' ? 0 : 1;
                    j--;
                }
                sum += carry;
                carry = sum / 2;
                result.Insert(0, (sum%2));
            }
            if (carry == 1)
                result.Insert(0,(1%2));
            Console.WriteLine(result);
            Console.WriteLine("1001110001111010101001110 - expected");
        }
        internal static void Add2Binary1()
        {
            string A = "100";
            string B = "11";

            int AL = A.Length;
            int BL = B.Length;
            string result = "";

            int N = AL;
            if (BL > AL)
                N = BL;
            if (N != AL)
                A = A.PadLeft(N, '0');
            if (N != BL)
                B = B.PadLeft(N, '0');

            int carry = 0, sum = 0;

            for (int i = N - 1; i >= 0; i--)
            {
                int a = A[i] == '0' ? 0 : 1;
                int b = B[i] == '0' ? 0 : 1;
                sum = a + b + carry;
                carry = (sum) / 2;
                result = (sum % 2).ToString() + result;
            }
            if (carry == 1)
                result = (1 % 2) + result;
            Console.WriteLine(result);
        }
    }
}
