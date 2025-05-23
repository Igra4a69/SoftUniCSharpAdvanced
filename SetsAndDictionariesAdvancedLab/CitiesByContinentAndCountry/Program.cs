namespace CitiesByContinentAndCountry;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, Dictionary<string, List<string>>> data =
            new Dictionary<string, Dictionary<string, List<string>>>();

        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string continent = parts[0];
            string country = parts[1];
            string city = parts[2];

            if (!data.ContainsKey(continent))
            {
                data[continent] = new Dictionary<string, List<string>>();
            }

            if (!data[continent].ContainsKey(country))
            {
                data[continent][country] = new List<string>();
            }

            data[continent][country].Add(city);
        }

        foreach (KeyValuePair<string, Dictionary<string, List<string>>> continentEntry in data)
        {
            Console.WriteLine($"{continentEntry.Key}:");
            foreach (KeyValuePair<string, List<string>> countryEntry in continentEntry.Value)
            {
                string cities = string.Join(", ", countryEntry.Value);
                Console.WriteLine($"  {countryEntry.Key} -> {cities}");
            }
        }
    }
}