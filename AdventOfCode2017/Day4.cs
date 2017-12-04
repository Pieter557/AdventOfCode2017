using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2017
{
    class Day4
    {
        internal static void Part1()
        {
            FileInfo inputfile = new FileInfo(Program.dir + "Day4.txt");
            var stream = inputfile.OpenText();
            int validPassphrases = 0;
            while (!stream.EndOfStream)
            {
                List<string> words = new List<string>();
                foreach (var item in stream.ReadLine().Split(' '))
                {
                    if (words.Contains(item))
                    {
                        break;
                    } else
                    {
                        words.Add(item);
                    }
                }
                validPassphrases++;
            }
            Console.WriteLine("Valid passphrases: " + validPassphrases);

        }

        internal static void Part2()
        {
            //throw new NotImplementedException();
        }
    }
}
