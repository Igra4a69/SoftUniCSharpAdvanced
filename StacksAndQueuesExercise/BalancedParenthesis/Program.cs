namespace BalancedParenthesis;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        Console.WriteLine(IsBalanced(input) ? "YES" : "NO");
    }

    static bool IsBalanced(string s)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char ch in s)
        {
            if (ch == '(' || ch == '{' || ch == '[')
            {
                stack.Push(ch);
            }
            else
            {
                if (stack.Count == 0)
                    return false;

                char top = stack.Pop();

                if (!IsMatchingPair(top, ch))
                    return false;
            }
        }

        return stack.Count == 0;
    }

    static bool IsMatchingPair(char open, char close)
    {
        return (open == '(' && close == ')') ||
               (open == '{' && close == '}') ||
               (open == '[' && close == ']');
    }
}