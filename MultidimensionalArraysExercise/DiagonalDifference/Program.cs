namespace DiagonalDifference;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        for (int row = 0; row < n; row++)
        {
            string[] input = Console.ReadLine().Split(' ');
            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = int.Parse(input[col]);
            }
        }

        int primaryDiagonalSum = 0;
        int secondaryDiagonalSum = 0;

        for (int i = 0; i < n; i++)
        {
            primaryDiagonalSum += matrix[i, i];               
            secondaryDiagonalSum += matrix[i, n - 1 - i];     
        }

        int difference = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
        Console.WriteLine(difference);
    }
}