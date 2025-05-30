using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Predicate<string> isShortEnough = name => name.Length <= n;

        PrintFilteredNames(names, isShortEnough);
    }

    static void PrintFilteredNames(string[] names, Predicate<string> predicate)
    {
        for (int i = 0; i < names.Length; i++)
        {
            if (predicate(names[i]))
            {
                Console.WriteLine(names[i]);
            }
        }
    }
}