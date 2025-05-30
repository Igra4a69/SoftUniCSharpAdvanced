using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] bounds = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int lower = int.Parse(bounds[0]);
        int upper = int.Parse(bounds[1]);

        string condition = Console.ReadLine();

        Predicate<int> filter;

        if (condition == "even")
        {
            filter = num => num % 2 == 0;
        }
        else // odd
        {
            filter = num => num % 2 != 0;
        }

        List<int> result = new List<int>();

        for (int i = lower; i <= upper; i++)
        {
            if (filter(i))
            {
                result.Add(i);
            }
        }

        Console.WriteLine(string.Join(" ", result));
    }
}