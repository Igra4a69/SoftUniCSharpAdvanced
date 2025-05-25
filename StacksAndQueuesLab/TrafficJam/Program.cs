namespace TrafficJam;

class Program
{
    static void Main(string[] args)
    {
        int carsPerGreen = int.Parse(Console.ReadLine()); 
        Queue<string> queue = new Queue<string>();      
        int totalPassed = 0;

        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            if (input == "green")
            {
                for (int i = 0; i < carsPerGreen && queue.Count > 0; i++)
                {
                    string car = queue.Dequeue();
                    Console.WriteLine($"{car} passed!");
                    totalPassed++;
                }
            }
            else
            {
                queue.Enqueue(input);
            }
        }

        Console.WriteLine($"{totalPassed} cars passed the crossroads.");
    }
}