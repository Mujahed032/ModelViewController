namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 10; i++)
            {
                Guid g = new Guid();
                Console.WriteLine(g.ToString());
            }
            
            Console.WriteLine("Hello, World!");
        }
    }
}