using System;

namespace AdventOfCode_2022
{
    class Day01Elf
    {
        public int Calories
        {
            get; set;
        }

        public Day01Elf()
        {
            Calories = 0;
        }

        internal void AddCalories(int calories)
        {
            Calories += calories;
        }
    }
}
