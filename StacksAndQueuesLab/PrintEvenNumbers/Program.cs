namespace PrintEvenNumbers;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        Queue<int> queue = new Queue<int>(numbers);

        List<int> evenNumbers = new List<int>();

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            if (current % 2 == 0)
            {
                evenNumbers.Add(current);
            }
        }
        
        Console.WriteLine(string.Join(", ", evenNumbers));
    }
}