using System;
using System.Collections.Generic;
using System.Linq;

namespace P04BestLecturesSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(':')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();


            int count = int.Parse(input[1]);

            List<Lecture> lecturesCollection = new List<Lecture>();

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new char[] { ':', ' ', '-' })
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .ToArray();

                string name = tokens[0];
                int start = int.Parse(tokens[1]);
                int end = int.Parse(tokens[2]);

                Lecture current = new Lecture(name, start, end);

                lecturesCollection.Add(current);
            }

            List<Lecture> result = new List<Lecture>();



            while (lecturesCollection.Count > 0)
            {
                Lecture latest = lecturesCollection
                    .OrderBy(l => l.End)
                    .FirstOrDefault();

                result.Add(latest);

                lecturesCollection = lecturesCollection
                    .Where(x => x.Start > latest.End)
                    .ToList();
            }

            Console.WriteLine($"Lectures ({result.Count}):");
            Console.WriteLine(string.Join(Environment.NewLine, result.Select(l => $"{l.Start}-{l.End} -> {l.Name}")));

        }


    }

    public class Lecture
    {
        public Lecture(string name, int start, int end)
        {
            this.Name = name;
            this.Start = start;
            this.End = end;
        }

        public string Name { get; set; }

        public int Start { get; set; }

        public int End { get; set; }
    }
}
