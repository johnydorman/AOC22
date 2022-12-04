using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode_2022
{
    class Day01 : IDay 
    {
        private List<Day01Elf> elves;

        public Day01()
        {
            elves = new List<Day01Elf>();
        }

        public void Process()
        {
            // Read data
            ReadCalories("C:/Users/johnd/source/repos/AdventOfCode_2022/AdventOfCode_2022/RSS/day01a.txt");

            // Order Elves
            elves = elves.OrderByDescending(x => x.Calories).ToList();

            // Elf with most
            var maxObject = elves.First();
            Console.WriteLine("Most Calories: " + maxObject.Calories);

            // top 3 elves
            var topThreeSum = elves.Take(3).Sum(x => x.Calories);
            Console.WriteLine("Top 3 Calories: " + topThreeSum);
        }

        private void ReadCalories(string filePath)
        {
            Day01Elf elf = new Day01Elf();

            foreach (string line in File.ReadLines(filePath))
            {
                if (line.Length == 0)
                {
                    elf = new Day01Elf();
                    elves.Add(elf);
                }

                try
                {
                    elf.AddCalories(int.Parse(line));
                }
                catch (Exception) { }
            }
        }
    }
}
