namespace Largest3Numbers;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[] sortedDescending = numbers
            .OrderByDescending(x => x)
            .ToArray();

        int count = Math.Min(3, sortedDescending.Length);

        for (int i = 0; i < count; i++)
        {
            Console.Write($"{sortedDescending[i]} ");
        }
    }
}