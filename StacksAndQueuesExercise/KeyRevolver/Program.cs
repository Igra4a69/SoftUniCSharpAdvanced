namespace KeyRevolver;

class Program
{
    static void Main(string[] args)
    {
        int bulletPrice = int.Parse(Console.ReadLine());
        int barrelSize = int.Parse(Console.ReadLine());
        Stack<int> bullets = new Stack<int>(Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));
        Queue<int> locks = new Queue<int>(Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));
        int intelligenceValue = int.Parse(Console.ReadLine());

        int bulletsUsedInCurrentBarrel = 0;
        int totalBulletsUsed = 0;

        while (bullets.Count > 0 && locks.Count > 0)
        {
            int currentBullet = bullets.Pop();
            bulletsUsedInCurrentBarrel++;
            totalBulletsUsed++;

            int currentLock = locks.Peek();

            if (currentBullet <= currentLock)
            {
                Console.WriteLine("Bang!");
                locks.Dequeue();
            }
            else
            {
                Console.WriteLine("Ping!");
            }
            
            if (bulletsUsedInCurrentBarrel == barrelSize && bullets.Count > 0)
            {
                Console.WriteLine("Reloading!");
                bulletsUsedInCurrentBarrel = 0;
            }
        }

        if (locks.Count == 0)
        {
            int bulletsLeft = bullets.Count;
            int moneyEarned = intelligenceValue - (totalBulletsUsed * bulletPrice);
            Console.WriteLine($"{bulletsLeft} bullets left. Earned ${moneyEarned}");
        }
        else
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
    }
}