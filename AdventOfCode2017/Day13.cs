using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017 {
	internal class Day13 {
		static int totalLayers = 92;
		internal static void Part1() {
			FileInfo inputfile = new FileInfo(Program.dir + "Day13.txt");
			var stream = inputfile.OpenText();
			List<Layer> fireWall = new List<Layer>();
			while (!stream.EndOfStream) {
				var input = stream.ReadLine().Split();
				fireWall.Add(new Layer(int.Parse(input[0].Trim(':')), int.Parse(input[1])));
			}
			int severity = 0;
			foreach (var item in fireWall) {
				if(item.Depth % (2*item.Range-2) == 0) {
					severity += item.Depth * item.Range;
				}
			}
			Console.WriteLine(severity);


		}

		internal static void Part2() {
			FileInfo inputfile = new FileInfo(Program.dir + "Day13.txt");
			var stream = inputfile.OpenText();
			List<Layer> fireWall = new List<Layer>();
			while (!stream.EndOfStream) {
				var input = stream.ReadLine().Split();
				fireWall.Add(new Layer(int.Parse(input[0].Trim(':')), int.Parse(input[1])));
			}
			int delay = 0;
			bool caught = false;
			while (!caught) {
				caught = true;
				foreach (var item in fireWall) {
					if ((item.Depth+delay) % (2 * item.Range - 2) == 0) {
						caught = false;
						delay++;
						break;

					}
				}
			}

			Console.WriteLine(delay);
		}
		internal class Layer {
			public int Depth { get; set; }
			public int Range { get; set; }
			public int ScannerPosition { get; set; }
			public Layer() {
				ScannerPosition = 0;
			}
			public Layer(int Depth, int Range) {
				this.Depth = Depth;
				this.Range = Range;
				ScannerPosition = 0;
			}

		}
	}
}