namespace Lucky_Number_From_Given_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your lucky number");
            int userenter = int.Parse(Console.ReadLine());
            // ouput should be in sinlgle digit 
            // 1347 1+3+4+7 = 15, 1+5+1 = 7;

            int d = 0;
            int ds = 0;

            do
            {
                ds = 0;
                while (userenter > 0)
                {
                    d = userenter % 10;
                    userenter = userenter / 10;
                    ds += d;
                }
                if (ds > 9)
                {
                    userenter = ds;
                }
            }
            while (ds > 9);


            Console.WriteLine(ds);
        }
    }
}