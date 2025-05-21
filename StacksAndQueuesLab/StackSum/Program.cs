namespace StackSum;

class Program
{
    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>(
            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
        );

        string command;
        while ((command = Console.ReadLine().ToLower()) != "end")
        {
            string[] parts = command.Split();
            string action = parts[0];

            if (action == "add")
            {
                int num1 = int.Parse(parts[1]);
                int num2 = int.Parse(parts[2]);
                stack.Push(num1);
                stack.Push(num2);
            }
            else if (action == "remove")
            {
                int count = int.Parse(parts[1]);
                if (stack.Count >= count)
                {
                    for (int i = 0; i < count; i++)
                    {
                        stack.Pop();
                    }
                }
            }
        }

        Console.WriteLine($"Sum: {stack.Sum()}");
    }
}