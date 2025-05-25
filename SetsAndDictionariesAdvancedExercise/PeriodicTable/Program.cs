namespace PeriodicTable;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        HashSet<string> elements = new HashSet<string>();

        for (int i = 0; i < n; i++)
        {
            string[] lineElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (string el in lineElements)
            {
                elements.Add(el);
            }
        }

        List<string> sortedElements = elements.OrderBy(e => e).ToList();

        foreach (string el in sortedElements)
        {
            Console.Write(el + " ");
        }
    }
}