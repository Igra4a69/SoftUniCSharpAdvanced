namespace TriFunction;

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int targetSum = int.Parse(Console.ReadLine());
        string[] namesInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        List<string> names = new List<string>(namesInput);

        Func<string, int, bool> checkSum = (name, sum) =>
        {
            int total = 0;
            for (int i = 0; i < name.Length; i++)
            {
                total += (int)name[i];
            }
            return total >= sum;
        };

        string result = FindFirstName(names, targetSum, checkSum);
        Console.WriteLine(result);
    }

    static string FindFirstName(List<string> names, int sum, Func<string, int, bool> condition)
    {
        for (int i = 0; i < names.Count; i++)
        {
            if (condition(names[i], sum))
            {
                return names[i];
            }
        }
        return null;
    }
}
