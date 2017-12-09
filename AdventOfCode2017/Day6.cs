using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017 {
	internal class Day6 {
		static string input = "4	1	15	12	0	9	9	5	5	8	7	3	14	5	12	3";
		internal static void Part2() {
			//input = "0	2	7	0";
			var banks = new List<int>();
			int i = 0;
			foreach (var item in input.Split('\t')) {
				banks.Add(int.Parse(item));
			}

			var states = new List<int[]>();
			states.Add(banks.ToArray());
			while (true) {
				banks = Redistribute(banks);
				if (states.Any(c => c.SequenceEqual(banks))) {
					Console.WriteLine(states.Count - states.FindIndex(c => c.SequenceEqual(banks)));
					return;
				}
				states.Add(banks.ToArray());

			}
		}

		internal static void Part1() {
			//input = "0	2	7	0";
			var banks = new List<int>();
			int i = 0;
			foreach (var item in input.Split('\t')) {
				banks.Add(int.Parse(item));
			}

			var states = new List<int[]>();
			states.Add(banks.ToArray());
			while (true) {
				banks = Redistribute(banks);
				if (states.Any(c => c.SequenceEqual(banks))) {
					Console.WriteLine(states.Count);
					return;
				}
				states.Add(banks.ToArray());

			}
		}




		private static List<int> Redistribute(List<int> memory) {
			int largest = 0;
			for (int i = 0; i < memory.Count; i++) {
				if (memory[i] > memory[largest]) {
					largest = i;
				}
			}
			int blocks = memory[largest];
			memory[largest] = 0;
			int j = (largest + 1) % memory.Count;
			for (int i = blocks; i > 0; i--) {
				memory[j]++;
				j = (j + 1) % memory.Count;
			}
			return memory;
		}

		private static bool CompareMemory(int[] a, int[] b) {
			for (int i = 0; i < a.Length; i++) {
				if (a[i] != b[i]) {
					return false;
				}
			}
			return true;
		}
	}
}