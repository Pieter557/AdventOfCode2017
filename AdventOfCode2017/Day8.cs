using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017 {
	internal class Day8 {
		internal static void Part1() {
			FileInfo inputfile = new FileInfo(Program.dir + "Day8.txt");
			var stream = inputfile.OpenText();
			List<Register> registers = new List<Register>();
			while (!stream.EndOfStream) {
				var command = stream.ReadLine().Split(' ');
				/* 0 ugc 
				 * 1 inc 
				 * 2 294 
				 * 3 if 
				 * 4 xml 
				 * 5 <= -
				 * 6 1 */
				if (registers.FindAll(r => r.Name.Equals(command[4])).Count == 0) {
					registers.Add(new Register(command[4]));
				}
				if (registers.FindAll(r => r.Name.Equals(command[0])).Count == 0) {
					registers.Add(new Register(command[0]));
				}
				Register a = registers.Find(r => r.Name.Equals(command[4]));
				Register b = registers.Find(r => r.Name.Equals(command[0]));
				bool execute = false;
				int cmp = int.Parse(command[6]);
				switch (command[5]) {
					case ">":
						if (a.Value > cmp) execute = true;
						break;
					case "<":
						if (a.Value < cmp) execute = true;
						break;
					case "==":
						if (a.Value == cmp) execute = true;
						break;
					case "!=":
						if (a.Value != cmp) execute = true;
						break;
					case ">=":
						if (a.Value >= cmp) execute = true;
						break;
					case "<=":
						if (a.Value <= cmp) execute = true;
						break;
				}
				if (execute) {
					int c = int.Parse(command[2]);
					switch (command[1]) {
						case "inc":
							b.Value += c;
							break;
						case "dec":
							b.Value -= c;
							break;
					}
				}
			}
			var max = registers.OrderByDescending(r => r.Value).First() ;
			Console.WriteLine(max.Value);

		}

		internal static void Part2() {
			FileInfo inputfile = new FileInfo(Program.dir + "Day8.txt");
			var stream = inputfile.OpenText();
			List<Register> registers = new List<Register>();
			int max = 0;
			while (!stream.EndOfStream) {
				var command = stream.ReadLine().Split(' ');
				/* 0 ugc 
				 * 1 inc 
				 * 2 294 
				 * 3 if 
				 * 4 xml 
				 * 5 <= -
				 * 6 1 */
				if (registers.FindAll(r => r.Name.Equals(command[4])).Count == 0) {
					registers.Add(new Register(command[4]));
				}
				if (registers.FindAll(r => r.Name.Equals(command[0])).Count == 0) {
					registers.Add(new Register(command[0]));
				}
				Register a = registers.Find(r => r.Name.Equals(command[4]));
				Register b = registers.Find(r => r.Name.Equals(command[0]));
				bool execute = false;
				int cmp = int.Parse(command[6]);
				switch (command[5]) {
					case ">":
						if (a.Value > cmp) execute = true;
						break;
					case "<":
						if (a.Value < cmp) execute = true;
						break;
					case "==":
						if (a.Value == cmp) execute = true;
						break;
					case "!=":
						if (a.Value != cmp) execute = true;
						break;
					case ">=":
						if (a.Value >= cmp) execute = true;
						break;
					case "<=":
						if (a.Value <= cmp) execute = true;
						break;
				}
				if (execute) {
					int c = int.Parse(command[2]);
					switch (command[1]) {
						case "inc":
							b.Value += c;
							break;
						case "dec":
							b.Value -= c;
							break;
					}
				}
				int newmax = registers.OrderByDescending(r => r.Value).First().Value;
				if (newmax > max) max = newmax;
			}
			Console.WriteLine(max);

		}
	}
	internal class Register {
		public Register(string Name) {
			this.Name = Name;
			this.Value = 0;
		}

		public string Name { get; set; }
		public int Value { get; set; }

	}
}