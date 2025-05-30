namespace CustomMinFunction;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Func<int[], int> findMin = nums =>
        {
            int min = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < min)
                    min = nums[i];
            }
            return min;
        };

        int minNumber = findMin(numbers);
        Console.WriteLine(minNumber);
    }
}