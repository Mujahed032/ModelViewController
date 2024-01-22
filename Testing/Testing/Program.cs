using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    internal class Program
    {
       
        static List<List<int>> FindSmallestDifferenceSets(int[] arr)
        {
            List<int> sortedArr = arr.OrderBy(x => x).ToList();
            List<int> set1 = new List<int>();
            List<int> set2 = new List<int>();
            int sum1 = 0, sum2 = 0;

            foreach (int num in sortedArr)
            {
                if (sum1 <= sum2)
                {
                    set1.Add(num);
                    sum1 += num;
                }
                else
                {
                    set2.Add(num);
                    sum2 += num;
                }
            }

            return new List<List<int>> { set1, set2 };
        }
        static void Main()
        {
            int[] inputArray = { 5, 10, 15, 20, 25 };
            var result = FindSmallestDifferenceSets(inputArray);

            Console.WriteLine("Sets with the smallest difference:");
            foreach (var set in result)
            {
                Console.WriteLine("{" + string.Join(", ", set) + "}");
            }
            Console.ReadLine();
        }


    }
}
