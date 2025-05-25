namespace SquaresInMatrix;

class Program
{
    static void Main(string[] args)
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);

        string[,] matrix = new string[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            string[] inputLine = Console.ReadLine().Split(' ');
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = inputLine[col];
            }
        }

        int equalSquaresCount = 0;

        for (int row = 0; row < rows - 1; row++)
        {
            for (int col = 0; col < cols - 1; col++)
            {
                string topLeft = matrix[row, col];
                string topRight = matrix[row, col + 1];
                string bottomLeft = matrix[row + 1, col];
                string bottomRight = matrix[row + 1, col + 1];

                if (topLeft == topRight &&
                    topLeft == bottomLeft &&
                    topLeft == bottomRight)
                {
                    equalSquaresCount++;
                }
            }
        }

        Console.WriteLine(equalSquaresCount);
    }
}