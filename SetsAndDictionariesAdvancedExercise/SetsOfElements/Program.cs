namespace SetsOfElements;

class Program
{
    static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine().Split();
        int n = int.Parse(tokens[0]);
        int m = int.Parse(tokens[1]);

        List<int> firstSetOrder = new List<int>();
        HashSet<int> firstSet = new HashSet<int>();
        HashSet<int> secondSet = new HashSet<int>();

        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            if (!firstSet.Contains(num))
            {
                firstSet.Add(num);
                firstSetOrder.Add(num);
            }
        }

        for (int i = 0; i < m; i++)
        {
            int num = int.Parse(Console.ReadLine());
            secondSet.Add(num);
        }

        foreach (int num in firstSetOrder)
        {
            if (secondSet.Contains(num))
            {
                Console.Write(num + " ");
            }
        }
    }
}