namespace ListOfPredicates;

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] dividerStrings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        int[] dividers = new int[dividerStrings.Length];
        for (int i = 0; i < dividerStrings.Length; i++)
        {
            dividers[i] = int.Parse(dividerStrings[i]);
        }

        List<Predicate<int>> predicates = new List<Predicate<int>>();
        for (int i = 0; i < dividers.Length; i++)
        {
            int currentDivider = dividers[i]; 
            predicates.Add(number => number % currentDivider == 0);
        }

        List<int> divisibleNumbers = FindDivisibleNumbers(n, predicates);

        Console.WriteLine(string.Join(' ', divisibleNumbers));
    }

    static List<int> FindDivisibleNumbers(int n, List<Predicate<int>> predicates)
    {
        List<int> result = new List<int>();

        for (int number = 1; number <= n; number++)
        {
            bool isDivisibleByAll = true;
            for (int i = 0; i < predicates.Count; i++)
            {
                if (!predicates[i](number))
                {
                    isDivisibleByAll = false;
                    break;
                }
            }

            if (isDivisibleByAll)
            {
                result.Add(number);
            }
        }

        return result;
    }
}
