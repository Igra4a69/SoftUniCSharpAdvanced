namespace ProductShop;

class Program
{
    static void Main(string[] args)
    {
        SortedDictionary<string, Dictionary<string, double>> shops =
            new SortedDictionary<string, Dictionary<string, double>>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Revision")
            {
                break;
            }

            string[] parts = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string shop = parts[0];
            string product = parts[1];
            double price = double.Parse(parts[2]);

            if (!shops.ContainsKey(shop))
            {
                shops[shop] = new Dictionary<string, double>();
            }

            shops[shop][product] = price;
        }

        foreach (KeyValuePair<string, Dictionary<string, double>> shopEntry in shops)
        {
            Console.WriteLine($"{shopEntry.Key}->");
            foreach (KeyValuePair<string, double> productEntry in shopEntry.Value)
            {
                Console.WriteLine($"Product: {productEntry.Key}, Price: {productEntry.Value}");
            }
        }
    }
}