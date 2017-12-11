using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    internal class Day11
    {
        internal static Dictionary<string, Hex> directions = new Dictionary<string, Hex>();

        internal static void Part2()
        {
            FileInfo inputfile = new FileInfo(Program.dir + "Day11.txt");
            var stream = inputfile.OpenText();
            string input = stream.ReadLine();
            Hex start = new Hex(0, 0, 0);
            int maxDistance = 0;
            Hex child = new Hex(0, 0, 0);
            foreach (var step in input.Split(','))
            {
                Hex direction = directions[step];
                child = child + direction;
                int newDistance = start.Distance(child);
                if(newDistance > maxDistance)
                {
                    maxDistance = newDistance;
                }
            }
            Console.WriteLine(maxDistance);
        }

        internal static void Part1()
        {
            directions.Add("n", new Hex(1, 0, -1));
            directions.Add("ne", new Hex(1, -1, 0));
            directions.Add("se", new Hex(0, -1, 1));
            directions.Add("s", new Hex(-1, 0, 1));
            directions.Add("sw", new Hex(-1, 1, 0));
            directions.Add("nw", new Hex(0, 1, -1));

            FileInfo inputfile = new FileInfo(Program.dir + "Day11.txt");
            var stream = inputfile.OpenText();
            string input = stream.ReadLine();
            Hex child = new Hex(0,0,0);
            foreach (var step in input.Split(','))
            {
                Hex direction = directions[step];
                child = child + direction;

            }
            Console.WriteLine((new Hex(0,0,0)).Distance(child));
        }
    }
    internal class Hex
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }

        public Hex(int x, int y, int z)
        {
            if (x + y + z == 0)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }
        public int Distance(Hex h)
        {
            return (this - h).Lenght();
        }
        public int Lenght()
        {
            return (int)((Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2);
        }
        public static Hex operator -(Hex h1, Hex h2)
        {
            return new Hex(h1.x - h2.x, h1.y - h2.y, h1.z - h2.z);
        }
        public static Hex operator +(Hex h1, Hex h2)
        {
            return new Hex(h1.x + h2.x, h1.y + h2.y, h1.z + h2.z);
        }
    }
}