using System;
using System.IO;

namespace AdventOfCode_2022
{
    class Day02 : IDay
    {
        string filePath;
        int[] w = { 2, 3, 1 };
        int[] l = { 3, 1, 2 };

        public Day02() { filePath = "C:/Users/johnd/source/repos/AdventOfCode_2022/AdventOfCode_2022/RSS/day02.txt"; }

        public void Process()
        {
            int stratOne = 0, stratTwo = 0;
            int aaa = 64, xxx = 87;

            foreach (string line in File.ReadLines(filePath))
            {
                int first = line[0] - aaa;
                int second = line[2] - xxx;
                int secondAdapted = GenOutput(first, line[2] - xxx);

                stratOne += CalcScore(first, second);
                stratTwo += CalcScore(first, secondAdapted);

            }
            Console.WriteLine("Strat 1: " + stratOne);
            Console.WriteLine("Strat 2: " + stratTwo);
        }

        private int GenOutput(int first, int second)
        {
            switch (second)
            {
                case 1:
                    return l[first-1];
                case 2:
                    return first;
                case 3:
                    return w[first-1];
            }
            return -1;
        }
        private int CalcScore(int a, int b)
        {
            switch (a - b)
            {
                case 0:
                    return 3 + b;
                case -1:
                case 2:
                    return 6 + b;
                default:
                    return b;
            }
        }
    }
}