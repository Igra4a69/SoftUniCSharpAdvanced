using System;

class Miner
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        char[,] field = new char[n, n];
        int minerRow = -1;
        int minerCol = -1;
        int totalCoals = 0;

        for (int i = 0; i < n; i++)
        {
            string[] rowInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < n; j++)
            {
                field[i, j] = rowInput[j][0];
                if (field[i, j] == 's')
                {
                    minerRow = i;
                    minerCol = j;
                }
                else if (field[i, j] == 'c')
                {
                    totalCoals++;
                }
            }
        }

        int collectedCoals = 0;

        foreach (string command in commands)
        {
            int nextRow = minerRow;
            int nextCol = minerCol;

            switch (command)
            {
                case "up":
                    if (minerRow - 1 >= 0)
                        nextRow = minerRow - 1;
                    break;
                case "down":
                    if (minerRow + 1 < n)
                        nextRow = minerRow + 1;
                    break;
                case "left":
                    if (minerCol - 1 >= 0)
                        nextCol = minerCol - 1;
                    break;
                case "right":
                    if (minerCol + 1 < n)
                        nextCol = minerCol + 1;
                    break;
            }

            if (nextRow != minerRow || nextCol != minerCol)
            {
                minerRow = nextRow;
                minerCol = nextCol;

                if (field[minerRow, minerCol] == 'c')
                {
                    collectedCoals++;
                    field[minerRow, minerCol] = '*';
                    if (collectedCoals == totalCoals)
                    {
                        Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                        return;
                    }
                }
                else if (field[minerRow, minerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    return;
                }
            }
        }

        int remainingCoals = totalCoals - collectedCoals;
        Console.WriteLine($"{remainingCoals} coals left. ({minerRow}, {minerCol})");
    }
}
