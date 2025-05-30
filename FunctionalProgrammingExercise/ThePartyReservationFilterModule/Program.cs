namespace ThePartyReservationFilterModule;

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] guestsInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        List<string> guests = new List<string>(guestsInput);

        List<Predicate<string>> filters = new List<Predicate<string>>();

        string commandLine;
        while ((commandLine = Console.ReadLine()) != "Print")
        {
            string[] parts = commandLine.Split(';', StringSplitOptions.RemoveEmptyEntries);
            string command = parts[0];       
            string filterType = parts[1];    
            string parameter = parts[2];

            Predicate<string> filter = CreatePredicate(filterType, parameter);

            if (command == "Add filter")
            {
                filters.Add(filter);
            }
            else if (command == "Remove filter")
            {
                for (int i = 0; i < filters.Count; i++)
                {
                    bool same = true;
                    foreach (string testName in guests)
                    {
                        if (filters[i](testName) != filter(testName))
                        {
                            same = false;
                            break;
                        }
                    }
                    if (same)
                    {
                        filters.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        for (int i = 0; i < filters.Count; i++)
        {
            guests.RemoveAll(filters[i]);
        }

        if (guests.Count == 0)
        {
            Console.WriteLine("Nobody is going to the party!");
        }
        else
        {
            Console.WriteLine(string.Join(" ", guests));
        }
    }

    static Predicate<string> CreatePredicate(string filterType, string parameter)
    {
        if (filterType == "Starts with")
        {
            return name => name.StartsWith(parameter);
        }
        else if (filterType == "Ends with")
        {
            return name => name.EndsWith(parameter);
        }
        else if (filterType == "Length")
        {
            int length = int.Parse(parameter);
            return name => name.Length == length;
        }
        else if (filterType == "Contains")
        {
            return name => name.Contains(parameter);
        }
        else
        {
            return null;
        }
    }
}
