namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var Array = new int[] { 5, 15, 15, 25, 35 };

            //int sum = 0;

            //foreach (var item in Array)
            //{
            //    sum += item;
              
            //}
            //Console.WriteLine("Sum: " + sum);

            var (number, index) = Array.Select((n, i) => (n, i)).Max();

            Console.WriteLine("biggest numbers are "+ number);
            Console.WriteLine("smallest numbers are " + index);
        }
    }
   
}