using System;
using System.Linq;

class Bombs
{
    static int N;
    static int[,] matrix;
    static int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
    static int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        matrix = new int[N, N];

        for (int i = 0; i < N; i++)
        {
            string line = Console.ReadLine();
            string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < N; j++)
            {
                matrix[i, j] = int.Parse(tokens[j]);
            }
        }

        string bombsLine = Console.ReadLine();
        string[] bombsInput = bombsLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int b = 0; b < bombsInput.Length; b++)
        {
            string bomb = bombsInput[b];
            string[] parts = bomb.Split(',');

            int bombRow = int.Parse(parts[0]);
            int bombCol = int.Parse(parts[1]);

            if (matrix[bombRow, bombCol] <= 0)
                continue;

            int bombValue = matrix[bombRow, bombCol];
            matrix[bombRow, bombCol] = 0;

            for (int k = 0; k < 8; k++)
            {
                int newRow = bombRow + dx[k];
                int newCol = bombCol + dy[k];

                if (IsInside(newRow, newCol) && matrix[newRow, newCol] > 0)
                {
                    matrix[newRow, newCol] -= bombValue;
                }
            }
        }

        int aliveCells = 0;
        int sumOfCells = 0;

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (matrix[i, j] > 0)
                {
                    aliveCells++;
                    sumOfCells += matrix[i, j];
                }
            }
        }

        Console.WriteLine("Alive cells: " + aliveCells);
        Console.WriteLine("Sum: " + sumOfCells);

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(matrix[i, j]);
                if (j != N - 1)
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    static bool IsInside(int r, int c)
    {
        return r >= 0 && r < N && c >= 0 && c < N;
    }
}
