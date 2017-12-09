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
                        goto NEXT;
                    } else
                    {
                        words.Add(item);
                    }
                }
                validPassphrases++;
                NEXT:
                continue;

            }
            Console.WriteLine("Valid passphrases: " + validPassphrases);

        }

        internal static void Part2()
        {
            FileInfo inputfile = new FileInfo(Program.dir + "Day4.txt");
            var stream = inputfile.OpenText();
            int validPassphrases = 0;
            while (!stream.EndOfStream)
            {
                List<string> words = new List<string>();
                foreach (String item in stream.ReadLine().Split(' '))
                {
                    var chars = item.ToCharArray();
                    Array.Sort(chars);
                    String word = new String(chars);
                    if (words.Contains(word))
                    {
                        goto NEXT;
                    }
                    else
                    {
                        words.Add(word);
                    }
                }
                validPassphrases++;
                NEXT:
                continue;

            }
            Console.WriteLine("Valid passphrases: " + validPassphrases);

        }
    }
}
