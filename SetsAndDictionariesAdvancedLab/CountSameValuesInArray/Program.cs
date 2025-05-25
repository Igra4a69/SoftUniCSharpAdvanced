namespace CountSameValuesInArray;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        double[] numbers = new double[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            numbers[i] = double.Parse(input[i]);
        }

        Dictionary<double, int> counts = new Dictionary<double, int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            double number = numbers[i];
            if (counts.ContainsKey(number))
            {
                counts[number]++;
            }
            else
            {
                counts[number] = 1;
            }
        }

        foreach (KeyValuePair<double, int> kvp in counts)
        {
            Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
        }
    }
}