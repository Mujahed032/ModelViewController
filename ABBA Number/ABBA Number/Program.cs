using System;

namespace ABBA_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your 4 Digit Number");
            int userenter = int.Parse(Console.ReadLine());

            //Number +1 should be added in the number and square to the number if the value matches to the user that is ABBA Number

            double s = 0;
            int rev = 0;
            int temp = userenter, d;

            while (temp > 0)
            {
                d = temp % 10;
                temp = temp / 10;
                rev = rev * 10 + d;
            }
            if (userenter == rev)
            {
                 s = Math.Sqrt(userenter + 1);
            }
            if (s == (int)s)
            {
                Console.WriteLine("ABBA");
            }
            else
            {
                Console.WriteLine("Not ABBA Number");
            }
        }
    }
}