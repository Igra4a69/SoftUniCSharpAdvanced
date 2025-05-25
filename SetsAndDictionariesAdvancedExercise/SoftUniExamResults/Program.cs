namespace SoftUniExamResults;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> userPoints = new Dictionary<string, int>();
        Dictionary<string, int> languageSubmissions = new Dictionary<string, int>();

        string input;

        while ((input = Console.ReadLine()) != "exam finished")
        {
            string[] parts = input.Split('-');

            if (parts[1] == "banned")
            {
                string bannedUser = parts[0];
                if (userPoints.ContainsKey(bannedUser))
                {
                    userPoints.Remove(bannedUser);
                }
                continue;
            }

            string username = parts[0];
            string language = parts[1];
            int points = int.Parse(parts[2]);

            if (!languageSubmissions.ContainsKey(language))
            {
                languageSubmissions[language] = 0;
            }
            languageSubmissions[language]++;

            if (!userPoints.ContainsKey(username))
            {
                userPoints[username] = points;
            }
            else
            {
                if (points > userPoints[username])
                {
                    userPoints[username] = points;
                }
            }
        }

        Console.WriteLine("Results:");
        foreach (KeyValuePair<string, int> kvp in userPoints
                     .OrderByDescending(u => u.Value)
                     .ThenBy(u => u.Key))
        {
            Console.WriteLine($"{kvp.Key} | {kvp.Value}");
        }

        Console.WriteLine("Submissions:");
        foreach (KeyValuePair<string, int> kvp in languageSubmissions
                     .OrderByDescending(l => l.Value)
                     .ThenBy(l => l.Key))
        {
            Console.WriteLine($"{kvp.Key} - {kvp.Value}");
        }
    }
}