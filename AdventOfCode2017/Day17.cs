using System;

namespace AdventOfCode2017 {
	internal class Day17 {
		public static int steps = 303;
		internal static void Part1() {
			Value v = new Value();
			v.ID = 0;
			v.Next = v;
			for (int i = 0; i < 2017; i++) {
				for (int s = 0; s < steps; s++) {
					v = v.Next;
				}
				Value t = new Value();
				t.ID = i + 1;
				t.Next = v.Next;
				v.Next = t;
				v = t;
			}
			Console.WriteLine(v.ID + "- " + v.Next.ID);

		}

		internal static void Part2() {
			int position = 0;
			int lastvalue = 0;
			for (int i = 1; i <= 50000000; i++) {
				position = (position + steps + 1) % i;
				if(position == 0) {
					lastvalue = i;
				}
			}
			Console.WriteLine(lastvalue);

		}
	}
	internal class Value {
		public int ID { get; set; }
		public Value Next { get; set; }

	}
}