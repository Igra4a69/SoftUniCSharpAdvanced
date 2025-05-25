namespace SongsQueue;

class Program
{
    static void Main(string[] args)
    {
        Queue<string> songsQueue = new Queue<string>(
            Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
        );

        HashSet<string> songsSet = new HashSet<string>(songsQueue);

        while (songsQueue.Count > 0)
        {
            string commandLine = Console.ReadLine();
            string[] parts = commandLine.Split(' ', 2);
            string command = parts[0];

            if (command == "Play")
            {
                string playedSong = songsQueue.Dequeue();
                songsSet.Remove(playedSong);
            }
            else if (command == "Add")
            {
                string songToAdd = parts[1];

                if (songsSet.Contains(songToAdd))
                {
                    Console.WriteLine($"{songToAdd} is already contained!");
                }
                else
                {
                    songsQueue.Enqueue(songToAdd);
                    songsSet.Add(songToAdd);
                }
            }
            else if (command == "Show")
            {
                Console.WriteLine(string.Join(", ", songsQueue));
            }
        }

        Console.WriteLine("No more songs!");
    }
}