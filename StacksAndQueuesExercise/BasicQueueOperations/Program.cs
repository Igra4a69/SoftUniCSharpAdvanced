namespace BasicQueueOperations;

class Program
{
    static void Main(string[] args)
    {
        int[] inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = inputs[0]; 
        int s = inputs[1]; 
        int x = inputs[2]; 
        
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Queue<int> queue = new Queue<int>();
        
        for (int i = 0; i < n; i++)
        {
            queue.Enqueue(numbers[i]);
        }
        
        for (int i = 0; i < s && queue.Count > 0; i++)
        {
            queue.Dequeue();
        }
        
        if (queue.Count == 0)
        {
            Console.WriteLine(0);
        }
        else if (queue.Contains(x))
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine(queue.Min());
        }
    }
}