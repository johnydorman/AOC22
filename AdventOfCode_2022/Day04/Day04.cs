using System;
using System.IO;

namespace AdventOfCode_2022
{
    class Day04 : IDay
    {
        string filePath;

        public Day04() { filePath = "C:/Users/johnd/source/repos/AdventOfCode_2022/AdventOfCode_2022/RSS/day04.txt"; }

        public void Process()
        {
            int totalCounter = 0, partialCounter =0;
            foreach (string line in File.ReadLines(filePath))
            {
                var assignments = line.Split(',');

                int aLower = int.Parse( assignments[0].Split('-')[0] );
                int aUpper = int.Parse( assignments[0].Split('-')[1] );

                int bLower = int.Parse( assignments[1].Split('-')[0] );
                int bUpper = int.Parse( assignments[1].Split('-')[1] );
                
                if( (aLower <= bLower && aUpper >= bUpper) || (bLower <= aLower && bUpper >= aUpper) )
                {
                    totalCounter++;
                }

                if( (aLower <= bLower && aUpper >= bLower) || (bLower <= aLower && bUpper >= aLower) )
                {
                    partialCounter++;
                }
            }
            Console.WriteLine("Total Sum: " + totalCounter);
            Console.WriteLine("Partial Sum: " + partialCounter);
        }
    }
}