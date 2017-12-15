using System;

namespace AdventOfCode2017 {
	internal class Day15 {
		static int inputA = 116;
		static int inputB = 299;

		static int factorA = 16807;
		static int factorB = 48271;

		static int divider = 2147483647;


		internal static void Part1() {
			int maxPairs = 40000000;
			long valueA = inputA;
			long valueB = inputB;
			int pairs = 0;
			for (int i = 0; i < maxPairs; i++) {
				valueA = (valueA * factorA) % divider;
				valueB = (valueB * factorB) % divider;
				if ((valueA & 65535) == (valueB & 65535)) pairs++;
			}
			Console.WriteLine(pairs);
		}

		internal static void Part2() {
			int maxPairs = 5000000;
			long valueA = inputA;
			long valueB = inputB;
			int pairs = 0;
			for (int i = 0; i < maxPairs; i++) {
				while (true) {
					valueA = (valueA * factorA) % divider;
					if (valueA % 4 == 0) break;
				}
				while (true) {
					valueB = (valueB * factorB) % divider;
					if (valueB % 8 == 0) break;
				}

				if ((valueA & 65535) == (valueB & 65535)) pairs++;

			}
			Console.WriteLine(pairs);
		}
	}
}