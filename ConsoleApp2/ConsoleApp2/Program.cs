namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, string> keypad = new Dictionary<char, string>
        {
            {'2', "abc"}, {'3', "def"}, {'4', "ghi"},
            {'5', "jkl"}, {'6', "mno"}, {'7', "pqrs"},
            {'8', "tuv"}, {'9', "wxyz"}
        };

            Console.Write("Enter numbers (2-9): ");
            string input = Console.ReadLine();
            List<string> results = new List<string> { "" };

            foreach (char digit in input)
            {
                results = results.SelectMany(prefix => keypad[digit].Select(letter => prefix + letter)).ToList();
            }

            Console.WriteLine("Possible words:");
            foreach (string word in results)
            {
                Console.WriteLine(word);
            }
        }
    }
}