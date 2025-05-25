namespace JaggedArrayModification;

class Program
{
    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        int[][] matrix = new int[rows][];

        for (int row = 0; row < rows; row++)
        {
            matrix[row] = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] tokens = command.Split();
            string action = tokens[0];
            int row = int.Parse(tokens[1]);
            int col = int.Parse(tokens[2]);
            int value = int.Parse(tokens[3]);

            if (row < 0 || row >= matrix.Length ||
                col < 0 || col >= matrix[row].Length)
            {
                Console.WriteLine("Invalid coordinates");
                continue;
            }

            if (action == "Add")
            {
                matrix[row][col] += value;
            }
            else if (action == "Subtract")
            {
                matrix[row][col] -= value;
            }
        }

        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(' ', row));
        }
    }
}