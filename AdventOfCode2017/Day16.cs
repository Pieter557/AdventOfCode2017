using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace AdventOfCode2017 {
	internal class Day16 {
		internal static string programs = "abcdefghijklmnop";
		internal static void Part2() {
			FileInfo inputfile = new FileInfo(Program.dir + "Day16.txt");

			var stream = inputfile.OpenText();
			string commands = stream.ReadLine();
			programs = "abcdefghijklmnop";
			string startSTate = programs;
			//commands = "s1,x3/4,pe/b";
			//programs = "abcde";
			for (int i = 0; i < 1000000000 % 60 ; i++) {
				doDance(commands);
				if (programs == startSTate) {
					Console.WriteLine(i);
				}
			}
			Console.WriteLine(programs);
		}

		internal static void Part1() {
			FileInfo inputfile = new FileInfo(Program.dir + "Day16.txt");

			var stream = inputfile.OpenText();
			string commands = stream.ReadLine();

			//commands = "s1,x3/4,pe/b";
			//programs = "abcde";

			doDance(commands);
		}

		private static void doDance(string commands) {
			foreach (var item in commands.Split(',')) {
				switch (item[0]) {
					case 's': // SPIN
						int x = int.Parse(item.Substring(1));
						string dance = "";
						for (int i = programs.Length - x; i < programs.Length; i++) {
							dance += programs[i];
						}
						for (int i = 0; i < programs.Length - x; i++) {
							dance += programs[i];
						}
						programs = dance;
						break;
					case 'x': // EXCHANGE
						int a = int.Parse(item.Substring(1).Split('/')[0]);
						int b = int.Parse(item.Substring(1).Split('/')[1]);
						var progArray = programs.ToArray();
						char t = progArray[a];
						progArray[a] = progArray[b];
						progArray[b] = t;
						programs = new string(progArray);

						break;
					case 'p': // PARTNER
						char c = item[1];
						char d = item[3];
						var progArray2 = programs.ToArray();
						for (int i = 0; i < progArray2.Length; i++) {
							if (programs[i] == c) {
								progArray2[i] = d;
							} else if (programs[i] == d) {
								progArray2[i] = c;
							}
						}
						programs = new string(progArray2);
						break;
				}
				//Console.WriteLine(item + "\t" + programs);

			}
		}
	}
}