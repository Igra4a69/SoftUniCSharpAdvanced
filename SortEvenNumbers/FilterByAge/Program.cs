using System;
using System.Collections.Generic;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Person> people = ReadPeople(n);

        string condition = Console.ReadLine();
        int ageThreshold = int.Parse(Console.ReadLine());
        string format = Console.ReadLine();

        Predicate<Person> filter = CreateFilter(condition, ageThreshold);
        Action<Person> printer = CreatePrinter(format);

        PrintFilteredPeople(people, filter, printer);
    }

    static List<Person> ReadPeople(int count)
    {
        List<Person> people = new List<Person>();

        for (int i = 0; i < count; i++)
        {
            string[] parts = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string name = parts[0];
            int age = int.Parse(parts[1]);

            Person person = new Person { Name = name, Age = age };
            people.Add(person);
        }

        return people;
    }

    static Predicate<Person> CreateFilter(string condition, int ageThreshold)
    {
        if (condition == "older")
        {
            return person => person.Age >= ageThreshold;
        }
        else 
        {
            return person => person.Age < ageThreshold;
        }
    }

    static Action<Person> CreatePrinter(string format)
    {
        if (format == "name")
        {
            return person => Console.WriteLine(person.Name);
        }
        else if (format == "age")
        {
            return person => Console.WriteLine(person.Age);
        }
        else 
        {
            return person => Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }

    static void PrintFilteredPeople(List<Person> people, Predicate<Person> filter, Action<Person> printer)
    {
        foreach (Person person in people)
        {
            if (filter(person))
            {
                printer(person);
            }
        }
    }
}
