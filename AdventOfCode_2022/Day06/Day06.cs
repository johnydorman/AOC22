using System;
using System.IO;

namespace AdventOfCode_2022
{
    class Day06 : IDay
    {
        string filePath;

        public Day06() { filePath = "C:/Users/johnd/source/repos/AdventOfCode_2022/AdventOfCode_2022/RSS/day06.txt"; }
        public void Process()
        {
            var line = File.ReadAllText(filePath);

            int index = SearchString(line, 4);
            Console.WriteLine("Start-of-packet market: " + (index + 5));

            index = SearchString(line, 14);
            Console.WriteLine("End-of-packet market: " + (index + 14));
        }
        private int SearchString(string line, int len)
        {
            int index = 0;
            while (index < line.Length)
            {
                int x = CheckForDupes(line.Substring(index, len));
                if (x != -1)
                {
                    index += x;
                }
                else { break; }
            }
            return index;
        }

        public int CheckForDupes(string valueToCheck)
        {
            for(int x = 0; x < valueToCheck.Length; x++)
            {
                for(int y = 0; y < valueToCheck.Length; y++)
                {
                    if ( (x != y) && valueToCheck[x] == valueToCheck[y])
                    {
                        return x+1;
                    }
                }
            }
            return -1;
        }
    }
}