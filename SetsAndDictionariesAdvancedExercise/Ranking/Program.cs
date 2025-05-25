using System;
using System.Collections.Generic;
using System.Linq;

class Ranking
{
    static void Main()
    {
        Dictionary<string, string> contests = new Dictionary<string, string>();

        string input;
        while ((input = Console.ReadLine()) != "end of contests")
        {
            string[] parts = input.Split(':');
            string contest = parts[0];
            string password = parts[1];
            contests[contest] = password;
        }

        Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

        while ((input = Console.ReadLine()) != "end of submissions")
        {
            string[] tokens = input.Split("=>");

            string contest = tokens[0];
            string password = tokens[1];
            string user = tokens[2];
            int points = int.Parse(tokens[3]);

            if (contests.ContainsKey(contest) && contests[contest] == password)
            {
                if (!users.ContainsKey(user))
                {
                    users[user] = new Dictionary<string, int>();
                }

                if (!users[user].ContainsKey(contest))
                {
                    users[user][contest] = points;
                }
                else
                {
                    if (users[user][contest] < points)
                    {
                        users[user][contest] = points;
                    }
                }
            }
        }

        string bestCandidate = "";
        int bestPoints = 0;

        foreach (KeyValuePair<string, Dictionary<string, int>> userEntry in users)
        {
            int total = userEntry.Value.Values.Sum();
            if (total > bestPoints)
            {
                bestPoints = total;
                bestCandidate = userEntry.Key;
            }
        }

        Console.WriteLine($"Best candidate is {bestCandidate} with total {bestPoints} points.");
        Console.WriteLine("Ranking:");

        foreach (KeyValuePair<string, Dictionary<string, int>> userEntry in users.OrderBy(u => u.Key))
        {
            Console.WriteLine(userEntry.Key);

            foreach (KeyValuePair<string, int> contestEntry in userEntry.Value.OrderByDescending(c => c.Value))
            {
                Console.WriteLine($"#  {contestEntry.Key} -> {contestEntry.Value}");
            }
        }
    }
}
