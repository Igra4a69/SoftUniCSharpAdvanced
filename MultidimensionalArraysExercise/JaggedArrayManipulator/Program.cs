namespace JaggedArrayManipulator;

class Program
{
    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        double[][] jagged = new double[rows][];

        for (int row = 0; row < rows; row++)
        {
            jagged[row] = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
        }

        for (int row = 0; row < rows - 1; row++)
        {
            if (jagged[row].Length == jagged[row + 1].Length)
            {
                jagged[row] = jagged[row].Select(x => x * 2).ToArray();
                jagged[row + 1] = jagged[row + 1].Select(x => x * 2).ToArray();
            }
            else
            {
                jagged[row] = jagged[row].Select(x => x / 2).ToArray();
                jagged[row + 1] = jagged[row + 1].Select(x => x / 2).ToArray();
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string action = parts[0];
            int row = int.Parse(parts[1]);
            int col = int.Parse(parts[2]);
            int value = int.Parse(parts[3]);

            if (row >= 0 && row < rows && col >= 0 && col < jagged[row].Length)
            {
                if (action == "Add")
                {
                    jagged[row][col] += value;
                }
                else if (action == "Subtract")
                {
                    jagged[row][col] -= value;
                }
            }
        }

        foreach (var row in jagged)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}