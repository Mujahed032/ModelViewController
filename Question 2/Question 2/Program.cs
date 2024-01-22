namespace Question_2
{
    internal class Program
    {
        static bool PartitionKSubsets(List<int> arr, int k, int currentIndex, List<List<int>> partitions)
        {
            if (currentIndex == arr.Count)
                return partitions.All(p => p.Sum() == partitions[0].Sum());

            for (int i = 0; i < k; i++)
            {
                partitions[i].Add(arr[currentIndex]);
                if (PartitionKSubsets(arr, k, currentIndex + 1, partitions))
                    return true;
                partitions[i].RemoveAt(partitions[i].Count - 1);
            }

            return false;
        }

        static List<List<int>> PartitionIntoKSubsets(List<int> arr, int k)
        {
            int totalSum = arr.Sum();
            if (totalSum % k != 0)
                return null;

            List<List<int>> partitions = Enumerable.Range(0, k).Select(_ => new List<int>()).ToList();
            return PartitionKSubsets(arr, k, 0, partitions) ? partitions : null;
        }

        static void Main(string[] args)
        {
            List<int> S = new List<int> { 7, 3, 5, 12, 2, 1, 5, 3, 8, 4, 6, 4 };
            int k = 4;

            List<List<int>> result = PartitionIntoKSubsets(S, k);

            if (result != null)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    Console.WriteLine($"S{i + 1} = {{ {string.Join(", ", result[i])} }}");
                }
            }
            else
            {
                Console.WriteLine($"Cannot partition S into {k} equal-sum subsets.");
            }
        }
    }

    }