using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AdventOfCode2017 {
	internal class Day14 {
		static string puzzleInput = "xlqgujun";
		static int size = 256;
		internal static void Part1() {
			int usedSquares = 0;
			for (int i = 0; i < 128; i++) {
				string knotHash = CalculateKnotHash(puzzleInput + "-" + i.ToString());
				string binarystring = HashToBinary(knotHash);
				usedSquares += binarystring.Where(c => c == '1').Count();
			}
			Console.WriteLine(usedSquares);
		}

		private static string HashToBinary(string knotHash) {
			return String.Join(String.Empty, knotHash.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
		}

		internal static void Part2() {
			var grid = new bool[128,128];
			var visited = new bool[128, 128];
			for (int i = 0; i < 128; i++) {
				string knotHash = CalculateKnotHash(puzzleInput + "-" + i.ToString());
				string binarystring = String.Join(String.Empty, knotHash.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
				for (int j = 0; j < binarystring.Length; j++) {
					grid[i,j] = binarystring[j] == '1';
				}

			}

			int groupCount = 0;

			for (int i = 0; i < grid.GetLength(0); i++) {
				for (int j = 0; j < grid.GetLength(1); j++) {
					if(visited[i,j] || !grid[i, j]) { // already been here or 0 at this place
						continue;
					}
					visit(i, j, grid, visited);

					groupCount++;
				}
			}
			Console.WriteLine(groupCount);
		}

		private static void visit(int i, int j, bool[,] grid, bool[,] visited) {
			if (visited[i, j]) return; // Already been here

			visited[i, j] = true;

			if (!grid[i, j]) return; // 0 at this place nothing to do

			if (i > 0) visit(i - 1, j, grid, visited); // go left
			if (i < 127) visit(i + 1, j, grid, visited); // go right
			if (j > 0) visit(i, j - 1, grid, visited); // go up
			if (j < 127) visit(i, j + 1, grid, visited); // go down


		}

		internal static string CalculateKnotHash(string input) {
			//int size = 256;
			int rounds = 64;
			int skipSize = 0;
			int currentPosition = 0;
			int[] list = Enumerable.Range(0, size).ToArray();

			List<int> inputList = new List<int>();
			foreach (var item in input) {
				inputList.Add((int)item);
			}
			inputList.AddRange(new int[] { 17, 31, 73, 47, 23 });
			for (int r = 0; r < rounds; r++) {
				foreach (var length in inputList) {
					MakeKnot(currentPosition, list, length);
					currentPosition = (currentPosition + length + skipSize) % size;
					skipSize++;
				}
			}

			List<int> denseHash = new List<int>();
			for (int i = 0; i < size; i += 16) {
				int hash = 0;
				for (int j = 0; j < 16; j++) {
					hash ^= list[i + j];
				}
				denseHash.Add(hash);
			}

			string hexValue = "";
			foreach (var item in denseHash) {
				hexValue += item.ToString("X").PadLeft(2, '0'); // each hex should be 2 chars 28E7C4360520718A5DC811D3942CF1FD
			}
			return hexValue;
		}

		private static void MakeKnot(int currentPosition, int[] list, int length) {
			var tmpList = new int[length];
			for (int i = 0; i < length; i++) {
				tmpList[i] = list[(currentPosition + i) % size];
			}
			tmpList = tmpList.Reverse().ToArray();
			for (int i = 0; i < length; i++) {
				list[(currentPosition + i) % size] = tmpList[i];
			}
		}
	}
}