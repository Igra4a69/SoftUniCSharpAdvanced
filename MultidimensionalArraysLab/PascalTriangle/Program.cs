namespace PascalTriangle;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        long[][] triangle = new long[n][];

        for (int row = 0; row < n; row++)
        {
            triangle[row] = new long[row + 1];
            triangle[row][0] = 1;
            triangle[row][row] = 1;

            for (int col = 1; col < row; col++)
            {
                triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
            }
        }

        for (int i = 0; i < triangle.Length; i++)
        {
            for (int j = 0; j < triangle[i].Length; j++)
            {
                Console.Write(triangle[i][j] + " ");
            }

            Console.WriteLine();
        }
    }
}