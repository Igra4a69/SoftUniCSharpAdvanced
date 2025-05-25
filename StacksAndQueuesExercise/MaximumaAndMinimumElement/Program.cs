namespace MaximumaAndMinimumElement;

class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        Stack<int> stack = new Stack<int>();
        Stack<int> maxStack = new Stack<int>();
        Stack<int> minStack = new Stack<int>();

        for (int i = 0; i < N; i++)
        {
            string[] query = Console.ReadLine().Split();

            int type = int.Parse(query[0]);

            if (type == 1)
            {
                int x = int.Parse(query[1]);
                stack.Push(x);
                
                if (maxStack.Count == 0 || x >= maxStack.Peek())
                {
                    maxStack.Push(x);
                }
                else
                {
                    maxStack.Push(maxStack.Peek());
                }
                
                if (minStack.Count == 0 || x <= minStack.Peek())
                {
                    minStack.Push(x);
                }
                else
                {
                    minStack.Push(minStack.Peek());
                }
            }
            else if (type == 2)
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                    maxStack.Pop();
                    minStack.Pop();
                }
            }
            else if (type == 3)
            {
                if (stack.Count > 0)
                {
                    Console.WriteLine(maxStack.Peek());
                }
            }
            else if (type == 4)
            {
                if (stack.Count > 0)
                {
                    Console.WriteLine(minStack.Peek());
                }
            }
        }

        if (stack.Count > 0)
        {
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}