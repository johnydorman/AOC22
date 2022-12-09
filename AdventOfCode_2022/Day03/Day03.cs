using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode_2022
{
    class Day03 : IDay
    {
        string filePath;

        public Day03() { filePath = "C:/Users/johnd/source/repos/AdventOfCode_2022/AdventOfCode_2022/RSS/day03.txt"; }

        public int CharToValue(int x)
        {
            if (x < 95)
            {
                return x - 38;
            }
            else
            {
                return x - 96;
            }
        }

        public void Process()
        {
            HashSet<char>[] elfGroup = new HashSet<char>[3];
            int gCounter = 0;

            int pSum = 0, gSum = 0;
            foreach (string line in File.ReadLines(filePath))
            {
                int bSize = line.Length / 2;

                var p1 = new HashSet<char>(line.Substring(0, bSize));
                var p2 = new HashSet<char>(line.Substring(bSize, bSize));

                p1.IntersectWith(p2);
                pSum += CharToValue(p1.First());

                elfGroup[gCounter] = new HashSet<char>(line);
                if(++gCounter == 3)
                {
                    elfGroup[0].IntersectWith(elfGroup[1]);
                    elfGroup[0].IntersectWith(elfGroup[2]);
                    gSum += CharToValue(elfGroup[0].First());

                    gCounter = 0;
                }
            }
            Console.WriteLine("Prio Sum: " + pSum);
            Console.WriteLine("Group Sum: " + gSum);
        }
    }
}