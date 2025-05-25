namespace ForceBook;

class Program
{
    static void Main(string[] args)
    {

        Dictionary<string, string> userSide = new Dictionary<string, string>();

        string input;
        while ((input = Console.ReadLine()) != "Lumpawaroo")
        {
            if (input.Contains(" | "))
            {

                string[] parts = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                string forceSide = parts[0];
                string forceUser = parts[1];


                if (!userSide.ContainsKey(forceUser))
                {
                    userSide[forceUser] = forceSide;
                }
            }
            else if (input.Contains(" -> "))
            {

                string[] parts = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string forceUser = parts[0];
                string forceSide = parts[1];

                if (userSide.ContainsKey(forceUser))
                {

                    if (userSide[forceUser] != forceSide)
                    {
                        userSide[forceUser] = forceSide;
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                }
                else
                {

                    userSide[forceUser] = forceSide;
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }
        }


        Dictionary<string, List<string>> sideUsers = new Dictionary<string, List<string>>();

        foreach (KeyValuePair<string, string> entry in userSide)
        {
            string user = entry.Key;
            string side = entry.Value;

            if (!sideUsers.ContainsKey(side))
            {
                sideUsers[side] = new List<string>();
            }

            sideUsers[side].Add(user);
        }


        foreach (KeyValuePair<string, List<string>> entry in sideUsers
                     .OrderByDescending(s => s.Value.Count)
                     .ThenBy(s => s.Key))
        {
            string side = entry.Key;
            List<string> users = entry.Value;
            if (users.Count > 0)
            {
                Console.WriteLine($"Side: {side}, Members: {users.Count}");
                foreach (string user in users.OrderBy(u => u))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}