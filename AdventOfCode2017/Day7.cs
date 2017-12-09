using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017 {
	internal class Day7 {
		internal static List<Tower> towers;

		internal static void Part1() {
			FileInfo inputfile = new FileInfo(Program.dir + "Day7.txt");
			var stream = inputfile.OpenText();
			towers = new List<Tower>();
			while (!stream.EndOfStream) {
				Tower t = new Tower();
				string input = stream.ReadLine();
				var parts = input.Split(' ');
				t.Name = parts[0];
				t.Value = int.Parse(parts[1].Trim(new char[] { '(', ')' }));
				t.parts = parts;
				towers.Add(t);
			}
			foreach (var t in towers) {
				for (int i = 3; i < t.parts.Length; i++) {
					string subTowerName = t.parts[i].Trim(',');
					var subT = towers.Find(a => a.Name.Equals(subTowerName));
					subT.Parent = t;
					t.SubTowers.Add(subT);
				}
			}
			var startTower = towers.Find(a => a.Parent == null);
			Console.WriteLine("Start tower: " + startTower.Name);

		}

		internal static void Part2() {
			var startTower = towers.Find(a => a.Parent == null);
			int correctWeight = 0;
			int wrongWeight = 0;
			while (!startTower.isBalanced()) {
				(startTower, correctWeight) = startTower.getWrongTower();
			}
			wrongWeight = startTower.getWeight();
			Console.WriteLine(wrongWeight + " - " + correctWeight);
		}
	}
	internal class Tower {
		public string Name { get; set; }
		public List<Tower> SubTowers { get; set; }
		public string[] parts { get; set; }
		public int Value { get; set; }
		public Tower Parent { get; set; }
		
		public Tower(string Name, Tower Parent) {
			this.Name = Name;
			this.Parent = Parent;
			SubTowers = new List<Tower>();
		}
		public Tower() {
			SubTowers = new List<Tower>();
		}
		internal int getWeight() {
			return Value + SubTowers.Sum(c => c.getWeight());
		}
		internal bool isBalanced() {
			return SubTowers.GroupBy(c => c.getWeight()).Count() == 1;
		}
		internal (Tower, int) getWrongTower() {
			var groups = SubTowers.GroupBy(c => c.getWeight());
			int correctWeight = groups.First(c => c.Count() > 1).Key;
			var wrongTower = groups.First(c => c.Count() == 1).First();
			return (wrongTower, correctWeight);
		}
	}
}