namespace SnakeMoves;

using System;

class Program
{
    static void Main(string[] args)
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);

        string snake = Console.ReadLine();
        char[,] matrix = new char[rows, cols];

        int snakeIndex = 0;

        for (int row = 0; row < rows; row++)
        {
            if (row % 2 == 0)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = snake[snakeIndex];
                    snakeIndex++;
                    if (snakeIndex >= snake.Length)
                    {
                        snakeIndex = 0;
                    }
                }
            }
            else
            {
                for (int col = cols - 1; col >= 0; col--)
                {
                    matrix[row, col] = snake[snakeIndex];
                    snakeIndex++;
                    if (snakeIndex >= snake.Length)
                    {
                        snakeIndex = 0;
                    }
                }
            }
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}