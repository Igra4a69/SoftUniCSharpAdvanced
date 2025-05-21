namespace HotPotato;

class Program
{
    static void Main(string[] args)
    {

        string[] kids = Console.ReadLine().Split(); 
        int n = int.Parse(Console.ReadLine());      

        Queue<string> queue = new Queue<string>(kids);

        while (queue.Count > 1)
        {
            for (int i = 0; i < n - 1; i++)
            {
                string kid = queue.Dequeue();
                queue.Enqueue(kid); 
            }

            string removedKid = queue.Dequeue(); 
            Console.WriteLine($"Removed {removedKid}");
        }

        Console.WriteLine($"Last is {queue.Peek()}");

    }
}