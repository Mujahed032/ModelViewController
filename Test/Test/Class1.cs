using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Class1
    {

        static void Main()
        {
            int[] originalArray = { 5, 10, 15, 20, 25 };

            List<int> set1 = new List<int>();
            List<int> set2 = new List<int>();

            for (int i = 0; i < originalArray.Length; i++)
            {
                if (i % 2 == 0)
                    set1.Add(originalArray[i]);
                else
                    set2.Add(originalArray[i]);
            }

            Console.WriteLine("Set 1: " + string.Join(", ", set1));
            Console.WriteLine("Set 2: " + string.Join(", ", set2));
        }

    }
}
