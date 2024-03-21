namespace fundamental
{
    internal class SmallestNumberProductOfDigitsIsN
    {
        public static void FindSmallest()
        {
            Console.WriteLine("Enter Number to find the smallest number whose product is equal to N");
            int n = 19;// Convert.ToInt32(Console.ReadLine());
            string ans = string.Empty;

            for(int div=9; div>1; div--)
            {
                while(n % div == 0)
                {
                    n = n/div;
                    ans = div + ans;
                }
            }
            if (n != 1) Console.WriteLine("-1");
            else Console.WriteLine(ans);
        }
    }
}
