namespace Count_Uppercase_Words;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        Func<string, bool> isUppercase = word =>
            !string.IsNullOrEmpty(word) && char.IsUpper(word[0]);

        string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        IEnumerable<string> uppercaseWords = words.Where(isUppercase);

        foreach (string word in uppercaseWords)
        {
            Console.WriteLine(word);
        }
    }
}