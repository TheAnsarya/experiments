using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2019 {
	//https://adventofcode.com/2019/day/2
	class Day02 {
		static readonly string Input = "1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,13,1,19,1,9,19,23,2,23,13,27,1,27,9,31,2,31,6,35,1,5,35,39,1,10,39,43,2,43,6,47,1,10,47,51,2,6,51,55,1,5,55,59,1,59,9,63,1,13,63,67,2,6,67,71,1,5,71,75,2,6,75,79,2,79,6,83,1,13,83,87,1,9,87,91,1,9,91,95,1,5,95,99,1,5,99,103,2,13,103,107,1,6,107,111,1,9,111,115,2,6,115,119,1,13,119,123,1,123,6,127,1,127,5,131,2,10,131,135,2,135,10,139,1,13,139,143,1,10,143,147,1,2,147,151,1,6,151,0,99,2,14,0,0";

		// Answer: 3306701
		public string PartOne() {
			var code = Input.Split(',').Select(x => int.Parse(x)).ToArray();

			code[1] = 12;
			code[2] = 2;

			var pos = 0;
			while (code[pos] != 99) {
				if (code[pos] == 1) {
					code[code[pos + 3]] = code[code[pos + 1]] + code[code[pos + 2]];
				} else if (code[pos] == 2) {
					code[code[pos + 3]] = code[code[pos + 1]] * code[code[pos + 2]];
				} else {
					throw new Exception($"Unexpected code {code[pos]} @ {pos}");
				}

				pos += 4;
			}

			return code[0].ToString();
		}

		// Answer: 7621
		public string PartTwo() {
			var codeStart = Input.Split(',').Select(x => int.Parse(x)).ToArray();
			var target = 19690720;

			for (int noun = 0; noun < 100; noun++) {
				for (int verb = 0; verb < 100; verb++) {
					var code = (int[])codeStart.Clone();
					code[1] = noun;
					code[2] = verb;

					var pos = 0;
					while (code[pos] != 99) {
						if (code[pos] == 1) {
							code[code[pos + 3]] = code[code[pos + 1]] + code[code[pos + 2]];
						} else if (code[pos] == 2) {
							code[code[pos + 3]] = code[code[pos + 1]] * code[code[pos + 2]];
						} else {
							continue;
						}

						pos += 4;
						if (pos >= code.Length) {
							continue;
						}
					}

					if (code[0] == target) {
						return ((100 * noun) + verb).ToString();
					}
				}
			}

			return "Error, not found";
		}
	}
}
