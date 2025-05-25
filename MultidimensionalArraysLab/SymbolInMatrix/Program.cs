namespace SymbolInMatrix;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        char[,] matrix = new char[n, n];

        for (int row = 0; row < n; row++)
        {
            string line = Console.ReadLine();
            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = line[col];
            }
        }

        char symbol = char.Parse(Console.ReadLine());

        bool found = false;

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (matrix[row, col] == symbol)
                {
                    Console.WriteLine($"({row}, {col})");
                    found = true;
                    return; 
                }
            }
        }

        if (!found)
        {
            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}