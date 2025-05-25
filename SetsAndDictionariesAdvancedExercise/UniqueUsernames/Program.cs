namespace UniqueUsernames;

class Program
{
    static void Main(string[] args)
    {   
        int n = int.Parse(Console.ReadLine());

        HashSet<string> seen = new HashSet<string>();
        List<string> usernames = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string username = Console.ReadLine();

            if (!seen.Contains(username))
            {
                seen.Add(username);
                usernames.Add(username);
            }
        }

        foreach (string name in usernames)
        {
            Console.WriteLine(name);
        }
    }
}