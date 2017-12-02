using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2017
{
    class Day2
    {

        internal static void Part1()
        {
            int checksum = 0;
            FileInfo inputfile = new FileInfo(Program.dir + "Day2.txt");
            var stream = inputfile.OpenText();
            while (!stream.EndOfStream)
            {
                string[] row = stream.ReadLine().Split('\t');
                List<int> rowlist = new List<int>();
                foreach (var item in row)
                {
                    rowlist.Add(int.Parse(item));
                }
                rowlist.Sort();
                int min = rowlist[0];
                int max = rowlist[rowlist.Count - 1];
                checksum = checksum + (max - min);

            }
            Console.WriteLine("Day 2 part 1: " + checksum);
        }



        internal static void Part2()
        {
            int checksum = 0;
            FileInfo inputfile = new FileInfo(Program.dir + "Day2.txt");
            var stream = inputfile.OpenText();
            while (!stream.EndOfStream)
            {
                string[] row = stream.ReadLine().Split('\t');
                List<int> rowlist = new List<int>();
                foreach (var item in row)
                {
                    rowlist.Add(int.Parse(item));
                }
                foreach (var item in rowlist)
                {
                    foreach (var divider in rowlist)
                    {
                        if (item != divider && item % divider == 0)
                        {
                            checksum = checksum + (item / divider);
                        }
                    }
                }
                //checksum = checksum + ; ; // + result of division

            }
            Console.WriteLine("Day 2 part 2: " + checksum);
        }
    }
}
