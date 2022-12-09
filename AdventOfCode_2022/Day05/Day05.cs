using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode_2022
{
    class Day05 : IDay
    {
        string filePath;
        Stack<char>[] stacksOne;
        Stack<char>[] stacksTwo;

        public Day05() { filePath = "C:/Users/johnd/source/repos/AdventOfCode_2022/AdventOfCode_2022/RSS/day05.txt"; }

        private void BuildStackRow(string line)
        {
            for (int indx = 1; indx < line.Length; indx += 4)
            {
                var crate = line[indx];

                if (crate != ' ')
                {
                    stacksOne[(int)indx / 4].Push(crate);
                }
            }
        }

        private void FinalizeStacks()
        {
            for (int s = 0; s < stacksOne.Length; s++)
            {
                stacksOne[s].Pop();
                stacksOne[s] = new Stack<char>(stacksOne[s]);
                stacksTwo[s] = new Stack<char>(new Stack<char>(stacksOne[s]));
            }
        }

        private void OriginalCrateMover(string[] command)
        {
            int amount = int.Parse(command[0]);
            int from = int.Parse(command[1]);
            int to = int.Parse(command[2]);

            for (int x = 0; x < amount; x++)
            {
                var crate = stacksOne[from - 1].Pop();
                stacksOne[to - 1].Push(crate);
            }
        }

        private void NewCrateMover(string[] command)
        {
            int amount = int.Parse(command[0]);
            int from = int.Parse(command[1]);
            int to = int.Parse(command[2]);

            Stack<char> tempStack = new Stack<char>();
            for (int x = 0; x < amount; x++)
            {
                var crate = stacksTwo[from - 1].Pop();
                tempStack.Push(crate);
            }

            for (int x = 0; x < amount; x++)
            {
                var crate = tempStack.Pop();
                stacksTwo[to - 1].Push(crate);
            }
        }

        public void Process()
        {
            stacksOne = new Stack<char>[9].Select(item => new Stack<char>()).ToArray();
            stacksTwo = new Stack<char>[9].Select(item => new Stack<char>()).ToArray();

            bool buildingStacks = true;

            foreach (string line in File.ReadLines(filePath))
            {
                if (buildingStacks)
                {
                    if (line.Length == 0)
                    {
                        buildingStacks = false;
                        FinalizeStacks();
                        continue;
                    }

                    BuildStackRow(line);
                }
                else
                {
                    string[] command = Regex.Replace(line, "[A-Za-z ]", " ").Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

                    OriginalCrateMover(command);
                    NewCrateMover(command);
                }
            }
            foreach(var stk in stacksOne) { Console.Write(" " + stk.Peek()); }
            Console.WriteLine(" ");

            foreach (var stk in stacksTwo) { Console.Write(" " + stk.Peek()); }
            Console.WriteLine(" ");
        }
    }
}