namespace ConsoleApp1
{
    public class Technical
    {
         public int add(int a , int b)
        { return a + b; }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           Technical technicaltechnical = new Technical();
            technicaltechnical.add(1,2);
            Console.WriteLine(technicaltechnical);
            
        }
    }
}