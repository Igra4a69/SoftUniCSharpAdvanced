namespace CountSymbols;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        SortedDictionary<char, int> symbolCounts = new SortedDictionary<char, int>();

        for (int i = 0; i < input.Length; i++)
        {
            char symbol = input[i];

            if (symbolCounts.ContainsKey(symbol))
            {
                symbolCounts[symbol]++;
            }
            else
            {
                symbolCounts[symbol] = 1;
            }
        }

        foreach (KeyValuePair<char, int> pair in symbolCounts)
        {
            Console.WriteLine(pair.Key + ": " + pair.Value + " time/s");
        }
    }
}