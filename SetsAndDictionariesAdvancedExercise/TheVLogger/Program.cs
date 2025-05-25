namespace TheVLogger;

class Program
{
    static void Main(string[] args)
    {
                Dictionary<string, HashSet<string>> followers = new Dictionary<string, HashSet<string>>();
        Dictionary<string, HashSet<string>> following = new Dictionary<string, HashSet<string>>();

        string input;
        while ((input = Console.ReadLine()) != "Statistics")
        {
            string[] tokens = input.Split();

            if (tokens[1] == "joined")
            {
                string vlogger = tokens[0];

                if (!followers.ContainsKey(vlogger))
                {
                    followers[vlogger] = new HashSet<string>();
                    following[vlogger] = new HashSet<string>();
                }
            }
            else if (tokens[1] == "followed")
            {
                string follower = tokens[0];
                string followee = tokens[2];

                if (followers.ContainsKey(follower)
                    && followers.ContainsKey(followee)
                    && follower != followee
                    && !followers[followee].Contains(follower))
                {
                    followers[followee].Add(follower);
                    following[follower].Add(followee);
                }
            }
        }

        Console.WriteLine($"The V-Logger has a total of {followers.Count} vloggers in its logs.");

        int rank = 1;

        foreach (KeyValuePair<string, HashSet<string>> vlogger in followers
            .OrderByDescending(x => x.Value.Count) // by followers descending
            .ThenBy(x => following[x.Key].Count))  // by following ascending
        {
            string name = vlogger.Key;
            int followersCount = vlogger.Value.Count;
            int followingCount = following[name].Count;

            Console.WriteLine($"{rank}. {name} : {followersCount} followers, {followingCount} following");

            if (rank == 1 && followersCount > 0)
            {
                foreach (string fan in vlogger.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"*  {fan}");
                }
            }

            rank++;
        }
    }
}