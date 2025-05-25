using System;
using System.Collections.Generic;

class RadioactiveMutantVampireBunnies
{
    static int rows, cols;
    static char[,] lair;
    static int playerRow, playerCol;
    static bool playerDead = false;
    static bool playerWon = false;

    static void Main()
    {
        string[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        rows = int.Parse(size[0]);
        cols = int.Parse(size[1]);

        lair = new char[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            string line = Console.ReadLine();
            for (int c = 0; c < cols; c++)
            {
                lair[r, c] = line[c];
                if (lair[r, c] == 'P')
                {
                    playerRow = r;
                    playerCol = c;
                }
            }
        }

        string commands = Console.ReadLine();

        foreach (char cmd in commands)
        {
            MovePlayer(cmd);
            SpreadBunnies();

            if (playerDead || playerWon)
            {
                break;
            }
        }

        PrintLair();

        if (playerWon)
        {
            Console.WriteLine($"won: {playerRow} {playerCol}");
        }
        else if (playerDead)
        {
            Console.WriteLine($"dead: {playerRow} {playerCol}");
        }
    }

    static void MovePlayer(char cmd)
    {
        int nextRow = playerRow;
        int nextCol = playerCol;

        switch (cmd)
        {
            case 'U': nextRow--; break;
            case 'D': nextRow++; break;
            case 'L': nextCol--; break;
            case 'R': nextCol++; break;
        }

        if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols)
        {
            lair[playerRow, playerCol] = '.';
            playerWon = true;
            return;
        }

        if (lair[nextRow, nextCol] == 'B')
        {
            lair[playerRow, playerCol] = '.';
            playerRow = nextRow;
            playerCol = nextCol;
            playerDead = true;
            return;
        }

        lair[playerRow, playerCol] = '.';
        playerRow = nextRow;
        playerCol = nextCol;
        lair[playerRow, playerCol] = 'P';
    }

    static void SpreadBunnies()
    {
        List<(int, int)> bunnies = new List<(int, int)>();

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (lair[r, c] == 'B')
                {
                    bunnies.Add((r, c));
                }
            }
        }

        foreach (var (r, c) in bunnies)
        {
            int[] dR = { -1, 1, 0, 0 };
            int[] dC = { 0, 0, -1, 1 };

            for (int i = 0; i < 4; i++)
            {
                int nr = r + dR[i];
                int nc = c + dC[i];

                if (nr >= 0 && nr < rows && nc >= 0 && nc < cols)
                {
                    if (lair[nr, nc] == '.')
                    {
                        lair[nr, nc] = 'B';
                    }
                    else if (lair[nr, nc] == 'P')
                    {
                        playerDead = true;
                    }
                }
            }
        }
    }

    static void PrintLair()
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Console.Write(lair[r, c]);
            }
            Console.WriteLine();
        }
    }
}
