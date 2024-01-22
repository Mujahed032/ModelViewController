using System;
using System.Collections.Generic;

class Program
{
    static string[] phoneLetters = {
        "0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"
    };

    static void Main()
    {
        string phoneNumber = "23"; // Replace with the phone number you want to generate combinations for
        List<string> combinations = LetterCombinations(phoneNumber);

        Console.WriteLine("Letter Combinations:");
        combinations.ForEach(Console.WriteLine);
    }

    static List<string> LetterCombinations(string digits)
    {
        if (string.IsNullOrEmpty(digits))
        {
            return new List<string>();
        }

        return digits.Aggregate(
            new List<string> { "" },
            (combinations, digit) =>
                combinations.SelectMany(combination =>
                    phoneLetters[digit - '0'].Select(letter => combination + letter))
                            .ToList()
        );
    }
}


