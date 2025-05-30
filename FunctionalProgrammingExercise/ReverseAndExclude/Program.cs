namespace ReverseAndExclude;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        int n = int.Parse(Console.ReadLine());

        Predicate<int> isDivisible = x => x % n == 0;

        Func<List<int>, List<int>> reverseAndExclude = nums =>
        {
            List<int> reversed = nums.AsEnumerable().Reverse().ToList();
            return reversed.FindAll(x => !isDivisible(x));
        };

        List<int> result = reverseAndExclude(numbers);

        Console.WriteLine(string.Join(" ", result));
    }
}