using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    internal class Day10
    {
        static string input = "31,2,85,1,80,109,35,63,98,255,0,13,105,254,128,33";
        static int size = 256;
        internal static void Part1()
        {
            int skipSize = 0;
            int currentPosition = 0;
            int[] list = Enumerable.Range(0, size).ToArray();

            foreach (var l in input.Split(','))
            {
                int length = int.Parse(l);

                KnotHash(currentPosition, list, length);


                currentPosition = (currentPosition + length + skipSize) % size;
                skipSize++;

            }
            Console.WriteLine(list[0] * list[1]);
            
        }

        internal static void Part2()
        {
            int rounds = 64;
            int skipSize = 0;
            int currentPosition = 0;
            int[] list = Enumerable.Range(0, size).ToArray();

            List<int> inputList = new List<int>();
            foreach (var item in input)
            {
                inputList.Add((int)item);
            }
            inputList.AddRange(new int[] { 17, 31, 73, 47, 23 });
            for (int r = 0; r < rounds; r++)
            {
                foreach (var length in inputList)
                {
                    KnotHash(currentPosition, list, length);
                    currentPosition = (currentPosition + length + skipSize) % size;
                    skipSize++;
                }
            }

            List<int> denseHash = new List<int>();
            for (int i = 0; i < size; i+= 16)
            {
                int hash = 0;
                for (int j = 0; j < 16; j++)
                {
                    hash ^= list[i+j];
                }
                denseHash.Add(hash);
            }

            string hexValue = "";
            foreach (var item in denseHash)
            {
                hexValue += item.ToString("X").PadLeft(2, '0'); // each hex should be 2 chars 28E7C4360520718A5DC811D3942CF1FD
            }
            
            Console.WriteLine(hexValue);


        }

        private static void KnotHash(int currentPosition, int[] list, int length)
        {
            var tmpList = new int[length];
            for (int i = 0; i < length; i++)
            {
                tmpList[i] = list[(currentPosition + i) % size];
            }
            tmpList = tmpList.Reverse().ToArray();
            for (int i = 0; i < length; i++)
            {
                list[(currentPosition + i) % size] = tmpList[i];
            }
        }
    }
}