﻿namespace PrimaryDiagonal;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        for (int row = 0; row < n; row++)
        {
            int[] rowData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = rowData[col];
            }
        }
        
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += matrix[i, i];
        }

        Console.WriteLine(sum);
    }
}