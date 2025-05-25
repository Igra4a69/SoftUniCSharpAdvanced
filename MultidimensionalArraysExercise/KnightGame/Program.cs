using System;

class KnightGame
{
    static int N;
    static char[,] board;
    static int[] dx = { -2, -2, -1, -1, 1, 1, 2, 2 };
    static int[] dy = { -1, 1, -2, 2, -2, 2, -1, 1 };

    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        board = new char[N, N];

        for (int i = 0; i < N; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < N; j++)
            {
                board[i, j] = line[j];
            }
        }

        int removedKnights = 0;

        while (true)
        {
            int maxAttacks = 0;
            int knightRow = -1;
            int knightCol = -1;

            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    if (board[row, col] == 'K')
                    {
                        int attacks = CountAttacks(row, col);
                        if (attacks > maxAttacks)
                        {
                            maxAttacks = attacks;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }
            }

            if (maxAttacks == 0)
            {
                break;
            }

            board[knightRow, knightCol] = '0';
            removedKnights++;
        }

        Console.WriteLine(removedKnights);
    }

    static int CountAttacks(int row, int col)
    {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            int newRow = row + dx[i];
            int newCol = col + dy[i];

            if (IsInside(newRow, newCol) && board[newRow, newCol] == 'K')
            {
                count++;
            }
        }
        return count;
    }

    static bool IsInside(int row, int col)
    {
        return row >= 0 && row < N && col >= 0 && col < N;
    }
}
