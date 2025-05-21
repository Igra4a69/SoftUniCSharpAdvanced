namespace FashionBoutique;

class Program
{
    static void Main(string[] args)
    {
        Stack<int> clothes = new Stack<int>(
            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
        );

        int rackCapacity = int.Parse(Console.ReadLine());

        int racksUsed = 1;
        int currentSum = 0;

        while (clothes.Count > 0)
        {
            int cloth = clothes.Peek();

            if (currentSum + cloth == rackCapacity)
            {
                currentSum = 0;
                racksUsed++;
                clothes.Pop();
            }
            else if (currentSum + cloth < rackCapacity)
            {
                currentSum += cloth;
                clothes.Pop();
            }
            else
            {
                racksUsed++;
                currentSum = 0;
            }
        }

        Console.WriteLine(racksUsed);
    }
}