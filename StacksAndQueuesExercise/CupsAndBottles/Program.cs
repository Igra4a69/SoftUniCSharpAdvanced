namespace CupsAndBottles;

class Program
{
    static void Main(string[] args)
    {
        Queue<int> cups = new Queue<int>(Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));
        Stack<int> bottles = new Stack<int>(Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));

        int wastedWater = 0;

        while (cups.Count > 0 && bottles.Count > 0)
        {
            int currentCup = cups.Peek();
            int currentBottle = bottles.Pop();

            if (currentBottle >= currentCup)
            {
                wastedWater += currentBottle - currentCup;
                cups.Dequeue();
            }
            else
            {
                currentCup -= currentBottle;
                
                cups.Dequeue();
                cups = new Queue<int>(new[] { currentCup }.Concat(cups));
            }
        }

        if (cups.Count == 0)
        {
            Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
        }
        else
        {
            Console.WriteLine($"Cups: {string.Join(' ', cups)}");
        }

        Console.WriteLine($"Wasted litters of water: {wastedWater}");
    }
}