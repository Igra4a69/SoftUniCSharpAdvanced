namespace EvenTimes;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<int, int> counts = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());

            if (counts.ContainsKey(number))
            {
                counts[number]++;
            }
            else
            {
                counts[number] = 1;
            }
        }

        foreach (KeyValuePair<int, int> pair in counts)
        {
            if (pair.Value % 2 == 0)
            {
                Console.WriteLine(pair.Key);
                break;
            }
        }
    }
}