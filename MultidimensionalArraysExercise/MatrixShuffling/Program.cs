namespace MatrixShuffling;

class Program
{
    static void Main(string[] args)
    {
        string[] sizeInput = Console.ReadLine().Split(' ');
        int rows = int.Parse(sizeInput[0]);
        int cols = int.Parse(sizeInput[1]);

        string[,] matrix = new string[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            string[] inputRow = Console.ReadLine().Split(' ');
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = inputRow[col];
            }
        }

        string command = Console.ReadLine();
        while (command != "END")
        {
            string[] parts = command.Split(' ');

            int row1 = 0;
            int col1 = 0;
            int row2 = 0;
            int col2 = 0;

            if (parts.Length == 5 && parts[0] == "swap")
            {
                bool isValid =
                    int.TryParse(parts[1], out row1) &&
                    int.TryParse(parts[2], out col1) &&
                    int.TryParse(parts[3], out row2) &&
                    int.TryParse(parts[4], out col2);

                if (isValid &&
                    row1 >= 0 && row1 < rows &&
                    col1 >= 0 && col1 < cols &&
                    row2 >= 0 && row2 < rows &&
                    col2 >= 0 && col2 < cols)
                {
                    string temp = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = temp;

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            Console.Write(matrix[row, col] + " ");
                        }

                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }

            command = Console.ReadLine();
        }
    }
}
