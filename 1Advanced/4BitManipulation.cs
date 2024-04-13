namespace _1Advanced
{
    internal class _4BitManipulation
    {
        public static void FindNthMagicNumber5()
        {
            int A = 10;

            int ans = 0;
            int power = 5;

            while (A > 0)
            {
                ans += A % 2 * power;
                A /= 2;
                power *= 5;
            }
            Console.WriteLine(ans);
        }
    }
}
