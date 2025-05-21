using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine() ?? "0");
            StringBuilder text = new StringBuilder();
            Stack<string> history = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string? line = Console.ReadLine();
                if (line == null) break;
                string[] input = line.Split(' ', 2);
                string command = input[0];

                if (command == "1")
                {
                    history.Push(text.ToString());
                    string toAppend = input[1];
                    text.Append(toAppend);
                }
                else if (command == "2")
                {
                    history.Push(text.ToString());
                    int count = int.Parse(input[1]);
                    text.Remove(text.Length - count, count);
                }
                else if (command == "3")
                {
                    int index = int.Parse(input[1]) - 1;
                    Console.WriteLine(text[index]);
                }
                else if (command == "4")
                {
                    if (history.Count > 0)
                    {
                        text = new StringBuilder(history.Pop());
                    }
                }
            }
        }
    }
}