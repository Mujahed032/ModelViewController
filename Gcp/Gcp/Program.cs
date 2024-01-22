namespace Gcp
{
    internal class Program
    {
       
            static void Main(string[] args)
            {

                int num1 = 48;
                int num2 = 18;

                int gcd = FindGCD(num1, num2);

                Console.WriteLine($"GCD of {num1} and {num2} is {gcd}");
            }

        static int FindGCD(int a, int b)
        {
            // Base case
            if (b == 0)
            {
                return a;
            }
            else
            {
                return FindGCD(b, a % b);
            }
        }
    }
}