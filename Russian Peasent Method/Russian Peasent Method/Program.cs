namespace Russian_Peasent_Method
{
    internal class Program
    {
        
            static void Main()
            {
              Console.WriteLine("Enter your first number");
              int num1 = int.Parse(Console.ReadLine());
             Console.WriteLine("Enter your first number");
             int num2 = int.Parse(Console.ReadLine());
            

                int product = RussianPeasantMultiplication(num1, num2);

                Console.WriteLine($"Product of {num1} and {num2} is {product}");
            }

            static int RussianPeasantMultiplication(int num1, int num2)
            {
                int result = 0;

                while (num2 > 0)
                {
                    if (num2 % 2 != 0) 
                    {
                        result += num1;
                    }

                    num1 *= 2; 
                    num2 /= 2; 
                }

                return result;
            }
        
    }
}