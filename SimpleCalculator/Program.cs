namespace SimpleCalculator;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Stack<string> stack = new Stack<string>();
        
        for (int i = tokens.Length - 1; i >= 0; i--)
        {
            stack.Push(tokens[i]);
        }

        int result = int.Parse(stack.Pop());

        while (stack.Count > 0)
        {
            string op = stack.Pop();       
            int number = int.Parse(stack.Pop()); 

            if (op == "+")
            {
                result += number;
            }
            else if (op == "-")
            {
                result -= number;
            }
        }

        Console.WriteLine(result);
    }
}