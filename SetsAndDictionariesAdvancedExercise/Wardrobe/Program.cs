namespace Wardrobe;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split(" -> ");
            string color = parts[0];
            string[] clothes = parts[1].Split(',');

            if (!wardrobe.ContainsKey(color))
            {
                wardrobe[color] = new Dictionary<string, int>();
            }

            for (int j = 0; j < clothes.Length; j++)
            {
                string item = clothes[j];
                if (!wardrobe[color].ContainsKey(item))
                {
                    wardrobe[color][item] = 0;
                }

                wardrobe[color][item]++;
            }
        }

        string[] search = Console.ReadLine().Split();
        string searchColor = search[0];
        string searchClothing = search[1];

        foreach (KeyValuePair<string, Dictionary<string, int>> colorPair in wardrobe)
        {
            Console.WriteLine(colorPair.Key + " clothes:");
            foreach (KeyValuePair<string, int> itemPair in colorPair.Value)
            {
                Console.Write("* " + itemPair.Key + " - " + itemPair.Value);
                if (colorPair.Key == searchColor && itemPair.Key == searchClothing)
                {
                    Console.Write(" (found!)");
                }

                Console.WriteLine();
            }
        }
    }
}