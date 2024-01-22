namespace Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 1;

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4 - i; j++)
                {
                    Console.WriteLine("  ");
                }
                for (int j = 1; j <= i * 2 - 1; j++)
                {
                    Console.Write($"{num,3}");
                    num++;
                }
                Console.WriteLine();
            }
            Console.ReadLine();

        }
    }
}