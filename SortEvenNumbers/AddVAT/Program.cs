namespace AddVAT;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        string[] inputPrices = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
        double[] pricesWithVAT = inputPrices
            .Select(price => double.Parse(price) * 1.20)
            .ToArray();

        foreach (double price in pricesWithVAT)
        {
            Console.WriteLine($"{price:F2}");
        }
    }
}