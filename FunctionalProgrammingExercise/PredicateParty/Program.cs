namespace PredicateParty;

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] guestsInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        List<string> guests = new List<string>(guestsInput);

        string commandLine;
        while ((commandLine = Console.ReadLine()) != "Party!")
        {
            string[] commandParts = commandLine.Split(' ', 3);
            string action = commandParts[0]; 
            string criteria = commandParts[1]; 
            string parameter = commandParts[2];

            Predicate<string> filter = CreatePredicate(criteria, parameter);

            if (action == "Remove")
            {
                guests.RemoveAll(filter);
            }
            else if (action == "Double")
            {
                List<string> toAdd = new List<string>();
                for (int i = 0; i < guests.Count; i++)
                {
                    if (filter(guests[i]))
                    {
                        toAdd.Add(guests[i]);
                    }
                }
                guests.AddRange(toAdd);
            }
        }

        if (guests.Count == 0)
        {
            Console.WriteLine("Nobody is going to the party!");
        }
        else
        {
            Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
        }
    }

    static Predicate<string> CreatePredicate(string criteria, string parameter)
    {
        if (criteria == "StartsWith")
        {
            return name => name.StartsWith(parameter);
        }
        else if (criteria == "EndsWith")
        {
            return name => name.EndsWith(parameter);
        }
        else if (criteria == "Length")
        {
            int length = int.Parse(parameter);
            return name => name.Length == length;
        }
        else
        {
            return null;
        }
    }
}
