namespace TruckTour;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[] petrol = new int[n];
        int[] distance = new int[n];

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(' ');
            petrol[i] = int.Parse(input[0]);
            distance[i] = int.Parse(input[1]);
        }

        int startIndex = 0;
        long tank = 0;
        long deficit = 0;

        for (int i = 0; i < n; i++)
        {
            tank += petrol[i] - distance[i];

            if (tank < 0)
            {
                deficit += tank;
                tank = 0;
                startIndex = i + 1;
            }
        }

        if (tank + deficit >= 0)
            Console.WriteLine(startIndex);
        else
            Console.WriteLine(-1);


    }
}