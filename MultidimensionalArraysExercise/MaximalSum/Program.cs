namespace MaximalSum;

class Program
{
    static void Main(string[] args)
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);

        int[,] matrix = new int[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            string[] input = Console.ReadLine().Split(' ');
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = int.Parse(input[col]);
            }
        }

        int maxSum = int.MinValue;
        int bestRow = 0;
        int bestCol = 0;

        for (int row = 0; row <= rows - 3; row++)
        {
            for (int col = 0; col <= cols - 3; col++)
            {
                int currentSum =
                    matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                    matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                    matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }

        Console.WriteLine("Sum = " + maxSum);
        for (int row = bestRow; row < bestRow + 3; row++)
        {
            for (int col = bestCol; col < bestCol + 3; col++)
            {
                Console.Write(matrix[row, col] + " ");
            }

            Console.WriteLine();
        }
    }
}