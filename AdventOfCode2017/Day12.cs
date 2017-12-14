using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017 {
	internal class Day12 {
		internal static void Part1() {
			FileInfo inputfile = new FileInfo(Program.dir + "Day12.txt");
			var stream = inputfile.OpenText();
			List<Prog12> progs = new List<Prog12>();
			while (!stream.EndOfStream) {
				var input = stream.ReadLine().Split() ;
				// 1976 <-> 872, 1310, 1565, 1637
				Prog12 p;
				if (progs.Where(x => x.ID == int.Parse(input[0])).Count() > 0) {
					p = progs.Where(x => x.ID == int.Parse(input[0])).First();
				} else {
					p = new Prog12();
					p.ID = int.Parse(input[0]);
					progs.Add(p);

				}
				for (int i = 2; i < input.Length; i++) {
					int newPipe = int.Parse(input[i].Trim(','));
					Prog12 pipe;
					if(progs.Where(x => x.ID == newPipe).Count() > 0) {
						pipe = progs.Where(x => x.ID == newPipe).First();
					} else {
						pipe = new Prog12();
						pipe.ID = newPipe;
						progs.Add(pipe);
						
					}
					p.Pipes.Add(pipe);
					if (!pipe.Pipes.Contains(p)) {
						pipe.Pipes.Add(p);
					}

				}
			}

			List<Prog12> connected = new List<Prog12>();
			List<Prog12> toCheck = new List<Prog12>();
			Prog12 start = progs.Where(x => x.ID == 0).First();
			connected.Add(start);
			//Console.WriteLine("Starting with: " + start.ToString());
			toCheck.AddRange(start.Pipes);
			while(toCheck.Count > 0) {
				var nextLoop = new List<Prog12>();
		
				foreach (var item in toCheck) {
					//.WriteLine("Checking now: " + item.ToString());
					if (!connected.Contains(item)) {
						connected.Add(item);
						nextLoop.AddRange(item.Pipes);
					}
				}
				toCheck = nextLoop;
			}
			Console.WriteLine(connected.Count);


		}

		internal static void Part2() {
			FileInfo inputfile = new FileInfo(Program.dir + "Day12.txt");
			var stream = inputfile.OpenText();
			List<Prog12> progs = new List<Prog12>();
			while (!stream.EndOfStream) {
				var input = stream.ReadLine().Split();
				// 1976 <-> 872, 1310, 1565, 1637
				Prog12 p;
				if (progs.Where(x => x.ID == int.Parse(input[0])).Count() > 0) {
					p = progs.Where(x => x.ID == int.Parse(input[0])).First();
				} else {
					p = new Prog12();
					p.ID = int.Parse(input[0]);
					progs.Add(p);

				}
				for (int i = 2; i < input.Length; i++) {
					int newPipe = int.Parse(input[i].Trim(','));
					Prog12 pipe;
					if (progs.Where(x => x.ID == newPipe).Count() > 0) {
						pipe = progs.Where(x => x.ID == newPipe).First();
					} else {
						pipe = new Prog12();
						pipe.ID = newPipe;
						progs.Add(pipe);

					}
					p.Pipes.Add(pipe);
					if (!pipe.Pipes.Contains(p)) {
						pipe.Pipes.Add(p);
					}

				}
			}
			int groups = 0;

			while (progs.Count > 0) {
				List<Prog12> connected = new List<Prog12>();
				List<Prog12> toCheck = new List<Prog12>();
				Prog12 start = progs.First();
				connected.Add(start);
				Console.WriteLine("Starting with: " + start.ToString());
				toCheck.AddRange(start.Pipes);

				if (progs.Contains(start)) { progs.Remove(start); }

				while (toCheck.Count > 0) {
					var nextLoop = new List<Prog12>();

					foreach (var item in toCheck) {
						//Console.WriteLine("Checking now: " + item.ToString());
						if (!connected.Contains(item)) {
							connected.Add(item);
							nextLoop.AddRange(item.Pipes);
							if (progs.Contains(item)) { progs.Remove(item); }
						}
					}
					toCheck = nextLoop;
				}
				Console.WriteLine(connected.Count);
				groups++;
				connected.Clear();
				toCheck.Clear();

			}
			Console.WriteLine(groups);
		}

	
	}
	internal class Prog12 {
		public int ID { get; set; }
		public List<Prog12> Pipes { get; set; }
		public Prog12() {
			Pipes = new List<Prog12>();
		}
		public string ToString() {
			string s = "";
			s += ID;
			s += " <=> ";
			foreach (var item in Pipes) {
				s += item.ID + ", ";
			}
			return s;
		}
	}
}