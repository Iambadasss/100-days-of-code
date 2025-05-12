
class Program
{
    static void Main()
    {
        Console.Write("Enter a word or sentence: ");
        string input = Console.ReadLine();

        string cleanedInput = "";
        foreach (char c in input.ToLower())
        {
            if (char.IsLetter(c))
            {
                cleanedInput += c;
            }
        }

        Dictionary<char, int> charCount = new Dictionary<char, int>();

        foreach (char c in cleanedInput)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }


        foreach (char c in cleanedInput)
        {
            if (charCount[c] == 1)
            {
                Console.WriteLine($"First non-repeating character: {c}");
                return;
            }
        }

        Console.WriteLine("No unique character found.");
    }
}
