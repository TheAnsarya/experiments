using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2019 {
	//https://adventofcode.com/2019/day/4
	class Day04 {
		static readonly string Input = "284639-748759";

		// Answer: 895
		public string PartOne() {
			// Assuming 6 digit range values
			var range = Input.Split('-').Select(x => int.Parse(x)).ToArray();
			var to = range[1];
			var count = 0;
			//var hasDouble = new Regex(@"00|11|22|33|44|55|66|77|88|99", RegexOptions.Compiled);

			for (var i = range[0]; i <= to; i++){
				var password = i.ToString();
				if (
						((password[0] == password[1])
							|| (password[1] == password[2])
							|| (password[2] == password[3])
							|| (password[3] == password[4])
							|| (password[4] == password[5]))
						&& (password[0] <= password[1])
						&& (password[1] <= password[2])
						&& (password[2] <= password[3])
						&& (password[3] <= password[4])
						&& (password[4] <= password[5])) { 
					count++;
				}
			}

			return count.ToString();
		}

		// Answer: 591
		public string PartTwo() {
			// Assuming 6 digit range values
			var range = Input.Split('-').Select(x => int.Parse(x)).ToArray();
			var to = range[1];
			var count = 0;

			for (var i = range[0]; i <= to; i++) {
				var password = i.ToString();
				if (
						(((password[0] == password[1]) && (password[1] != password[2]))
							|| ((password[1] == password[2]) && (password[0] != password[1]) && (password[2] != password[3]))
							|| ((password[2] == password[3]) && (password[1] != password[2]) && (password[3] != password[4]))
							|| ((password[3] == password[4]) && (password[2] != password[3]) && (password[4] != password[5]))
							|| ((password[4] == password[5]) && (password[3] != password[4])))
						&& (password[0] <= password[1])
						&& (password[1] <= password[2])
						&& (password[2] <= password[3])
						&& (password[3] <= password[4])
						&& (password[4] <= password[5])) {
					count++;
				}
			}

			return count.ToString();
		}
	}
}
