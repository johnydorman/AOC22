using System;

namespace AdventOfCode_2022
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter Day:");
                string dayInput = Console.ReadLine();

                try
                {
                    var day = int.Parse(dayInput);

                    FindTask(day);

                } catch (Exception)
                {
                    Console.WriteLine(dayInput + " is not a number.");
                }
            }

        }

        private static void FindTask(int day)
        {
            IDay dayToProcess = null;

            switch (day)
            {
                case 1:
                    dayToProcess = new Day01();
                    break;
                case 2:
                    dayToProcess = new Day02();
                    break;
                case 3:
                    dayToProcess = new Day03();
                    break;
                case 4:
                    dayToProcess = new Day04();
                    break;
                case 5:
                    dayToProcess = new Day05();
                    break;
                case 6:
                    dayToProcess = new Day06();
                    break;
                case 7:
                    dayToProcess = new Day07();
                    break;
                case 8:
                    dayToProcess = new Day08();
                    break;
                case 9:
                    dayToProcess = new Day09();
                    break;
                case 10:
                    dayToProcess = new Day10();
                    break;
                case 11:
                    dayToProcess = new Day11();
                    break;
                case 12:
                    dayToProcess = new Day12();
                    break;
                case 13:
                    dayToProcess = new Day13();
                    break;
                case 14:
                    dayToProcess = new Day14();
                    break;
                case 15:
                    dayToProcess = new Day15();
                    break;
                case 16:
                    dayToProcess = new Day16();
                    break;
                case 17:
                    dayToProcess = new Day17();
                    break;
                case 18:
                    dayToProcess = new Day18();
                    break;
                case 19:
                    dayToProcess = new Day19();
                    break;
                case 20:
                    dayToProcess = new Day20();
                    break;
                case 21:
                    dayToProcess = new Day21();
                    break;
                case 22:
                    dayToProcess = new Day22();
                    break;
                case 23:
                    dayToProcess = new Day23();
                    break;
                case 24:
                    dayToProcess = new Day24();
                    break;
                case 25:
                    dayToProcess = new Day25();
                    break;
                default:
                    Console.WriteLine("\nDay " + day + " is not implemented");
                    return;
            }

            Console.WriteLine("\n---  Running Day " + day + "  ---");
            dayToProcess.Process();
            Console.WriteLine("-----------------------\n");
        }
    }
}
