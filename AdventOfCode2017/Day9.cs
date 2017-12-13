using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2017
{
    internal class Day9
    {
        internal static void Part1()
        {
            FileInfo inputfile = new FileInfo(Program.dir + "Day9.txt");
            var stream = inputfile.OpenText();
            string input = stream.ReadLine();
            int score = 0;
            int depth = 0;
            int garbageCount = 0;
            bool isGarbage = false;
            //input = "{ {< a!>}, {< a!>}, {< a!>}, {< ab >} }";
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if( c == '<' && !isGarbage)
                {
                    isGarbage = true;
                    continue;
                }
                if (isGarbage)
                {
                    if(c == '!')
                    {
                        i++;
                        continue;
                    }
                    if(c == '>')
                    {
                        isGarbage = false;
                        continue;
                    }
                    garbageCount++;
                } else
                {
                    if(c == '{')
                    {
                        depth++;
                    } else if( c == '}')
                    {
                        score += depth;
                        depth--;
                    }
                }
            }
            Console.WriteLine("Result: " + score + "\nGarbagecount: " + garbageCount);

        }

        internal static void Part2()
        {
            //throw new NotImplementedException();
        }
    }
}