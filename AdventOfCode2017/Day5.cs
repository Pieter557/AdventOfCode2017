using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2017
{
    class Day5
    {
        internal static void Part2()
        {
            FileInfo inputfile = new FileInfo(Program.dir + "Day5.txt");
            var stream = inputfile.OpenText();
            List<int> instructions = new List<int>();
            while (!stream.EndOfStream)
            {
                string inst = stream.ReadLine();
                instructions.Add(int.Parse(inst));
            }

            int currentlocation = 0;
            int steps = 0;
            while (currentlocation < instructions.Count)
            {
                int offset = instructions[currentlocation];
                if (offset >= 3)
                {
                    instructions[currentlocation] = instructions[currentlocation] - 1;
                } else
                {
                    instructions[currentlocation] = instructions[currentlocation] + 1;
                }

                currentlocation += offset;
                steps++;
            }
            Console.WriteLine("Part 2 - Steps taken: " + steps);
        }

        internal static void Part1()
        {
            FileInfo inputfile = new FileInfo(Program.dir + "Day5.txt");
            var stream = inputfile.OpenText();
            List<int> instructions = new List<int>();
            while (!stream.EndOfStream)
            {
                string inst = stream.ReadLine();
                instructions.Add(int.Parse(inst));
            }

            int currentlocation = 0;
            int steps = 0;
            while(currentlocation < instructions.Count)
            {
                int offset = instructions[currentlocation];
                instructions[currentlocation] = instructions[currentlocation] + 1;
                currentlocation += offset;
                steps++;
            }
            Console.WriteLine("Part 1 Steps taken: " + steps);
        }
    }
}
