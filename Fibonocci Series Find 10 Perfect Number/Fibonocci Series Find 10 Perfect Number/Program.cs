namespace Fibonocci_Series_Find_10_Perfect_Number
{
    internal class Program
    {


        // Function to check if a number is a perfect number
        static bool IsPerfectNumber(int num)
        {
            int sum = 1; // Start with 1 because every number is divisible by 1
            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                {
                    sum += i;
                    if (i * i != num)
                    {
                        sum += num / i;
                    }
                }
            }
            return sum == num;
        }

        static void Main()
        {
            int count = 0;
            int a = 0, b = 1;

            Console.WriteLine("First 10 Fibonacci numbers that are perfect numbers:");

            while (count < 10)
            {
                int temp = a;
                a = b;
                b = temp + b;

                if (IsPerfectNumber(a))
                {
                    Console.WriteLine(a);
                    count++;
                }
            }
        }
    }

}

