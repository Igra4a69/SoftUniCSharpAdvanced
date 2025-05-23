namespace AverageStudentGrades;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = input[0];
            decimal grade = decimal.Parse(input[1]);

            if (!studentGrades.ContainsKey(name))
            {
                studentGrades[name] = new List<decimal>();
            }

            studentGrades[name].Add(grade);
        }

        foreach (KeyValuePair<string, List<decimal>> student in studentGrades)
        {
            Console.Write($"{student.Key} -> ");

            foreach (decimal grade in student.Value)
            {
                Console.Write($"{grade:F2} ");
            }

            decimal average = student.Value.Average();
            Console.WriteLine($"(avg: {average:F2})");
        }
    }
}