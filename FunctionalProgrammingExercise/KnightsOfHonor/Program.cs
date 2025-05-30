namespace KnightsOfHonor;

class Program
{
    static void Main(string[] args)
    {
        string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Action<string> knight = name => Console.WriteLine("Sir " + name);

        foreach (string name in names)
        {
            knight(name);
        }
    }
}