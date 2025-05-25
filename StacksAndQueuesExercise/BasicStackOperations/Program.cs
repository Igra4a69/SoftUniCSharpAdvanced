namespace BasicStackOperations;

class Program
{
    static void Main(string[] args)
    {
        int[] inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = inputs[0]; 
        int s = inputs[1]; 
        int x = inputs[2]; 
        
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Stack<int> stack = new Stack<int>();
        
        for (int i = 0; i < n; i++)
        {
            stack.Push(numbers[i]);
        }
        for (int i = 0; i < s && stack.Count > 0; i++)
        {
            stack.Pop();
        }
        
        if (stack.Count == 0)
        {
            Console.WriteLine(0);
        }
        else if (stack.Contains(x))
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine(stack.Min());
        }
    }
}